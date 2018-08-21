using UnityEngine;
using System.Collections;


public interface IMovementBehavior
{
    void CheckMovement();
<<<<<<< HEAD
=======

    //void InitiateMove(KeyCode direction);
>>>>>>> 0e9fcdd1b57ca0e9212c38a4153abbc4effcaf30

    IEnumerator SmoothMovement(Vector3 end);
}


