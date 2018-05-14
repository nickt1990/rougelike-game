using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Equipment
{
    public int damage;
    public Sword(string _name, int _damage, Element _element)
    {
        name = _name;
        damage = _damage;
        element = _element;
    }
}
