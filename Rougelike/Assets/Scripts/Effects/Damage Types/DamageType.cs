using System.Collections.Generic;

public enum DamageType
{
    None = 0,
    Physical = 1,
    Magic = 2
}

public class BaseDamageType : Effect
{

}

public class PhysicalDamageType : BaseDamageType
{
    public PhysicalDamageType()
    {
        
    }
}

public class MagicDamageType : BaseDamageType
{
    public MagicDamageType()
    {
        
    }
}

