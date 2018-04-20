using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : LivingEntity
{
    public IClassType classType;

    public MyPlayer(string _name, int _healthPoints, int _magicPoints, int _physicalAttack, int _magicAttack, int _speed, IClassType _thisClass)
    {
        classType = _thisClass;
    }

    public void SetClass(IClassType newClass)
    {
        classType = newClass;
    }
}
