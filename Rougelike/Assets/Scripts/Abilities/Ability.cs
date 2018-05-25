/// <summary>
/// The parent class of all skills and spells - Gives them their basic properties.
/// </summary>
public abstract class Ability : DamageModifier
{
    public string name { get; set; }
    public int damage { get; set; }
    public DamageType damageType { get; set; }
    public Element element { get; set; }
    public StatusEffect statusEffect { get; set; }
    public DamageCalculator damageCalculator;

    public int modifiedDamage; // The actual damage after the modifier (and everything) has been applied
    public int damageModifier = 1; // The percentage in which the damage will be modified

    /// <summary>
    /// Base constructor that simply adds a damage calculator to the ability
    /// </summary>
    public Ability()
    {
        damageCalculator = new DamageCalculator(this);
    }

    public Ability(string _name, int _damage, DamageType _damageType, Element _element)
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
        // Overriden by child classes - Do not delete
    }

    /// <summary>
    /// Rules that every ability must follow when cast
    /// </summary>
    /// <param name="attacker"> Character casting the spell </param>
    /// <param name="defender"> Character being hit by the spell</param>
    public virtual void Cast(Character attacker, Character defender)
    {
        Player caster = attacker as Player;
        Enemy target = defender as Enemy;
       
        // Calculate the damage based on the defenders strengths and weaknesses
        modifiedDamage = damageCalculator.CalculateDamage(damage, defender);

        // Defender takes the modified damage amount
        target.TakeDamage(modifiedDamage);

        if (target.CheckIfDead())
        {
            caster.AddExperience(target.experience);
        }
    }
}


