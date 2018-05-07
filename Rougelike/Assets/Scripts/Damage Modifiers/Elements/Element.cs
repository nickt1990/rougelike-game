public class ElementBase : BaseDamageModifier
{
    public StatusEffectBase statusEffect;
    public void HasStatusEffect(StatusEffectBase _statusEffect)
    {
        statusEffect = _statusEffect;
    }

}

public class Fire : ElementBase
{
    public Fire()
    {
        
    }

    public Fire(StatusEffectBase _statusEffect)
    {
        statusEffect = _statusEffect;
    }    
}

public class Ice : ElementBase
{
    public Ice()
    {
        
    }

    public Ice(StatusEffectBase _statusEffect)
    {
        statusEffect = _statusEffect;
    }

}

public class Water : ElementBase
{
    
    public Water()
    {
        
    }

}

public class Holy : ElementBase
{
    public Holy()
    {
    
    }

    public Holy(StatusEffectBase _statusEffect)
    {
        statusEffect = _statusEffect;
    }

}

public class Shadow : ElementBase
{
    
    public Shadow()
    {
    
    }

}


