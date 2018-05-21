/// <summary>
/// An ice-based spell that hits every enemy in the area
/// </summary>
public class Blizzard : IceSpell
{
    public Blizzard()
    {
        name = "Blizzard";
        damage = 30;
    }

    public override void Cast(Character attacker, Character defender)
    {
        base.Cast(attacker, defender);
    }

}


