using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class DamageCalculator
{
    Ability skill;
    int finalDamage;
    public DamageCalculator(Ability _skill)
    {
        skill = _skill;
    }

    /// <summary>
    /// Calculate the damage based on various attributes
    /// </summary>
    public int CalculateDamage(int damage, Character defender)
    {
        finalDamage = CheckStrengthsAndWeaknesses(damage, defender);
        return finalDamage;
    }

    public int CheckStrengthsAndWeaknesses(int damageBeingModified, Character defender)
    {
        int modifiedDamage = damageBeingModified;

        if (skill.element != null)
        {
            // Check if the defender is weak to that element
            foreach (var weakness in defender.weaknesses)
            {
                if (weakness.GetType() == skill.element.GetType()) // Because we are using classes, we have to go by its types.  If the type is found in their weaknesses, then...
                {
                    // Damage is doubled
                    modifiedDamage = (int)(modifiedDamage * 2);
                }
            }

            // Check if the defender is resistant to the element
            foreach (var resistance in defender.resistances)
            {
                if (resistance.GetType() == skill.element.GetType()) // Because we are using classes, we have to go by its types.  If the type is found in their resistances, then...
                {
                    // Damage is halved
                    modifiedDamage = (int)(modifiedDamage * .5);
                }
            }

            // Check if the defender is immune to the element
            foreach (var immunity in defender.immunities)
            {
                if (immunity.GetType() == skill.element.GetType()) // Because we are using classes, we have to go by its types.  If the type is found in their resistances, then...
                {
                    // Damage is set to nothing
                    modifiedDamage = 0;
                }
            }

            // Check if the defender heals from the element
            foreach (var advantage in defender.advantages)
            {
                if (advantage.GetType() == skill.element.GetType()) // Because we are using classes, we have to go by its types.  If the type is found in their resistances, then...
                {
                    // Damage is set to negative, Healing the enemy
                    modifiedDamage = (int)(modifiedDamage * -1);
                }
            }
        }
        return modifiedDamage;
    }
}



