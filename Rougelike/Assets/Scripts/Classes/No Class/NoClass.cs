using System;
using System.Collections.Generic;

/// <summary>
/// This class will set the default stats to the character.
/// All characters start with no class, so all characters will go through the constructor of this class upon their instantiation.
/// </summary>
public class NoClass : IClassType
{
    public IStatModifier statModifier { get; set; }
    public List<ISkill> skills { get; set; }
    public string className { get; set; }

    public NoClass(Character character)
    {
        className = "No Class";
        statModifier = new BaseModifier(character);
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
