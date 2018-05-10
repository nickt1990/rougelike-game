using System;

public class Skill : Ability
{
    int damageModifier; // The percentage in which the damage will be modified

    public Skill()
    {
        damageModifier = 1;
        damageType = new PhysicalDamageType();
    }
    public Skill(string _name, int _damage, BaseDamageType _damageType, ElementBase _element)
    {
        name = _name;
        damage = _damage;
        damageType = _damageType;
        element = _element;
    }

    public Skill(int _damageModifier)
    {
        damageModifier = _damageModifier;
    }

    public override void AddStatDamage(ClassType characterClass)
    {
        damage += characterClass.classStats.PhysAtk;
    }
}


