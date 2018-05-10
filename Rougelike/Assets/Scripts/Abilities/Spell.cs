using System;

public class Spell : Ability
{
    int damageModifier; // The percentage in which the damage will be modified

    public Spell()
    {
        damageModifier = 1;
        damageType = new MagicDamageType();
    }
    public Spell(string _name, int _damage, BaseDamageType _damageType, ElementBase _element)
    {
        name = _name;
        damage = _damage;
        damageType = _damageType;
        element = _element;
    }

    public Spell(int _damageModifier)
    {
        damageModifier = _damageModifier;
    }

    public override void AddStatDamage(ClassType characterClass)
    {
        damage += characterClass.classStats.MagAtk;
    }
}


