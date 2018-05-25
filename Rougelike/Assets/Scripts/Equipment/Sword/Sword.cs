using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Equipment
{

    public Sword(string Name, int HealthPoints, int MagicPoints, int PhysicalAttack, int MagicAttack, int Speed)
    {
        equipmentName = Name;
        stats.HP = HealthPoints;
        stats.MP = MagicPoints;
        stats.PhysAtk = PhysicalAttack;
        stats.MagAtk = MagicAttack;
        stats.Speed = Speed;
        this.element = element;

        equipmentType = EquipmentType.Weapon;

    }

    public Sword(string Name, int HealthPoints, int MagicPoints, int PhysicalAttack, int MagicAttack, int Speed, Element element)
    {
        equipmentName = Name;
        stats.HP = HealthPoints;
        stats.MP = MagicPoints;
        stats.PhysAtk = PhysicalAttack;
        stats.MagAtk = MagicAttack;
        stats.Speed = Speed;
        this.element = element;

        equipmentType = EquipmentType.Weapon;
    }
}
