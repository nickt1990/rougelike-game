using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Mage : BaseClass, IClassType
{
    public string className { get; set; }

    public List<ISkill> skills { get; set; }

    /// <summary>
    /// Sets the class name and adds skills to the class
    /// </summary>
    /// <param name="character"> The character that is becoming the mage class </param>
    public Mage(Character character) : base (character)
    {
        className = "Mage";

        ModifyStats();
        skills = AddDefaultSkills();
    }
    /// <summary>
    /// Modify all stats so that they are specific to a mage
    /// </summary>
    public void ModifyStats()
    {                                                                                               // Mage receives:

        character.HealthPoints = character.HP - (int)(character.HP * .5);                           // 50% less hp.
        character.MagicPoints = character.MP * 2;                                                   // 100% more mp.
        character.PhysicalAttack = character.PhysAtk - (int)(character.PhysAtk * .5);               // 50% less physical attack.
        character.MagicAttack = character.MagAtk * 2;                                               // 100% more magic attack.
        character.Speed = character.baseSpeed;                                                      // Speed remains unchanged.

        character.maxHP = character.HealthPoints;
        character.healthValue.text = character.HealthPoints.ToString() + "/" + character.maxHP.ToString();
    }

    public void OnLevelUp(Player player)
    {
        LevelUp(player, 10, 50, 2, 10, 3);

        player.healthValue.text = player.HealthPoints.ToString() + "/" + player.maxHP.ToString();
    }

    public List<ISkill> AddDefaultSkills()
    {
        List<ISkill> allSkills = new List<ISkill>();

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

