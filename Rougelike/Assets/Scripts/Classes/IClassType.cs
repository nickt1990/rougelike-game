using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum ClassType
{
    NoClass = 0,
    Paladin = 1,
    Mage = 2
}

public interface IClassType
{
    List<ISkill> skills { get; set; }   
    string className { get; set; }
    string GetClassName();
    void OnLevelUp(Player player);
}
