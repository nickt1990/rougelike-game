using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Paladin : ClassBase
{
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

        ModifyStats();
        skills = AddDefaultSkills();

    }

    public void ModifyStats()
    {
        character.HealthPoints = character.HP + (int)(character.HP * .5);                           // 50% more hp.
        character.MagicPoints = character.MP + (int)(character.MP * .25);                           // 25% more mp.
        character.PhysicalAttack = character.PhysAtk + (int)(character.PhysAtk * .25);              // 25% more physical attack.
        character.MagicAttack = character.MagAtk + (int)(character.MagAtk * .25);                   // 25% more magic attack.
        character.Speed = character.baseSpeed - (int)(character.baseSpeed * .25);                   // 25% less speed.

        character.maxHP = character.HealthPoints;
        character.healthValue.text = character.HealthPoints.ToString() + "/" + character.maxHP.ToString();
    }

    public List<ISkill> AddDefaultSkills()
    {
        List<ISkill> allSkills = new List<ISkill>();

        allSkills.Add(new DoubleStab());
        allSkills.Add(new Heal());

        return allSkills;
    }

    public override void OnLevelUp(Player player)
    {
        LevelUp(player, 25, 25, 5, 5, 2);

        player.healthValue.text = player.HealthPoints.ToString() + "/" + player.maxHP.ToString();
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



