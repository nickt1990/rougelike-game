using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Smite : Skill
{
    public Smite()
    {
        name = "Smite";
        damage = 50;
        element = new Holy();
    }

}

