using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;
using System;


public class Player : Character, IAttack
{
    public const string TESTING_ENEMY = "Turtle";

    [Header("Experience Bar")]
    public Image expBar;
    public int playerLevel;

    [Header("Battle Bar")]
    public Image battleBar;
    public int btlBarValue;

    [Header("Unity Junk")]
    public int playerNumber;
    public float restartLevelDelay = 1f;    //Delay time in seconds to restart level.

    public Canvas playerUI;

    public int chargeAmount = 0;
    public float minAmount = 0;
    public float maxAmount = 100;
    public bool direction = false;
    private int _SweetSpot;
    public int SweetSpot
    {
        get { return _SweetSpot; }
        set
        {
            if (value < 1 || value > 3)
                throw new ArgumentException("Not valid sweetspot.");
            _SweetSpot = value;
        }
    }
    public float battleBarValue = 0;

    private int experience;
    private int experienceRequiredToLevel;

    private Dictionary<int, int> experienceTable;

    public IExecutable executable;

    GameObject pauseMenu;

    /// <summary>
    /// Called when the gameobject with the script attached enters the game
    /// </summary>
    public override void Start()
    {
        base.Start();   // Base classes Start function gives Living Entity all things a Living Entity needs

        SetMovementBehavior(new PlayerMovement(this));

        // Add experience stuff
        playerLevel = 1;
        CreateExpTable();
        experienceRequiredToLevel = experienceTable[playerLevel];

        SetClassType(new Mage(this));

        pauseMenu = GameObject.Find("PauseMenu");

        pauseMenu.SetActive(false);
    }

