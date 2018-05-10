using System;
public class DoubleStab : Skill
{

    public DoubleStab() : base()
    {
        name = "Double Stab";
    }

    public void Cast(Character attacker, Character defender)
    {
        // Double Stab performs a normal physical attack, twice
        attacker.PerformPhysicalAttack(defender);
        attacker.PerformPhysicalAttack(defender);
    }
}


