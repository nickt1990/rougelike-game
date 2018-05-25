using System.Collections.Generic;
using UnityEngine;
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

        Button btnSkill1;
        Text txtSkill1; 

        Button btnSkill2;
        Text txtSkill2;

        Button btnSkill3;
        Text txtSkill3;

        Button btnSkill4;
        Text txtSkill4;

    #endregion

    /// <summary>
    /// Constructor that all classes should inherit from - Sets up default properties that each and every class must have
    /// </summary>
    /// <param name="_character"></param>
    public ClassType(Character _character)
    {
        classStats = new Stats();

        character = _character;

        classStats.HP = character.characterStats.HP;
        classStats.MP = character.characterStats.MP;
        classStats.PhysAtk = character.characterStats.PhysAtk;
        classStats.MagAtk = character.characterStats.MagAtk;
        classStats.Speed = character.characterStats.Speed;

        character.maxHP = classStats.HP;
        character.healthValue.text = classStats.HP.ToString() + "/" + character.maxHP.ToString();
    }

    /// <summary>
    /// Returns the name of the class
    /// </summary>
    /// <returns></returns>
    public string GetClassName()
    {
        return className;
    }

    /// <summary>
    /// Called when a class levels up, and increments stats properly
    /// </summary>
    /// <param name="hpGained"> How much HP will be gained on level up </param>
    /// <param name="mpGained"> How much MP will be gained on level up </param>
    /// <param name="physAtkGained"> How much physical attack will be gained on level up </param>
    /// <param name="magAtkGained"> How much magic attack will be gained on level up </param>
    /// <param name="speedGained"> How much speed will be gained on level up </param>
    public void LevelUp(int hpGained, int mpGained, int physAtkGained, int magAtkGained, int speedGained)
    {
        classStats.HP += hpGained;
        classStats.MP += mpGained;
        classStats.PhysAtk += physAtkGained;
        classStats.MagAtk += magAtkGained;
        classStats.Speed += speedGained;

        character.maxHP = classStats.HP;

        character.healthValue.text = classStats.HP.ToString() + "/" + character.maxHP.ToString();

    }

    /// <summary>
    /// Add and ability to the class
    /// </summary>
    /// <param name="newAbility"></param>
    public void AddAbility(Ability newAbility)
    {
        newAbility.AddStatDamage(this);

        skills.Add(newAbility);
    }

    /// <summary>
    /// Put the skill names on the correct buttons for the character
    /// </summary>
    public void SetSkillsToButtons()
    {
        int i = 0;

        btnSkill1 = GameObject.Find("btnSkill1_Player1").GetComponent<Button>();
        txtSkill1 = GameObject.Find("txtSkill1_Player1").GetComponent<Text>();


        btnSkill2 = GameObject.Find("btnSkill2_Player1").GetComponent<Button>();
        txtSkill2 = GameObject.Find("txtSkill2_Player1").GetComponent<Text>();


        btnSkill3 = GameObject.Find("btnSkill3_Player1").GetComponent<Button>();
        txtSkill3 = GameObject.Find("txtSkill3_Player1").GetComponent<Text>();


        btnSkill4 = GameObject.Find("btnSkill4_Player1").GetComponent<Button>();
        txtSkill4 = GameObject.Find("txtSkill4_Player1").GetComponent<Text>();

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
    /// <summary>
    /// Determine what the player number is, and set the skill buttons accordingly
    /// </summary>
    private void DeterminePlayerButtons()
    {
        int playerNumber = 0;

        Player player = character as Player;
        playerNumber = player.playerNumber;

        if (playerNumber == 1)
        {
            btnSkill1 = GameObject.Find("btnSkill1_Player1").GetComponent<Button>();
            txtSkill1 = GameObject.Find("txtSkill1_Player1").GetComponent<Text>();


            btnSkill2 = GameObject.Find("btnSkill2_Player1").GetComponent<Button>();
            txtSkill1 = GameObject.Find("txtSkill2_Player1").GetComponent<Text>();


            btnSkill3 = GameObject.Find("btnSkill3_Player1").GetComponent<Button>();
            txtSkill1 = GameObject.Find("txtSkill3_Player1").GetComponent<Text>();


            btnSkill4 = GameObject.Find("btnSkill4_Player1").GetComponent<Button>();
            txtSkill1 = GameObject.Find("txtSkill4_Player1").GetComponent<Text>();
        }
        //else if (playerNumber == 2)
        //{
        //    btnSkill1 = GameObject.Find("btnSkill1_Player2").GetComponent<Button>();
        //    txtSkill1 = GameObject.Find("txtSkill1_Player2").GetComponent<Text>();

        //    btnSkill2 = GameObject.Find("btnSkill2_Player2").GetComponent<Button>();
        //    txtSkill1 = GameObject.Find("txtSkill2_Player2").GetComponent<Text>();

        //    btnSkill3 = GameObject.Find("btnSkill3_Player2").GetComponent<Button>();
        //    txtSkill1 = GameObject.Find("txtSkill3_Player2").GetComponent<Text>();

        //    btnSkill4 = GameObject.Find("btnSkill4_Player2").GetComponent<Button>();
        //    txtSkill1 = GameObject.Find("txtSkill4_Player2").GetComponent<Text>();
        //}
    }

    /// <summary>
    /// Add a resistance to a class
    /// A resistance is an element that will deal half damage
    /// </summary>
    /// <param name="newResistance"> The element that the class is resistant to </param>
    public void AddResistance(Element newResistance)
    {
        character.resistances.Add(newResistance);
    }

    /// <summary>
    /// Add a weakness to a class
    /// A weakness is an element that will deal double damage
    /// </summary>
    /// <param name="newWeakness"> The element that will deal 2x damage to this class </param>
    public void AddWeakness(Element newWeakness)
    {
        character.weaknesses.Add(newWeakness);
    }

    /// <summary>
    /// Add an immunity to a class
    /// An immunity is an element that will deal no damage to this class
    /// </summary>
    /// <param name="newImmunity"> The element that will deal no damage to this class</param>
    public void AddImmunity(Element newImmunity)
    {
        character.immunities.Add(newImmunity);
    }

    /// <summary>
    /// Add advantage to a class
    /// An advantage is an element that will heal this class instead of harm it
    /// </summary>
    /// <param name="newAdvantage"> The element that will heal this class </param>
    public void AddAdvantage(Element newAdvantage)
    {
        character.advantages.Add(newAdvantage);
    }

    /// <summary>
    /// Whenever a class levels up, this will happen
    /// </summary>
    public virtual void OnLevelUp()
    {
        throw new System.NotImplementedException();
    }
}


