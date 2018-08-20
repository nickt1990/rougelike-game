using UnityEngine;
using System.Collections;


public interface IMovementBehavior
{
    void CheckMovement();

    //void InitiateMove(KeyCode direction);

    IEnumerator SmoothMovement(Vector3 end);
}


