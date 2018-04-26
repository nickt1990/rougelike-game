using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Mage : IClassType
{
    public Character character;
    public string className { get; set; }

    public IStatModifier statModifier { get; set; }

    public Mage(Character _character)
    {
        character = _character;
        className = "Mage";
        statModifier = new MageModifier(_character);
    }

    public string GetClassName()
    {
        return className;
    }

    public void Strength()
    {
        throw new NotImplementedException();
    }

    public void Weakness()
    {
        throw new NotImplementedException();
    }
}

