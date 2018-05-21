using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    void PerformPhysicalAttack<T>(T component) where T : Component;

    void PerformMagicAttack<T>(T component) where T : Component;

}
