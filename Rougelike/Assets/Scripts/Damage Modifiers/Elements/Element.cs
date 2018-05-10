public class ElementBase : BaseDamageModifier
{
    public StatusEffect statusEffect;
    public void HasStatusEffect(StatusEffect _statusEffect)
    {
        statusEffect = _statusEffect;
    }

}

public class Fire : ElementBase
{
    public Fire()
    {
        
    }

    public Fire(StatusEffect _statusEffect)
    {
        statusEffect = _statusEffect;
    }    
}

public class Ice : ElementBase
{
    public Ice()
    {
        
    }

    public Ice(StatusEffect _statusEffect)
    {
        statusEffect = _statusEffect;
    }

}

public class Water : ElementBase
{
    
    public Water()
    {
        
    }

    public Water(StatusEffect _statusEffect)
    {
        statusEffect = _statusEffect;
    }

}

public class Holy : ElementBase
{
    public Holy()
    {
    
    }

    public Holy(StatusEffect _statusEffect)
    {
        statusEffect = _statusEffect;
    }

}

public class Shadow : ElementBase
{
    
    public Shadow()
    {
    
    }

    public Shadow(StatusEffect _statusEffect)
    {
        statusEffect = _statusEffect;
    }

}


