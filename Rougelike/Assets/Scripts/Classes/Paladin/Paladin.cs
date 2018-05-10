using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Paladin : ClassType
{
    /// <summary>
    /// Sets the class name and adds skills to the class
    /// </summary>
    /// 
    /// Base: This is the ClassBase, which takes care of adding base stats
    /// 
    /// <param name="character"> The character that is becoming the mage class </param>
    public Paladin(Character character) : base (character)
    {
        className = "Paladin";

        ModifyStats();

        // Add Default abilities
        AddAbility(new DoubleStab());
        AddAbility(new Cure());

        SetSkillsToButtons();
    }

    public void ModifyStats()
    {                                                                               // Paladin recieves:
        classStats.HP = classStats.HP + (int)(classStats.HP * .5);                  // 50% more hp.
        classStats.MP = classStats.MP + (int)(classStats.MP * .25);                 // 25% more mp.
        classStats.PhysAtk = classStats.PhysAtk + (int)(classStats.PhysAtk * .25);  // 25% more physical attack.
        classStats.MagAtk= classStats.MagAtk + (int)(classStats.MagAtk * .25);      // 25% more magic attack.
        classStats.Speed = classStats.Speed - (int)(classStats.Speed * .25);        // 25% less speed.

        character.maxHP = classStats.HP;
        character.healthValue.text = classStats.HP.ToString() + "/" + character.maxHP.ToString();
    }

    public List<IAbility> AddDefaultSkills()
    {
        List<IAbility> allSkills = new List<IAbility>();

        //allSkills.Add(new DoubleStab());
        //allSkills.Add(new Cure());

        return allSkills;
    }

    public override void OnLevelUp()
    {
        LevelUp(25, 25, 5, 5, 2);

        character.healthValue.text = classStats.HP.ToString() + "/" + character.maxHP.ToString();
    }

    private void AddBaseResistances(Character character)
    {
        character.resistances.Add(new Holy());
    }

    private void AddBaseWeaknesses(Character character)
    {
        character.weaknesses.Add(new Shadow());
    }
}



