using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Equipment : IDamageModifier
{
    public string name;
    public Element element { get; set; }
    public DamageCalculator damageCalculator;

    public Equipment()
    {
        damageCalculator = new DamageCalculator(this);
    }

    public void OnPickUp()
    {

    }
}

