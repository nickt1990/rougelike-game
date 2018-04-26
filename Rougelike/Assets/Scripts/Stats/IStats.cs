using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStats
{
    int HP { get; set; }            // The amount of health that an entity will have
    int MP { get; set; }                    /* The amount of MP that an entity will have.  NOTE: WE MAY TAKE THIS OUT:
                                           WE ARE CURRENTLY THINKING THAT MAYBE STACKING WITH THE BATTLE BAR COULD REPLACE MP.  */
    int PhysAtk { get; set; }       // The amount of physical damage a character does with a physical attack
    int MagAtk { get; set; }        // The amount of magic damage a character does with a magic attack
    int baseSpeed{get; set;}            // How fast the battle bar moves.  The more speed, the slower it moves

    void OnDeath();

}
