public enum element
{
    None = 0,
    Fire = 1,
    Ice = 2,
    Water = 3,
    Holy = 4,
    Shadow = 5

};

public class Element : BaseDamageModifier
{



}

public class Fire : Element
{
    public element elementType;
    public Fire()
    {
        elementType = element.Fire;
    }
    
}

public class Ice : Element
{
    public element elementType;
    public Ice()
    {
        elementType = element.Ice;
    }

}

public class Water : Element
{
    public element elementType;
    public Water()
    {
        elementType = element.Fire;
    }

}

public class Holy : Element
{
    public element elementType;
    public Holy()
    {
        elementType = element.Holy;
    }

}

public class Shadow : Element
{
    public element elementType;
    public Shadow()
    {
        elementType = element.Fire;
    }

}


