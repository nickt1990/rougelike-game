public interface IAbility
{
    string name { get; set; }
    int damage { get; set; }
    BaseDamageType damageType { get; set; }
    Element element { get; set; }
    StatusEffect statusEffect { get; set; }

    void Cast(Character attacker, Character defender);
}


