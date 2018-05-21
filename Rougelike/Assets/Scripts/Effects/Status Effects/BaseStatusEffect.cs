public class StatusEffect : Effect
{
    
}

public class Blind : StatusEffect
{

}

public class Burn : StatusEffect
{
    public Burn()
    {

    }
}

public class Heal : StatusEffect
{
    public Heal()
    {
        damageModifier = -1;
    }
}

