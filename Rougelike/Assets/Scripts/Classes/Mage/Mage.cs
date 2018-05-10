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
    }

    /// <summary>
    /// Modify all stats so that they are specific to a mage
    /// </summary>
    public void ModifyStats()
    {                                                                               // Mage receives:
        classStats.HP = classStats.HP - (int)(classStats.HP * .5);                  // 50% less hp.
        classStats.MP = classStats.MP * 2;                                          // 100% more mp.
        classStats.PhysAtk = classStats.PhysAtk - (int)(classStats.PhysAtk * .5);   // 50% less physical attack.
        classStats.MagAtk = classStats.MagAtk * 2;                                  // 100% more magic attack.
        classStats.Speed = classStats.Speed;                                        // Speed remains unchanged.

        character.maxHP = classStats.HP;
        character.healthValue.text = classStats.HP.ToString() + "/" + character.maxHP.ToString();
    }

    public override void OnLevelUp()
    {
        LevelUp(10, 50, 2, 10, 3);

        character.healthValue.text = classStats.HP.ToString() + "/" + character.maxHP.ToString();
    }

    private void AddBaseResistances(Character character)
    {
        character.resistances.Add(new Fire());
        character.resistances.Add(new Water());
        character.resistances.Add(new Ice());
    }

    private void AddBaseWeaknesses(Character character)
    {

    }
}

