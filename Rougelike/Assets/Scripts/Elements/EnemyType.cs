using System.Collections.Generic;
public enum EnemyType
{
    None = 0,
    Undead = 1
}

public interface IEnemyType
{
    List<Element> Strengths { get; set; }
    List<Element> Weaknesses { get; set; }
}

public class Undead : IEnemyType
{
    private List<Element> strengths = new List<Element>();
    public List<Element> Strengths
    {
        get
        {
            return strengths;
        }
        set
        {
            strengths = new List<Element>();
        }
    }

    private List<Element> weaknesses = new List<Element>();
    public List<Element> Weaknesses
    {
        get
        {
            return weaknesses;
        }
        set
        {
            weaknesses = new List<Element>();
        }
    }

    public Undead()
    {
        AddWeaknesses();
    }

    public void AddWeaknesses()
    {
        weaknesses.Add(Element.Holy);
    }

}

