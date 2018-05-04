using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IClassType
{
    string className { get; set; }
    int experiencePoints { get; set; }
    int skillPoints { get; set; }

    List<ISkill> skills { get; set; }   
    string GetClassName();
    void OnLevelUp(Player player);
}
