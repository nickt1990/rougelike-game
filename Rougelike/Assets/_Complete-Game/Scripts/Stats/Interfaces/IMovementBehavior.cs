using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementBehavior
{
    void AttemptMove<T>(int xDir, int yDir, LivingEntity playerMoving);
}
