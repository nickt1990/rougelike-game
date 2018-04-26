using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public interface ISkillTree
{
    IEnumerable<ISkill> skills { get; set; }
}

public class PaladinSkillTree : ISkillTree
{
    public IEnumerable<ISkill> skills { get; set; }

    public PaladinSkillTree()
    {
        //skills.Add(new DoubleStab());
        //skills.Add(new Heal());
    }
    

}



