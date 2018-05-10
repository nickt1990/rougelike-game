public class Bubble : WaterSpell
{
    public Bubble()
    {
        name = "Bubble";
        damage = 30;
    }

    public override void Cast(Character attacker, Character defender)
    {
        base.Cast(attacker, defender);
    }

}


