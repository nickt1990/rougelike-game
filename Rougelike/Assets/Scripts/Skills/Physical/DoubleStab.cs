using System;
public class DoubleStab : SkillBase, ISkill
{
    public string name { get; set; }
    public int damage { get; set; }

    public Element element { get; set; }
    public DamageType damageType { get; set; }

    public DoubleStab()
    {
        name = "Double Stab";
        damageType = DamageType.Physical;
    }

    public void Cast(Character attacker, Character defender)
    {
        // Double Stab performs a normal physical attack, twice
        attacker.PerformPhysicalAttack(defender);
        attacker.PerformPhysicalAttack(defender);
    }
}


