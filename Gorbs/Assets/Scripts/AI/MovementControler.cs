using System.Collections;
using UnityEngine;

public class MovementControler : MonoBehaviour
{
    [SerializeField]
    float xBound;
    [SerializeField]
    float zBound;
    bool looking = false;
    float elapsedTime = 0.0f;
    float percentageCompleted = 0.0f;
    float desiredDuration;
    float minWait = 45.0f;
    float maxWait = 120.0f;
    Vector3 newPos;
    BaseMovementAI baseMovementAI;
    SpriteRenderer renderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        baseMovementAI = new BaseMovementAI();
        renderer = this.GetComponent<SpriteRenderer>();
        desiredDuration = Random.Range(minWait, maxWait);
        newPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!looking){
            StartCoroutine(lookCoroutine());
        }
        elapsedTime += Time.deltaTime;
        percentageCompleted = elapsedTime / desiredDuration;
        this.transform.position = Vector3.Lerp(transform.position, newPos, percentageCompleted);
    }

    IEnumerator lookCoroutine(){
        looking = true;
        baseMovementAI.queueNewPosition(xBound,zBound);
        yield return new WaitForSeconds(Random.Range(minWait / 15, maxWait / 15));
        newPos = baseMovementAI.moveToNextPosition();
        if(newPos.x < transform.position.x){ //Flip Left
            renderer.flipX = true;
        }else if(newPos.x > transform.position.x){ //Flip Right
            renderer.flipX = false;
        }
        desiredDuration = Random.Range(minWait, maxWait);
        elapsedTime = 0.0f;
        looking = false;
    }
}
