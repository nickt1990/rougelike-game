using UnityEngine;
using System.Collections;


public interface IMovementBehavior
{
    void CheckMovement();
    IEnumerator SmoothMovement(Vector3 end);
}


