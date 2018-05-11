using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Mage : ClassType
{

    /// <summary>
    /// Sets the class name and adds skills to the class
    /// </summary>
    /// <param name="character"> The character that is becoming the mage class </param>
    public Mage(Character character) : base (character)
    {
        className = "Mage";

        ModifyStats();
        AddAbility(new FireBall());
        AddAbility(new Blizzard());
        AddAbility(new Bubble());

        SetSkillsToButtons();

        AddBaseResistances();
        AddBaseWeaknesses();
    }

    /// <summary>
    /// Modify all stats so that they are specific to a mage
    /// </summary>
    public void ModifyStats()
    {                                                           // Mage receives:
        classStats.HP += (int)(classStats.HP * -.5);            // 50% less hp.
        classStats.MP += classStats.MP;                         // 100% more mp.
        classStats.PhysAtk += (int)(classStats.PhysAtk * .5);   // 50% less physical attack.
        classStats.MagAtk += classStats.MagAtk;                 // 100% more magic attack.
        classStats.Speed += 0;                                  // Speed remains unchanged.

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

    /// <summary>
    /// Add base resistances for a Mage
    /// </summary>
    /// <param name="character"></param>
    private void AddBaseResistances()
    {
        character.resistances.Add(new Fire());
        character.resistances.Add(new Water());
        character.resistances.Add(new Ice());
    }

    /// <summary>
    /// Add a weakness for a Mage
    /// </summary>
    /// <param name="character"></param>
    private void AddBaseWeaknesses()
    {

    }
}

