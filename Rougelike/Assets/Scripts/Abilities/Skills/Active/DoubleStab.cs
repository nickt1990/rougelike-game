/// <summary>
/// Skill that will perform a physical attack twice
/// </summary>
public class DoubleStab : Skill
{

    public DoubleStab() : base()
    {
        name = "Double Stab";
    }

    /// <summary>
    /// The specific rules that are attached to this ability when it gets cast
    /// </summary>
    /// <param name="attacker"> The character casting the ability </param>
    /// <param name="defender"> The character being hit by the ability </param>
    public void Cast(Character attacker, Character defender)
    {
        // Double Stab performs a normal physical attack, twice
        attacker.PerformPhysicalAttack(defender);
        attacker.PerformPhysicalAttack(defender);
    }
}


