using UnityEngine;
using System.Collections;


public interface IMovementBehavior
{
	void SetControls();
    void CheckMovement();
    IEnumerator SmoothMovement(Vector3 end);
}


