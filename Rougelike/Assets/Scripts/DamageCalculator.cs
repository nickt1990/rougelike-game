using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DamageCalculator
{
    public void CalculateDamage(Character attacking, Character defending)
    {
        if (attacking.GetType() == typeof(Player))
        {
            attacking = (Player)attacking;
            defending = (Enemy)defending;
        }
        else
        {
            attacking = (Enemy)attacking;
            defending = (Player)defending;
        }
    }
}

