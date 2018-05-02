using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//public enum ExperienceTable
//{
//    Level_1 = 10,
//    Level_2 = 20,
//    Level_3 = 40
//};

public class ExperienceTable
{
    public Dictionary<int, int> CreateExperienceTable()
    {
        Dictionary<int, int> experienceTable = new Dictionary<int, int>();

        experienceTable.Add(1, 10);
        experienceTable.Add(2, 20);
        experienceTable.Add(3, 40);
        experienceTable.Add(4, 100);
        experienceTable.Add(5, 200);

        return experienceTable;

    }
    

   

}


