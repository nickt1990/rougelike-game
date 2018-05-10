using System;
using System.Collections.Generic;

/// <summary>
/// This class will set the default stats to the character.
/// All characters start with no class, so all characters will go through the constructor of this class upon their instantiation.
/// </summary>
public class NoClass : ClassType
{

    public NoClass(Character character) : base(character)
    {
        className = "No Class";
    }

    public override void OnLevelUp()
    {
        LevelUp(15, 15, 5, 5, 5);

        character.healthValue.text = classStats.HP.ToString() + "/" + character.maxHP.ToString();
    }
}
