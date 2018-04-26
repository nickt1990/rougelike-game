using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Paladin : IClassType
{
    public Character character;
    public string className { get; set; }

    public IStatModifier statModifier { get; set; }
    public ISkill skill;
    public List<ISkill> skills = new List<ISkill>();

    public Paladin(Character _character)
    {
        character = _character;
        className = "Paladin";
        AddDefaultSkills();
        statModifier = new PaladinModifier(_character);
    }

    public void AddDefaultSkills()
    {
        skills.Add(new DoubleStab());
        skills.Add(new Heal());
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

