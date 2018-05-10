
using System.Collections.Generic;

/// <summary>
/// The base characteristics that every class must have
/// </summary>
public abstract class ClassType
{
    public List<Ability> skills = new List<Ability>();
    public Character character;
    public IStats classStats { get; set; }
    public string className { get; set; }

    public int experiencePoints { get; set; }
    public int skillPoints { get; set; }

    public ClassType(Character _character)
    {
        classStats = new ClassStats();

        character = _character;

        classStats.HP = character.characterStats.HP;
        classStats.MP = character.characterStats.MP;
        classStats.PhysAtk = character.characterStats.PhysAtk;
        classStats.MagAtk = character.characterStats.MagAtk;
        classStats.Speed = character.characterStats.Speed;

        character.maxHP = classStats.HP;
        character.healthValue.text = classStats.HP.ToString() + "/" + character.maxHP.ToString();
    }

    public void LevelUp(int hpGained, int mpGained, int physAtkGained, int magAtkGained, int speedGained)
    {
        classStats.HP += hpGained;
        classStats.MP = mpGained;
        classStats.PhysAtk = physAtkGained;
        classStats.MagAtk = magAtkGained;
        classStats.Speed = speedGained;

        character.maxHP = classStats.HP;
        character.healthValue.text = classStats.HP.ToString() + "/" + character.maxHP.ToString();

    }

    public void AddAbility(Ability newAbility)
    {
        newAbility.AddStatDamage(this);

        skills.Add(newAbility);
    }

    public void AddResistance(ElementBase newResistance)
    {
        character.resistances.Add(newResistance);
    }

    public void AddWeakness(ElementBase newWeakness)
    {
        character.weaknesses.Add(newWeakness);
    }

    public string GetClassName()
    {
        return className;
    }

    public virtual void OnLevelUp()
    {
        throw new System.NotImplementedException();
    }
}


