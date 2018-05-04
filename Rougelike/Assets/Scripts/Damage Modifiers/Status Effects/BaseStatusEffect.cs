using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

enum StatusEffect
{
    None = 0,
    Blind = 1,
    Hungry = 2,
    Enhanced = 3
}

public class BaseStatusEffect : BaseDamageModifier
{

}

public class Blind : BaseStatusEffect
{

}

