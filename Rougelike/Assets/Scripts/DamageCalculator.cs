using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SkillBase
{
    int modifiedDamage;

    public int CalculateDamage(Character attacker, Character defender, ISkill skill)
    {
        modifiedDamage = skill.damage;
        
        // If the skill has a damagetype
        if(skill.damageType != DamageType.None)
        {
            AddStatDamage(attacker, skill);
        }

        if(skill.element != Element.None)
        {
            if (defender.ElementalWeaknesses.Contains(skill.element))    // If enemy has resistance to element, then...
            {
                // Damage is halved
                modifiedDamage = (int)(modifiedDamage * 2);
            }

            if (defender.ElementalResistances.Contains(skill.element))    // If enemy has resistance to element, then...
            {
                // Damage is halved
                modifiedDamage = (int)(modifiedDamage * .5);
            }
        }

        return modifiedDamage;
    }

    public void AddStatDamage(Character attacker, ISkill skill)
    {
        if (skill.damageType == DamageType.Physical)
        {
            modifiedDamage += attacker.PhysAtk;
        }

        if (skill.damageType == DamageType.Magic)
        {
            modifiedDamage += attacker.MagAtk;
        }
    }
}

