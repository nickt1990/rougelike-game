
/// <summary>
/// This class is here simply to ensure that all characters stats get instantiated correctly.
/// All classes will go through this class at one point or another.
/// </summary>
public class BaseModifier
{
    public BaseModifier(Character character)
    {
        character.HealthPoints = character.HP;
        character.MagicPoints = character.MP;
        character.PhysicalAttack = character.PhysAtk;
        character.MagicAttack = character.MagAtk;
        character.Speed = character.baseSpeed;

        character.maxHP = character.HealthPoints;
        character.healthValue.text = character.HealthPoints.ToString() + "/" + character.maxHP.ToString();
    }
}


