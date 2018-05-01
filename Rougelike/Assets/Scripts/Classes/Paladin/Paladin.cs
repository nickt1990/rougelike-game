using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Paladin : IClassType
{
    public string className { get; set; }

    public IStatModifier statModifier { get; set; }

    public List<ISkill> skills { get; set; }

    public ISkill skill;

    public Paladin(Character character)
    {
        className = "Paladin";
        statModifier = new PaladinModifier(character);
        skills = AddDefaultSkills();

    }

    public List<ISkill> AddDefaultSkills()
    {
        List<ISkill> allSkills = new List<ISkill>();

        allSkills.Add(new FireBall());
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



