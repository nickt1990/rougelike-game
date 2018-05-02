public class Heal : SkillBase, ISkill
{
    public string name { get; set; }
    public int damage { get; set; }

    public Element element { get; set; }

    public DamageType damageType { get; set; }

    public Heal()
    {
        name = "Heal";
        damage = 30;
        damageType = DamageType.Magic;
        element = Element.Holy;
    }

    public void Cast(Character attacker, Character defender)
    {
        int modifiedDamage = 0; //Damage that is modified based on the resistances and weaknesses of the defender
        
        modifiedDamage = CalculateDamage(attacker, defender, this);

        defender.TakeDamage(modifiedDamage);
    }
}


