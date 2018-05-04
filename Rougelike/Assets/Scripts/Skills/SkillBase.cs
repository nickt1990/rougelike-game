using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SkillBase : ISkill
{
    public string name { get; set; }
    public int damage { get; set; }
    public IModifiesDamage damageType { get; set; }
    public IModifiesDamage element { get; set; }

    int modifiedDamage; // The actual damage after the modifier (and everything) has been applied
    int damageModifier; // The percentage in which the damage will be modified

    public SkillBase()
    {
        damageModifier = 1;
    }

    public SkillBase(int _damageModifier)
    {
        damageModifier = _damageModifier;
    }

    public int CalculateDamage(Character attacker, Character defender, ISkill skill)
    {
        modifiedDamage = skill.damage;

        if(element != null)
        {
            foreach (var weakness in defender.weaknesses)
            {
                if(weakness.GetType() == element.GetType()) // Because we are using classes, we have to go by their types.  So, if their type exists, then...
                {
                    // Damage is halved
                    modifiedDamage = (int)(modifiedDamage * 2);
                }
            }

            foreach (var resistance in defender.resistances)
            {
                if (resistance.GetType() == element.GetType())
                {
                    // Damage is halved
                    modifiedDamage = (int)(modifiedDamage * .5);
                }
            }

        }

        return modifiedDamage;
    }

    public virtual void Cast(Character attacker, Character defender)
    {
        throw new NotImplementedException();
    }
}

