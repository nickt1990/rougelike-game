public class PaladinModifier : BaseModifier, IStatModifier
{
    public PaladinModifier(Character character) : base(character)
    {              
                                                                                                    // Paladin receives:
        character.HealthPoints = character.HP + (int)(character.HP * .5);                           // 50% more hp.
        character.MagicPoints = character.MP + (int)(character.MP * .25);                           // 25% more mp.
        character.PhysicalAttack = character.PhysAtk + (int)(character.PhysAtk * .25);              // 25% more physical attack.
        character.MagicAttack = character.MagAtk + (int)(character.MagAtk * .25);                   // 25% more magic attack.
        character.Speed = character.baseSpeed - (int)(character.baseSpeed * .25);                   // 25% less speed.

        character.maxHP = character.HealthPoints;
        character.healthValue.text = character.HealthPoints.ToString() + "/" + character.maxHP.ToString();
    }
}


