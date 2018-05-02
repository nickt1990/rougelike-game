public interface ISkill
{
    string name { get; set; }
    int damage { get; set; }
    DamageType damageType { get; set; }
    Element element { get; set; }

    void Cast(Character attacker, Character defender);
}


