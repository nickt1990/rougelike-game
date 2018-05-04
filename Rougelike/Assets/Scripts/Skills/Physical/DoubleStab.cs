using System;
public class DoubleStab : SkillBase
{

    public DoubleStab()
    {
        name = "Double Stab";
    }

    public override void Cast(Character attacker, Character defender)
    {
        // Double Stab performs a normal physical attack, twice
        attacker.PerformPhysicalAttack(defender);
        attacker.PerformPhysicalAttack(defender);
    }
}


