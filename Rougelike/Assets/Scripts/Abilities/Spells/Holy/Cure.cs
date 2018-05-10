using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Cure : HolySpell
{ 
    public Cure() : base(new Heal())
    {
        name = "Cure";
        damage = 30;
    }

    public Cure(string _name, int _damage, StatusEffect statusEffect) : base (statusEffect)
    {
        name = _name;
        _damage = damage;
    }

    public override void Cast(Character attacker, Character defender)
    {
        base.Cast(attacker, defender);
    }

}


