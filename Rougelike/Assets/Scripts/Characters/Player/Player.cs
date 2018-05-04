using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;
using System;


public class Player : Character, IAttack
{
    [Header("Experience Bar")]
    public Image expBar;
    public int playerLevel;

    [Header("Skill Buttons")]
    public Button btnSkill1;
    private Text txtSkill1;

    public Button btnSkill2;
    private Text txtSkill2;

    public Button btnSkill3;
    private Text txtSkill3;

    public Button btnSkill4;
    private Text txtSkill4;

    [Header("Unity Junk")]
    public int playerNumber;
    public float restartLevelDelay = 1f;        //Delay time in seconds to restart level.

    public static Player player;

    public Canvas playerUI;

    
    private int experience;
    private int experienceRequiredToLevel;

    private Dictionary<int, int> experienceTable;

    public IExecutable executable;

    void Awake()
    {
        
    }

    public override void Start()
    {
        //------------- Singleton Design Pattern to ensure there is only ever one of each player (1-4) --------------
        if(player == null)
        {
            DontDestroyOnLoad(gameObject);
            player = this;  // Create Player 1
        }
        else if (playerNumber == 2 || playerNumber == 3 || playerNumber == 4)   // By default the player number == 1 unless we manually change it. Therefore we will only enter this if we have manually changed it.
        {
            DontDestroyOnLoad(gameObject);
            player = this;  // Create player 2, 3, or 4, depending on the player number
        }
        else if (player != this)    // Otherwise, we destroy the gameobject so that only 1 player can exist
        {
            Destroy(gameObject);
        }

        // ---------------------------------------------------------------------------------------------

        base.Start();   // Base classes Start function gives Living Entity all things a Living Entity needs

        SetMovementBehavior(new PlayerMovement(this));

        // Add experience stuff
        playerLevel = 1;
        CreateExpTable();
        experienceRequiredToLevel = experienceTable[playerLevel];

        SetClassType(new Mage(this));
        SetSkillsToButtons();
    }

    /// <summary>
    /// Called every frame
    /// </summary>
    private void Update()
    {
        //If it's not the player's turn, exit the function.
        if (!GameManager.instance.playersTurn)
            return;

        movementBehavior.CheckMovement();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            classType.skills[0].Cast(this, FindTarget("ZombieWeak"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            classType.skills[1].Cast(this, FindTarget("ZombieWeak"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            classType.skills[2].Cast(this, FindTarget("ZombieWeak"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            classType.skills[3].Cast(this, FindTarget("ZombieWeak"));
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            playerLevel = 1;
            SetClassType(new Mage(this));
            GameManager.instance.ShowNotification("Mage", Color.cyan);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            playerLevel = 1;
            SetClassType(new Paladin(this));
            GameManager.instance.ShowNotification("Paladin", Color.green);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            GameManager.instance.ShowNotification(playerLevel.ToString(), Color.white);
        }

    }
    public void SetSkillsToButtons()
    {
        int i = 0;

        txtSkill1 = GameObject.Find("txtSkill1").GetComponent<Text>();
        txtSkill2 = GameObject.Find("txtSkill2").GetComponent<Text>();
        txtSkill3 = GameObject.Find("txtSkill3").GetComponent<Text>();
        txtSkill4 = GameObject.Find("txtSkill4").GetComponent<Text>();

        Button[] buttons = new Button[4] { btnSkill1, btnSkill2, btnSkill3, btnSkill4 };
        Text[] buttonTexts = new Text[4] { txtSkill1, txtSkill2, txtSkill3, txtSkill4 };

        foreach (ISkill skill in classType.skills)
        {
            buttonTexts[i].text = (i + 1) + "." + classType.skills[i].name;
            i++;
        }

    }


    Character FindTarget(string targetName)
    {
        Character target = GameObject.Find(targetName).GetComponent<Character>();

        return target;
    }

    private void CreateExpTable()
    {
        ExperienceTable expTable = new ExperienceTable();

        experienceTable = expTable.CreateExperienceTable();
    }

    /// <summary>
    /// This is used when you want a player to interact with an item by stepping on it
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Exit")
        {
            enabled = false;
            Invoke("Restart", restartLevelDelay);
            StartCoroutine(movementBehavior.SmoothMovement(new Vector3(0, 0, 0))); // Move the player to the starting position of the next room
            enabled = true;
        }
    }

    /// <summary>
    /// Used when a new scene is being loaded
    /// </summary>
    private void Restart()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// When the player gets disabled, this will run
    /// </summary>
    private void OnDisable()
    {
    }

    public override void OnDeath()
    {
        // ~~IMPLEMENT: Check if both players are dead

        // If both players are dead, then...
        GameManager.instance.GameOver();     //Call the GameOver function of GameManager.
    }

    public bool CheckIfLevel()
    {
        if(experience >= experienceRequiredToLevel)
        {
            return true;
        }

        return false;
    }

    public void LevelUp()
    {
        int excessExperience;
        excessExperience = experience - experienceRequiredToLevel; // Store the extra that went over the level.

        playerLevel += 1;   // Level up the player.

        experienceRequiredToLevel = experienceTable[playerLevel];   // Change the experience required to level to the next level.

        expBar.fillAmount = 0;
        expBar.fillAmount += ((float)excessExperience / (float)experienceRequiredToLevel);   // Changes the fill amount to decrease when a character takes damage.

        experience = excessExperience; // Reset the players experience to equal the excess experience.

        classType.OnLevelUp(this);  // Add the specific class stats to the player

        GameManager.instance.ShowNotification("Level Up!", Color.yellow);
    }

    public void AddExperience(int gainedExperience)
    {
        experience += gainedExperience; // Add the gained experience to the players experience

        expBar.fillAmount += ((float)gainedExperience / (float)experienceRequiredToLevel);   // Changes the fill amount to decrease when a character takes damage
    }
    /// <summary>
    /// Called when an entity is about to take damage
    /// </summary>
    /// <param name="damage"> The amount of HP that the entity is going to lose </param>
    public void TakeDamage(int damage)
    {
        //Set the trigger for the player animator to transition to the playerHit animation.

        //Subtract lost food points from the players total.
        HP -= damage;

        healthBar.fillAmount -= ((float)damage / (float)maxHP);   // Changes the fill amount to decrease when a character takes damage


        //Update the food display with the new total.
        healthValue.text = HP.ToString() + "/" + maxHP.ToString();

        //Check to see if the entity is dead
        CheckIfDead();
    }

}

