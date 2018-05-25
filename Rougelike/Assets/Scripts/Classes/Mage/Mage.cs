using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Mage : ClassType
{
    Character thisCharacter;
    /// <summary>
    /// Sets the class name and adds skills to the class
    /// </summary>
    /// <param name="character"> The character that is becoming the mage class </param>
    public Mage(Character character) : base (character)
    {
        className = "Mage";

        thisCharacter = character;

        ModifyStats();

        AddAbility(new FireBall());
        AddAbility(new Blizzard());
        AddAbility(new Bubble());

        SetSkillsToButtons();

        AddResistance(new Fire());
        AddResistance(new Water());
        AddResistance(new Ice());
    }

    /// <summary>
    /// Modify all stats so that they are specific to a mage
    /// </summary>
    public void ModifyStats()
    {                                                           // Mage receives:
        classStats.HP = (int)(thisCharacter.characterStats.HP * -.5);            // 50% less hp.
        classStats.MP = thisCharacter.characterStats.MP;                         // 100% more mp.
        classStats.PhysAtk = (int)(thisCharacter.characterStats.PhysAtk * .5);   // 50% less physical attack.
        classStats.MagAtk = thisCharacter.characterStats.MagAtk;                 // 100% more magic attack.
        classStats.Speed = thisCharacter.characterStats.Speed;                                  // Speed remains unchanged.

        character.maxHP = classStats.HP;
        character.healthValue.text = classStats.HP.ToString() + "/" + character.maxHP.ToString();
    }

    /// <summary>
    /// What happens when a Mage levels up
    /// </summary>
    public override void OnLevelUp()
    {
        LevelUp(10, 50, 2, 10, 3);

        character.healthValue.text = classStats.HP.ToString() + "/" + character.maxHP.ToString();
    }
}

