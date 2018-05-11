using System;

public class Skill : Ability
{
    public Skill()
    {
        damageType = new PhysicalDamageType();
    }
    public Skill(string _name, int _damage, BaseDamageType _damageType, ElementBase _element)
    {
        name = _name;
        damage = _damage;
        damageType = _damageType;
        element = _element;
    }

    /// <summary>
    /// A skill is a physical damage ability, so we apply the physical attack of the class with said skill
    /// </summary>
    /// <param name="characterClass"> The class that has been given a skill </param>
    public override void AddStatDamage(ClassType characterClass)
    {
        damage += characterClass.classStats.PhysAtk;
    }
}


