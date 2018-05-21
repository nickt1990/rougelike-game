public abstract class Effect
{
    private int _damageModifier;
    public int damageModifier
    {
        get
        {
            return _damageModifier;
        }
        set
        {
            _damageModifier = value;
        }
    }

    public int damage { get; set; }

    public void SetDamageModifier(int damageMultipliedBy)
    {
        damageModifier = damageMultipliedBy;
    }
}

