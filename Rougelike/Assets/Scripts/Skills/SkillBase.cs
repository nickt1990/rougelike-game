using System;

public class SkillBase : ISkill
{
    public string name { get; set; }
    public int damage { get; set; }
    public IModifiesDamage damageType { get; set; }
    public IModifiesDamage element { get; set; }
    public IModifiesDamage statusEffect { get; set; }

    public int modifiedDamage; // The actual damage after the modifier (and everything) has been applied
    int damageModifier; // The percentage in which the damage will be modified

    public SkillBase()
    {
        damageModifier = 1;
    }

    public SkillBase(int _damageModifier)
    {
        damageModifier = _damageModifier;
    }

    public void CalculateDamage(Character attacker, Character defender)
    {
        modifiedDamage = damage;

        modifiedDamage += damageType.damage;

        // If the skill has an element, then...
        if (element != null)
        {
            // Check if the defender is weak to that element
            foreach (var weakness in defender.weaknesses)
            {
                if(weakness.GetType() == element.GetType()) // Because we are using classes, we have to go by its types.  If the type is found in their weaknesses, then...
                {
                    // Damage is doubled
                    modifiedDamage = (int)(modifiedDamage * 2);
                }
            }

            // Check if the defender is resistant to the element
            foreach (var resistance in defender.resistances)
            {
                if (resistance.GetType() == element.GetType()) // Because we are using classes, we have to go by its types.  If the type is found in their resistances, then...
                {
                    // Damage is halved
                    modifiedDamage = (int)(modifiedDamage * .5);
                }
            }

            // Check if the defender is immune to the element
            foreach (var immunity in defender.immunities)
            {
                if (immunity.GetType() == element.GetType()) // Because we are using classes, we have to go by its types.  If the type is found in their resistances, then...
                {
                    // Damage is set to nothing
                    modifiedDamage = 0;
                }
            }

            // Check if the defender heals from the element
            foreach (var advantage in defender.advantages)
            {
                if (advantage.GetType() == element.GetType()) // Because we are using classes, we have to go by its types.  If the type is found in their resistances, then...
                {
                    // Damage is set to negative, Healing the enemy
                    modifiedDamage = (int)(modifiedDamage * -1);
                }
            }
        }
    }

    public virtual void Cast(Character attacker, Character defender)
    {
        Enemy target = defender as Enemy;

        damageType = new PhysicalDamageType(attacker.MagicAttack);

        CalculateDamage(attacker, defender);

        target.TakeDamage(modifiedDamage);
    }
}


