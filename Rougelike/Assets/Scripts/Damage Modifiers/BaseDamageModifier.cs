using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BaseDamageModifier : IModifiesDamage
{
    private int _damageModifier;
    public int damageModifier
    {
        get
        {
            return _damageModifier;
        }
        set
        {
            _damageModifier = value;
        }
    }

    public int damage { get; set; }


    public void SetDamageModifier(int damageMultipliedBy)
    {
        damageModifier = damageMultipliedBy;
    }
}

