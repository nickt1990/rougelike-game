using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Paladin : IClassType
{
    string _className;
    public Paladin()
    {
        _className = "Paladin";
    }

    public string GetClassName()
    {
        return _className;
    }

    public void StatModifier()
    {
        Console.WriteLine("My magic and strength are high.  But my speed is low");
    }

    public void Strength()
    {
        Console.WriteLine("I can heal AND attack");
    }

    public void Weakness()
    {
        Console.WriteLine("I have no weaknesses.  I am invincible");
    }
}

