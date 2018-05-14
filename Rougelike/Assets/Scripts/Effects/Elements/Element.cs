public class Element : Effect
{
    public StatusEffect statusEffect;
    public void HasStatusEffect(StatusEffect _statusEffect)
    {
        statusEffect = _statusEffect;
    }

}

public class Fire : Element
{
    public Fire()
    {
        
    }

    public Fire(StatusEffect _statusEffect)
    {
        statusEffect = _statusEffect;
    }    
}

public class Ice : Element
{
    public Ice()
    {
        
    }

    public Ice(StatusEffect _statusEffect)
    {
        statusEffect = _statusEffect;
    }

}

public class Water : Element
{
    
    public Water()
    {
        
    }

    public Water(StatusEffect _statusEffect)
    {
        statusEffect = _statusEffect;
    }

}

public class Holy : Element
{
    public Holy()
    {
    
    }

    public Holy(StatusEffect _statusEffect)
    {
        statusEffect = _statusEffect;
    }

}

public class Shadow : Element
{
    
    public Shadow()
    {
    
    }

    public Shadow(StatusEffect _statusEffect)
    {
        statusEffect = _statusEffect;
    }

}


