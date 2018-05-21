using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Active skill that is often used by Paladin
/// </summary>
public class Smite : Skill
{
    public Smite()
    {
        name = "Smite";
        damage = 50;
        element = new Holy();
    }

}