    /// <summary>
    /// Called every frame
    /// </summary>
    private void Update()
    {
        //If it's not the player's turn, exit the function.
        if (!GameManager.instance.playersTurn)
            return;

        if (pauseMenu.activeInHierarchy == false)
        {
            battleBarValue = battleBar.fillAmount;

            CheckBattleBar();

            characterMovementBehavior.CheckMovement();

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                SetMovementBehavior(new MenuControls());
                pauseMenu.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                characterClass.skills[0].Cast(this, FindTarget(TESTING_ENEMY));
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                characterClass.skills[1].Cast(this, FindTarget(TESTING_ENEMY));
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                characterClass.skills[2].Cast(this, FindTarget(TESTING_ENEMY));
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                characterClass.skills[3].Cast(this, FindTarget(TESTING_ENEMY));
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                playerLevel = 1;
                SetClassType(new Mage(this));
                GameManager.instance.ShowNotification("Mage", Color.cyan);
                GetComponent<SpriteRenderer>().color = Color.cyan;
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                playerLevel = 1;
                SetClassType(new Paladin(this));
                GameManager.instance.ShowNotification("Paladin", Color.green);
                GetComponent<SpriteRenderer>().color = Color.yellow;
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                //GameManager.instance.ShowNotification(playerLevel.ToString(), Color.white);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (SweetSpot == 2)
                {
                    chargeAmount++;
                    var message = String.Format("CHRG: {0}", chargeAmount);
                    GameManager.instance.ShowNotification(message, Color.green);
                }
                else if (SweetSpot == 1)
                {
                    chargeAmount = 0;
                    GameManager.instance.ShowNotification("Bad hit.", Color.red);
                }
                battleBar.fillAmount = 0;
            }
        }
        else
        {
            characterMovementBehavior.CheckMovement();

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SetMovementBehavior(new PlayerMovement(this));
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    private void CheckBattleBar()
    {
        if (battleBarValue >= .80 && battleBarValue <= 1)
        {
            battleBar.GetComponent<Image>().color = Color.green;
        }

        if (battleBarValue >= .79 && battleBarValue <= 1 || battleBarValue <= .02)
        {
            SweetSpot = 2;
        }
        else
        {
            battleBar.GetComponent<Image>().color = Color.red;
            SweetSpot = 1;
        }

        battleBar.fillAmount += ((float).02 / (float)maxAmount);

        if (battleBar.fillAmount == maxAmount)
        {
            battleBar.fillAmount = 0;
            chargeAmount = 0;
        }
    }

    void EquipItem(Equipment location, Equipment equipment)
    {
        if (location.equipmentType == equipment.equipmentType)
        {
            location = equipment;
        }
        else
        {
            Console.WriteLine("You cannot equip that type of equipment here.");
        }
    }

    /// <summary>
    /// Finds the target with the given name
    /// </summary>
    /// <param name="targetName"> The name of the target to find </param>
    /// <returns> The target of the attack </returns>
    Character FindTarget(string targetName)
    {
        Character target = GameObject.Find(targetName).GetComponent<Character>();

        return target;
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
            StartCoroutine(characterMovementBehavior.SmoothMovement(new Vector3(0, 0, 0))); // Move the player to the starting position of the next room
            enabled = true;
        }
        else if (other.tag == "Food" || other.tag == "Soda")
        {
            TakeDamage(-25);
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Door")
        {
            enabled = false;
            StartCoroutine(characterMovementBehavior.SmoothMovement(new Vector3(0.5f, 0.5f, 0))); // Move the player to the starting position of the next room
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


    #region Fights

    /// <summary>
    /// Perform a basic physical attack as a character
    /// </summary>
    public override void PerformPhysicalAttack<T>(T component)
    {
        // The component that was passed in is the target that the Character is hitting, so we set it to be so.
        Enemy target = component as Enemy;

        //Call the TakeDamage function of the Character we are hitting.
        target.TakeDamage(characterClass.classStats.PhysAtk + (eqpMainHand.stats.PhysAtk + eqpOffHand.stats.PhysAtk + (chargeAmount * chargeAmount / 2)));

        //Set the attack trigger of the player's animation controller in order to play the player's attack animation.
        animator.SetTrigger("playerChop");

        if (target.CheckIfDead())
        {
            AddExperience(target.experience);
        }
    }

    /// <summary>
    /// Called when an entity is about to take damage
    /// </summary>
    /// <param name="damage"> The amount of HP that the entity is going to lose </param>
    public void TakeDamage(int damage)
    {
        // Sometimes damage can be negative, causing the character to be healed.  If that heal exceeds their max HP, then...
        if (characterStats.HP - damage > maxHP)
        {
            characterStats.HP = maxHP; // Forget how much it healed, and simply set their HP to their maxHP
        }
        else // otherwise...
        {
            //Subtract damage from players health
            characterStats.HP -= damage;
        }

        //Subtract lost food points from the players total.
        characterStats.HP -= damage;

        healthBar.fillAmount -= ((float)damage / (float)maxHP);   // Changes the fill amount to decrease when a character takes damage

        //Update the food display with the new total.
        healthValue.text = characterStats.HP.ToString() + "/" + maxHP.ToString();

        //Check to see if the entity is dead
        CheckIfDead();
    }
    #endregion

    #region Levels and Experience
    /// <summary>
    /// Check to see if the player has leveled up
    /// </summary>
    public void CheckIfLevel()
    {
        if (experience >= experienceRequiredToLevel)
        {
            LevelUp();
        }
    }
    /// <summary>
    /// Processes that happen is the player has leveled up
    /// </summary>
    public void LevelUp()
    {
        int excessExperience;
        excessExperience = experience - experienceRequiredToLevel; // Store the extra that went over the level.

        playerLevel += 1;   // Level up the player.

        experienceRequiredToLevel = experienceTable[playerLevel];   // Change the experience required to level to the next level.

        expBar.fillAmount = 0;
        expBar.fillAmount += ((float)excessExperience / (float)experienceRequiredToLevel);   // Changes the fill amount to decrease when a character takes damage.

        experience = excessExperience; // Reset the players experience to equal the excess experience.

        characterClass.OnLevelUp();  // Add the specific class stats to the player

        GameManager.instance.ShowNotification("Level Up!", Color.yellow);
    }

    /// <summary>
    /// Add experience to the player, and increment the exp bar
    /// </summary>
    /// <param name="gainedExperience"> The experience that has been gained by the player </param>
    public void AddExperience(int gainedExperience)
    {
        experience += gainedExperience; // Add the gained experience to the players experience

        expBar.fillAmount += ((float)gainedExperience / (float)experienceRequiredToLevel);   // Changes the fill amount to decrease when a character takes damage

        CheckIfLevel();
    }

    /// <summary>
    /// Create the values of experience it will take for each level
    /// </summary>
    private void CreateExpTable()
    {
        ExperienceTable expTable = new ExperienceTable();

        experienceTable = expTable.CreateExperienceTable();
    }

    #endregion

    #region Death
    /// <summary>
    /// What happens when a player dies
    /// </summary>
    public void OnDeath()
    {
        // ~~IMPLEMENT: Check if both players are dead

        // If both players are dead, then...
        GameManager.instance.GameOver();     //Call the GameOver function of GameManager.
    }
    /// <summary>
    /// Check if a players HP is below 0
    /// </summary>
    /// <returns> TRUE: If the HP is below 0, FALSE: if the HP is above 0 </returns>
    public bool CheckIfDead()
    {
        //Check if food point total is less than or equal to zero.
        if (characterStats.HP <= 0)
        {
            OnDeath();
            return true;
        }

        return false;
    }
    #endregion
}

