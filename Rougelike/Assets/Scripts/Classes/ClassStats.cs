using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// These stats use the Character Stats and modify them to fit into the specific class
/// </summary>
public class ClassStats : IStats
{
    public int modifiedHealthPoints;
    public int HP
    {
        get
        {
            return modifiedHealthPoints;
        }
        set
        {
            modifiedHealthPoints = value;
        }
    }

    public int modifiedMagicPoints;
    public int MP
    {
        get
        {
            return modifiedMagicPoints;
        }
        set
        {
            modifiedMagicPoints = value;
        }
    }

    public int modifiedPhysicalAttack;
    public int PhysAtk
    {
        get
        {
            return modifiedPhysicalAttack;
        }
        set
        {
            modifiedPhysicalAttack = value;
        }
    }

    public int modifiedMagicAttack;
    public int MagAtk
    {
        get
        {
            return modifiedMagicAttack;
        }
        set
        {
            modifiedMagicAttack = value;
        }
    }

    public int modifiedSpeed;
    public int Speed
    {
        get
        {
            return modifiedSpeed;
        }
        set
        {
            modifiedSpeed = value;
        }
    }
}

