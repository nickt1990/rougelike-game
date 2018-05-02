using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;
using System;


public class Player : Character, IAttack
{
    [Header("Experience Bar")]
    public Image expBar;

    [Header("Unity Junk")]
    public int playerNumber;
    public float restartLevelDelay = 1f;        //Delay time in seconds to restart level.

    private int playerLevel;
    private int experience;
    private int experienceRequiredToLevel;

    private Dictionary<int, int> experienceTable;

    public IExecutable executable;

    public override void Start()
    { 

        base.Start();   // Base classes Start function gives Living Entity all things a Living Entity needs

        // Add experience stuff
        playerLevel = 1;
        CreateExpTable();
        experienceRequiredToLevel = experienceTable[playerLevel];

        SetMovementBehavior(new PlayerMovement(this));

        SetClassType(new Paladin(this));
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
            Invoke("Restart", restartLevelDelay);
            enabled = false;
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

        GameManager.instance.ShowLevelUpNotification();
    }

    public void AddExperience(int gainedExperience)
    {
        experience += gainedExperience; // Add the gained experience to the players experience

        expBar.fillAmount += ((float)gainedExperience / (float)experienceRequiredToLevel);   // Changes the fill amount to decrease when a character takes damage

        //Update the health display with the new total.
        healthValue.text = HP.ToString();
    }

}

