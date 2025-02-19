using System.Collections.Generic;
using UnityEngine;

public class BaseMovementAI : IMoveable
{

    public BaseMovementAI()
    {
        this.positions = new Queue<Vector3>();
    }

    public override void queueNewPosition(float xRange, float zRange)
    {
        Debug.Log($"Adding new Position, Count at: {this.positions.Count}");
        if (this.positions.Count < 5) {
            Vector3 newPos = new Vector3(Random.Range(-1 * xRange, xRange), 0,Random.Range(-1 * zRange, zRange));
            this.positions.Enqueue(newPos);
        }
        
    }

    public override Vector3 moveToNextPosition()
    {
        if( this.positions.Count > 0){
            return this.positions.Dequeue();
        } else{
            return Vector3.zero; //Should be original position
        }
    }
}
