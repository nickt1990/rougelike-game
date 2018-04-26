using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IStatModifier
{ 


}

public class PaladinModifier : IStatModifier
{
    public PaladinModifier(Character character)
    {                                                                                               // Paladin receives:
        character.HealthPoints = character.HP + (int)(character.HP * .5);                           // 50% more hp.
        character.MagicPoints = character.MP + (int)(character.MP * .25);                           // 25% more mp.
        character.PhysicalAttack = character.PhysAtk + (int)(character.PhysAtk * .25);              // 25% more physical attack.
        character.MagicAttack = character.MagAtk + (int)(character.MagAtk * .25);                   // 25% more magic attack.
        character.Speed = character.baseSpeed - (int)(character.baseSpeed * .25);                   // 25% less speed.
    }
}

public class MageModifier : IStatModifier
{
    public MageModifier(Character character)
    {                                                                                               // Mage receives:
        character.HealthPoints = character.HP - (int)(character.HP * .5);                           // 50% less hp.
        character.MagicPoints = character.MP * 2;                                                   // 100% more mp.
        character.PhysicalAttack = character.PhysAtk + (int)(character.PhysAtk * .5);               // 50%  physical attack.
        character.MagicAttack = character.MagAtk * 2;                                               // 100% more magic attack.
        character.Speed = character.baseSpeed;                                                      // Speed remains unchanged.
    }
}


