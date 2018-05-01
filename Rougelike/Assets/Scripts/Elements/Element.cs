using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Element
{
    None = 0,
    Fire = 1,
    Ice = 2,
    Water = 3,
    Holy = 4
};

public interface IElement
{
    List<Element> Strengths { get; set; }
    List<Element> Weaknesses { get; set; }
}

public class Fire : IElement
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

    public Fire()
    {
        AddStrengths();
        AddWeaknesses();
    }

    public void AddStrengths()
    {
        strengths.Add(Element.Ice);
    }

    public void AddWeaknesses()
    {
        weaknesses.Add(Element.Water);
    }
}

public class Holy : IElement
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

    public Holy()
    {

    }
}
