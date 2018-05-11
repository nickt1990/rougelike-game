using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// The base for that all fire skills must inherit
/// </summary>
public class FireSpell : Spell
{
    /// <summary>
    /// Base constructor for a spell with the fire element attached to it
    /// </summary>
    public FireSpell()
    {
        element = new Fire();
    }

    /// <summary>
    /// Constructor if you would like to add a status effect to the fire spell
    /// </summary>
    /// <param name="statusEffect"> The status effect that you would like to be added to the spell </param>
    public FireSpell(StatusEffect statusEffect)
    {
        element = new Fire(statusEffect);
    }

    /// <summary>
    /// Generic fire spell
    /// </summary>
    /// <param name="_name"> Name of the spell </param>
    /// <param name="_damage"> Damage that the spell deals </param>
    public FireSpell(string _name, int _damage)
    {
        _name = name;
        _damage = damage;
        element = new Fire();
    }

    /// <summary>
    /// Generic fire spell with status effect
    /// </summary>
    /// <param name="_name"> Name of the spell </param>
    /// <param name="_damage"> Damage that the spell deals</param>
    /// <param name="statusEffect"> Status effect that will be attached to the spell</param>
    public FireSpell(string _name, int _damage, StatusEffect statusEffect)
    {
        _name = name;
        _damage = damage;
        element = new Fire(statusEffect);
    }
}

