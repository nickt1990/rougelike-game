/// <summary>
/// A Fire spell that hits a single target, dealing a lot of damage
/// </summary>
public class FireBall : FireSpell
{
    public FireBall()
    {
        name = "Fireball";
        damage = 30;
    }

    public override void Cast(Character attacker, Character defender)
    {
        base.Cast(attacker, defender);
    }

}


