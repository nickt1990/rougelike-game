using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;	//Allows us to use UI.

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

    #region UI Stuff
        Button btnSkill1 = GameObject.Find("btnSkill1").GetComponent<Button>();
        Text txtSkill1 = GameObject.Find("txtSkill1").GetComponent<Text>();

        Button btnSkill2 = GameObject.Find("btnSkill2").GetComponent<Button>();
        Text txtSkill2 = GameObject.Find("txtSkill2").GetComponent<Text>();

        Button btnSkill3 = GameObject.Find("btnSkill3").GetComponent<Button>();
        Text txtSkill3 = GameObject.Find("txtSkill3").GetComponent<Text>();

        Button btnSkill4 = GameObject.Find("btnSkill4").GetComponent<Button>();
        Text txtSkill4 = GameObject.Find("txtSkill4").GetComponent<Text>();

    #endregion

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

    public void SetSkillsToButtons()
    {
        int i = 0;

        Button[] buttons = new Button[4] { btnSkill1, btnSkill2, btnSkill3, btnSkill4 };
        Text[] buttonTexts = new Text[4] { txtSkill1, txtSkill2, txtSkill3, txtSkill4 };


        foreach (Ability skill in skills)
        {
            buttons[i].GetComponent<Image>().color = Color.green;
            buttonTexts[i].text = (i + 1) + "." + skills[i].name;
            i++;
        }

        for (int j = i; j < buttons.Length; j++)
        {
            buttons[j].GetComponent<Image>().color = Color.grey;
            buttonTexts[j].text = "";
        }
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


