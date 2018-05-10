using UnityEngine;

public class CharacterStats : IStats
{
    private int _maxHP;

    // Used as a base for the class to go off of, and also used if character has no class
    private int BaseHealthPoints = 100;
    public int HP
    {
        get
        {
            return BaseHealthPoints;
        }
        set
        {
            BaseHealthPoints = value;
        }
    }

    private int BaseMagicPoints = 100;
    public int MP
    {
        get
        {
            return BaseMagicPoints;
        }
        set
        {
            BaseMagicPoints = value;
        }
    }

    private int BasePhysicalAttack = 10;
    public int PhysAtk
    {
        get
        {
            return BasePhysicalAttack;
        }
        set
        {
            BasePhysicalAttack = value;
        }
    }

    private int BaseMagicAttack = 10;
    public int MagAtk
    {
        get
        {
            return BaseMagicAttack;
        }
        set
        {
            BaseMagicAttack = value;
        }
    }

    private int BaseSpeed = 10;
    public int Speed
    {
        get
        {
            return BaseSpeed;
        }
        set
        {
            BaseSpeed = value;
        }
    }
}