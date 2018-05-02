using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Mage : MageModifier, IClassType
{
    public string className { get; set; }

    public List<ISkill> skills { get; set; }

    /// <summary>
    /// Sets the class name and adds skills to the class
    /// </summary>
    /// 
    /// Base: This is the MageModifier, which modifies all stats to fit that of a mage.
    /// 
    /// <param name="character"> The character that is becoming the mage class </param>
    public Mage(Character character) : base (character)
    {
        className = "Mage";
        skills = AddDefaultSkills();
    }

    public List<ISkill> AddDefaultSkills()
    {
        List<ISkill> allSkills = new List<ISkill>();

        allSkills.Add(new Heal());
        allSkills.Add(new FireBall());
        
        return allSkills;
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

