public class MageModifier : BaseModifier, IStatModifier
{
    public MageModifier(Character character) : base (character)
    {                                                                                               // Mage receives:

        character.HealthPoints = character.HP - (int)(character.HP * .5);                           // 50% less hp.
        character.MagicPoints = character.MP * 2;                                                   // 100% more mp.
        character.PhysicalAttack = character.PhysAtk - (int)(character.PhysAtk * .5);               // 50% less physical attack.
        character.MagicAttack = character.MagAtk * 2;                                               // 100% more magic attack.
        character.Speed = character.baseSpeed;                                                      // Speed remains unchanged.

        character.maxHP = character.HealthPoints;
        character.healthValue.text = character.HealthPoints.ToString() + "/" + character.maxHP.ToString();
    }

    public void OnLevelUp(Player player)
    {
        LevelUp(player, 10, 50, 2, 10, 3);

        player.healthValue.text = player.HealthPoints.ToString() + "/" + player.maxHP.ToString();
    }

}


