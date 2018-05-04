public class Heal : SkillBase
{
    public Heal()
    {
        name = "Heal";
        damage = 30;
        element = new Holy();
    }

    public override void Cast(Character attacker, Character defender)
    {
        Enemy target = defender as Enemy;

        damageType = new MagicDamageType(attacker.MagicAttack);

        int modifiedDamage = 0; //Damage that will be modified based on the resistances and weaknesses of the defender

        modifiedDamage += damageType.damage;

        modifiedDamage += CalculateDamage(attacker, defender, this);


        target.TakeDamage(modifiedDamage);
    }
}


