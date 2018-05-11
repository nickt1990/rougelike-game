using System;

public class Spell : Ability
{
    public Spell()
    {
        damageType = new MagicDamageType();
    }
    public Spell(string _name, int _damage, BaseDamageType _damageType, ElementBase _element)
    {
        name = _name;
        damage = _damage;
        damageType = _damageType;
        element = _element;
    }

    /// <summary>
    /// A spell is a magic-type move, so this method will apply the characters classes magic attack to its damage
    /// </summary>
    /// <param name="characterClass"> The class that we grab tha magic attack value from </param>
    public override void AddStatDamage(ClassType characterClass)
    {
        damage += characterClass.classStats.MagAtk;
    }
}


