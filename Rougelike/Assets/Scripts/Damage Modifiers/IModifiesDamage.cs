using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public interface IModifiesDamage
{
    int damageModifier { get; set; }
    int damage { get; set; }
    void SetDamageModifier(int damageMultipliedBy);

}

