using System;

public abstract class Ability
{
    public string name { get; set; }
    public int damage { get; set; }
    public BaseDamageType damageType { get; set; }
    public ElementBase element { get; set; }
    public StatusEffect statusEffect { get; set; }
    public DamageCalculator damageCalculator;

    public int modifiedDamage; // The actual damage after the modifier (and everything) has been applied
    int damageModifier; // The percentage in which the damage will be modified

    public Ability()
    {
        damageCalculator = new DamageCalculator(this);
    }
    public Ability(string _name, int _damage, BaseDamageType _damageType, ElementBase _element)
    {
        name = _name;
        damage = _damage;
        damageType = _damageType;
        element = _element;
        damageCalculator = new DamageCalculator(this);
    }

    public Ability(int _damageModifier)
    {
        damageModifier = _damageModifier;
        damageCalculator = new DamageCalculator(this);
    }

    public virtual void AddStatDamage(ClassType characterClass)
    {
        
    }

    public virtual void Cast(Character attacker, Character defender)
    {
        Enemy target = defender as Enemy;

        damageCalculator.CalculateDamage(damage, defender);

        target.TakeDamage(damageCalculator.CalculateDamage(damage, defender));
    }
}


