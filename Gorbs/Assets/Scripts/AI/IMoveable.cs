using System.Collections.Generic;
using UnityEngine;

public abstract class IMoveable
{
    protected Queue<Vector3> positions;
    protected bool isFacingRight;

    public abstract void queueNewPosition(float xRange, float zRange);
    public abstract Vector3 moveToNextPosition();
}
