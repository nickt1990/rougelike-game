enum StatusEffect
{
    None = 0,
    Heal = 1,
    Blind = 2,
    Burn = 3,
    Freeze = 4,
    Enhanced = 5
}

public class StatusEffectBase : BaseDamageModifier
{
    
}

public class Blind : StatusEffectBase
{

}

public class Burn : StatusEffectBase
{
    public Burn()
    {

    }
}

public class Heal : StatusEffectBase
{
    public Heal()
    {
        damageModifier = -1;
    }
    public Heal(int _damageModifier)
    {
        damageModifier = _damageModifier;
    }
}

