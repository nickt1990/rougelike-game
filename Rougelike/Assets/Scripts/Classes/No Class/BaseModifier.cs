
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

    public void LevelUp(Player player, int hpGained, int mpGained, int physAtkGained, int magAtkGained, int speedGained)
    {
        player.maxHP += hpGained;
        player.HealthPoints = player.maxHP;
        player.MagicPoints += mpGained;
        player.PhysicalAttack += physAtkGained;
        player.MagicAttack += magAtkGained;
        player.Speed += speedGained;

        player.healthValue.text = player.HealthPoints.ToString() + "/" + player.maxHP.ToString();
    }
}


