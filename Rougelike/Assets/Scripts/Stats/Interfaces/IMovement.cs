using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    float moveTime { get; set; }            //Time it will take object to move, in seconds.
    float inverseMoveTime { get; set; }     //Used to make movement more efficient.

    //Move returns true if it is able to move and false if not. 
    //Move takes parameters for x direction, y direction and a RaycastHit2D to check collision.
    bool Move(int xDir, int yDir, out RaycastHit2D hit);


    //Co-routine for moving units from one space to next, takes a parameter end to specify where to move to.
    IEnumerator SmoothMovement(Vector3 end);


    //The virtual keyword means AttemptMove can be overridden by inheriting classes using the override keyword.
    //AttemptMove takes a generic parameter T to specify the type of component we expect our unit to interact with if blocked (Player for Enemies, Wall for Player).
    void AttemptMove<T>(int xDir, int yDir)
        where T : Component;


    //The abstract modifier indicates that the thing being modified has a missing or incomplete implementation.
    //OnCantMove will be overriden by functions in the inheriting classes.
    void OnCantMove<T>(T component)
            where T : Component;
}
