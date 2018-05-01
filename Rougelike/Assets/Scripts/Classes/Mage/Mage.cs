using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Mage : IClassType
{
    public string className { get; set; }

    public List<ISkill> skills { get; set; }

    public IStatModifier statModifier { get; set; }
    public Mage(Character character)
    {
        className = "Mage";
        statModifier = new MageModifier(character);
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

