using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IClassType
{
    IStatModifier statModifier { get; set; }
    string className { get; set; }
    string GetClassName();
    void Strength();
    void Weakness();

}
