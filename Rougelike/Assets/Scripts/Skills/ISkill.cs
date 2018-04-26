using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface ISkill
{
    string name { get; set; }
    int damage { get; set; }
    Element element { get; set; }

    void Execute();
}

public class DoubleStab : ISkill
{
    public string name {get; set;}
    public int damage { get; set; }

    public Element element { get; set; }

    public void Execute()
    {
        throw new NotImplementedException();
    }
}

public class FireBall : ISkill
{
    public string name { get; set; }
    public int damage { get; set; }
    public Element element { get; set; }

    public void Execute()
    {
        throw new NotImplementedException();
    }
}
public class Heal : ISkill
{
    public string name { get; set; }
    public int damage { get; set; }
    public Element element { get; set; }
    public void Execute()
    {
        throw new NotImplementedException();
    }
}

