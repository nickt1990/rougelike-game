using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IClassType
{
    IStats classStats { get; set; }
    DamageCalculator damageCalculator { get; set; }
    string className { get; set; }
    int experiencePoints { get; set; }
    int skillPoints { get; set; }
    string GetClassName();

    void OnLevelUp();
}
