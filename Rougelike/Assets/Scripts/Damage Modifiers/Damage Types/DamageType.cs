using System.Collections.Generic;

public enum DamageType
{
    None = 0,
    Physical = 1,
    Magic = 2
}

public class BaseDamageType : BaseDamageModifier
{
    
}

public class PhysicalDamageType : BaseDamageType
{

    public PhysicalDamageType(int statDamage)
    {
        damage += statDamage;
    }
}

public class MagicDamageType : BaseDamageType
{
    public MagicDamageType(int statDamage)
    {
        damage += statDamage;
    }
}

