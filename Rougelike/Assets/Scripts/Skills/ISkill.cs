public interface ISkill
{
    string name { get; set; }
    int damage { get; set; }
    IModifiesDamage damageType { get; set; }
    IModifiesDamage element { get; set; }
    IModifiesDamage statusEffect { get; set; }

    void Cast(Character attacker, Character defender);
}


