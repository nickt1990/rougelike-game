using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class HolySpell : Spell
{
    /// <summary>
    /// Base constructor for a spell with the holy element attached to it
    /// </summary>
    public HolySpell()
    {
        element = new Holy();
    }

    /// <summary>
    /// Constructor if you would like to add a status effect to the spell
    /// </summary>
    /// <param name="statusEffect"> The status effect that you would like to be added to the spell </param>
    public HolySpell(StatusEffect statusEffect)
    {
        element = new Holy(statusEffect);
        damageModifier = statusEffect.damageModifier;
    }

    /// <summary>
    /// Generic holy spell
    /// </summary>
    /// <param name="_name"> Name of the spell </param>
    /// <param name="_damage"> Damage that the spell deals </param>
    public HolySpell(string _name, int _damage)
    {
        _name = name;
        _damage = damage;
        element = new Holy();
    }

    /// <summary>
    /// Generic holy spell with status effect
    /// </summary>
    /// <param name="_name"> Name of the spell </param>
    /// <param name="_damage"> Damage that the spell deals</param>
    /// <param name="statusEffect"> Status effect that will be attached to the spell</param>
    public HolySpell(string _name, int _damage, StatusEffect statusEffect)
    {
        _name = name;
        _damage = damage;
        element = new Holy(statusEffect);

        damageModifier = statusEffect.damageModifier;
    }
}

