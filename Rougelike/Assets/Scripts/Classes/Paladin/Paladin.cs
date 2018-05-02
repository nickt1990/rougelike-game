using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Paladin : PaladinModifier, IClassType
{
    public string className { get; set; }

    public IStatModifier statModifier { get; set; }

    public List<ISkill> skills { get; set; }

    public ISkill skill;

    /// <summary>
    /// Sets the class name and adds skills to the class
    /// </summary>
    /// 
    /// Base: This is the PaladinModifer, which modifies all stats to fit that of a Paladin.
    /// 
    /// <param name="character"> The character that is becoming the mage class </param>
    public Paladin(Character character) : base(character)
    {
        className = "Paladin";
        statModifier = new PaladinModifier(character);
        skills = AddDefaultSkills();

    }

    public List<ISkill> AddDefaultSkills()
    {
        List<ISkill> allSkills = new List<ISkill>();

        allSkills.Add(new DoubleStab());
        allSkills.Add(new Heal());

        return allSkills;
    }

    public string GetClassName()
    {
        return className;
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



