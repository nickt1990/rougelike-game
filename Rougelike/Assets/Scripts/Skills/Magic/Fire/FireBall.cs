public class FireBall : SkillBase, ISkill
{
    public FireBall()
    {
        name = "Fireball";
        damage = 30;
        element = new Fire();
    }

    public override void Cast(Character attacker, Character defender)
    {
        int modifiedDamage = 0; //Damage that is modified based on the resistances and weaknesses of the defender

        Enemy target = defender as Enemy;

        modifiedDamage = CalculateDamage(attacker, defender, this);

        target.TakeDamage(modifiedDamage);
    }
}


