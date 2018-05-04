
/// <summary>
/// This class is here simply to ensure that all characters stats get instantiated correctly.
/// All classes will go through this class at one point or another.
/// </summary>
public class BaseClass
{
    public Character character;

    public int experiencePoints;
    public int skillPoints;

    public BaseClass(Character _character)
    {
        character = _character;

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

    public void AddResistance(Element newResistance)
    {
        character.resistances.Add(newResistance);
    }

    public void AddWeakness(Element newWeakness)
    {
        character.weaknesses.Add(newWeakness);
    }
}


