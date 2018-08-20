using UnityEngine;
using System.Collections;


public interface IMovementBehavior
{
    void CheckMovement();
    void CheckInput(int sweetSpot);

    IEnumerator SmoothMovement(Vector3 end);
}


