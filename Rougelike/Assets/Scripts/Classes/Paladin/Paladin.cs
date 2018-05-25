using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Paladin : ClassType
{
    Character thisCharacter;

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

        thisCharacter = character;

        ModifyStats();

        // Add Default abilities
        AddAbility(new DoubleStab());
        AddAbility(new Cure());

        AddResistance(new Holy());
        AddWeakness(new Shadow());

        SetSkillsToButtons();
    }

    /// <summary>
    /// Modify the character stats to fit into the class stats
    /// </summary>
    public void ModifyStats()
    {                                                               // Paladin recieves:
        classStats.HP = (int)(thisCharacter.characterStats.HP * .5);                 // 50% more hp.
        classStats.MP = (int)(thisCharacter.characterStats.MP * .25);                // 25% more mp.
        classStats.PhysAtk = (int)(thisCharacter.characterStats.PhysAtk * .25);      // 25% more physical attack.
        classStats.MagAtk = (int)(thisCharacter.characterStats.MagAtk * .25);        // 25% more magic attack.
        classStats.Speed = (int)(thisCharacter.characterStats.Speed * .25);          // 25% less speed.

        character.maxHP = classStats.HP;
        character.healthValue.text = classStats.HP.ToString() + "/" + character.maxHP.ToString();
    }

    /// <summary>
    /// Handles everything that occurs when a Paladin levels up
    /// </summary>
    public override void OnLevelUp()
    {
        LevelUp(25, 25, 5, 5, 2);

        character.healthValue.text = classStats.HP.ToString() + "/" + character.maxHP.ToString();
    }
}



