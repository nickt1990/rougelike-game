using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Skill_Fire : SkillBase
{
    public Skill_Fire(string _name, int _damage)
    {
        name = _name;
        damage = _damage;
        element = new Fire();
    }

    public Skill_Fire(string _name, int _damage, StatusEffectBase statusEffect)
    {
        name = _name;
        damage = _damage;
        element = new Fire(statusEffect);
    }
}

