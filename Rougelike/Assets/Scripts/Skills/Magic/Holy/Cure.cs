using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Cure : SkillBase
{
    public Cure()
    {
        element = new Holy(new Heal());
        name = "Cure";
        damage = 30 * element.damageModifier;
    }

    public Cure(string _name, int _damage)
    {
        element = new Holy(new Heal());
        name = _name;
    }
}


