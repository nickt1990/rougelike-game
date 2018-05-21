/// <summary>
/// A shadow-based spell that hits in a circle around the caster
/// </summary>
public class ShadowBall : ShadowSpell
{
    public ShadowBall()
    {
        name = "Shadow Ball";
        damage = 30;
    }

    public override void Cast(Character attacker, Character defender)
    {
        base.Cast(attacker, defender);
    }

}


