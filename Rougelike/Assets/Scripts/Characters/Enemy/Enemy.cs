using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;   //Allows us to use UI.


public class Enemy : Character, IAttack
{
    public AudioClip attackSound1;                      //First of two audio clips to play when attacking the player.
    public AudioClip attackSound2;                      //Second of two audio clips to play when attacking the player.
    public Text EnemyNameText;
    public Text EnemyDamageText;

    [Header("Experience")]
    public int experience;

    private Transform target;                           //Transform to attempt to move toward each turn.
    private bool skipMove;                              //Boolean to determine whether or not enemy should skip a turn or move this turn.

    //Start overrides the virtual Start function of the base class.
    public override void Start()
    {
        base.Start();   // We call the base class Start function to give everything required to be a living entity.

        // Register this enemy with our instance of GameManager by adding it to a list of Enemy objects. 
        // This allows the GameManager to issue movement commands.
        GameManager.instance.AddEnemyToList(this);

        // Write the name of the enemy above their head.
        EnemyNameText.text = Name;

        // Find the Player GameObject using it's tag and store a reference to its transform component.
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void PerformPhysicalAttack<T>(T component) where T : Component
    {
        //Declare hitPlayer and set it to equal the encountered component.
        Player target = component as Player;

        //Call the LoseFood function of hitPlayer passing it playerDamage, the amount of foodpoints to be subtracted.
        target.TakeDamage(PhysAtk);

        //Set the attack trigger of animator to trigger Enemy attack animation.
        animator.SetTrigger("enemyAttack");

        //Call the RandomizeSfx function of SoundManager passing in the two audio clips to choose randomly between.
        SoundManager.instance.RandomizeSfx(attackSound1, attackSound2);
    }

    public void PerformMagicAttack<T>(T component) where T : Component
    {
        throw new System.NotImplementedException();
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

        EnemyDamageText.text = "-" + damage;

        //Update the food display with the new total.
        healthValue.text = HP.ToString() + "/" + maxHP.ToString();

        //Check to see if the entity is dead
        CheckIfDead();
    }
}



