using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : LivingEntity, IStats
{
    public int _healthPoints;
    public int _magicPoints;
    public int _physicalAttack;
    public int _magicAttack;
    public int _speed;

    public IClassType classType;

    public MyPlayer(string name, int healthPoints, int magicPoints, int physicalAttack, int magicAttack, int speed, IClassType thisClass)
    {
        _name = name;
        _healthPoints = healthPoints;
        _magicPoints = magicPoints;
        _physicalAttack = physicalAttack;
        _magicAttack = magicAttack;
        _speed = speed;
        classType = thisClass;
    }

    public void SetClass(IClassType newClass)
    {
        classType = newClass;
    }


    public int healthPoints { get; set; }

    public int magicPoints { get; set; }
    public int physicalAttack {get; set;}
    public int magicAttack { get; set; }
    public int speed { get; set; }
}
