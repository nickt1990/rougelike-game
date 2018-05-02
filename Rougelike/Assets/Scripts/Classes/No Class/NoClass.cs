using System;
using System.Collections.Generic;

/// <summary>
/// This class will set the default stats to the character.
/// All characters start with no class, so all characters will go through the constructor of this class upon their instantiation.
/// </summary>
public class NoClass : BaseModifier, IClassType
{
    public List<ISkill> skills { get; set; }
    public string className { get; set; }

    public NoClass(Character character) : base(character)
    {
        className = "No Class";
    }
    public string GetClassName()
    {
        return className;
    }

    public void OnLevelUp(Player player)
    {
        LevelUp(player, 15, 15, 5, 5, 5);

        player.healthValue.text = player.HealthPoints.ToString() + "/" + player.maxHP.ToString();
    }
}
