public interface IAbility
{
    string name { get; set; }
    int damage { get; set; }
    BaseDamageType damageType { get; set; }
    ElementBase element { get; set; }
    StatusEffect statusEffect { get; set; }

    void Cast(Character attacker, Character defender);
}


