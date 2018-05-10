using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;   //Allows us to use UI.


public class Enemy : Character
{
    public AudioClip attackSound1;                      //First of two audio clips to play when attacking the player.
    public AudioClip attackSound2;                      //Second of two audio clips to play when attacking the player.
    public Text EnemyNameText;
    public Text EnemyDamageText;

    [Header("Stats")]
    public int healthPoints;
    public int magicPoints;
    public int physicalAttack;
    public int magicAttack;
    public int speed;

    [Header("Experience")]
    public int experience;

    private Transform target;                           //Transform to attempt to move toward each turn.
    private bool skipMove;                              //Boolean to determine whether or not enemy should skip a turn or move this turn.

    //Start overrides the virtual Start function of the base class.
    public override void Start()
    {
        base.Start();   // We call the base class Start function to give everything required to be a living entity.

        SetStats();
        SetClassType(new NoClass(this));    // Every Character starts with No Class - This can be changed at any time if a specific character needs one.

        // Register this enemy with our instance of GameManager by adding it to a list of Enemy objects. 
        // This allows the GameManager to issue movement commands.
        GameManager.instance.AddEnemyToList(this);

        // Write the name of the enemy above their head.
        EnemyNameText.text = Name;

        // Find the Player GameObject using it's tag and store a reference to its transform component.
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SetStats()
    {
        characterStats.HP = healthPoints;
        characterStats.MP = magicPoints;
        characterStats.PhysAtk = physicalAttack;
        characterStats.MagAtk = magicAttack;
        characterStats.Speed = speed;
    }

    public override void PerformPhysicalAttack<T>(T component)
    {
        //Declare hitPlayer and set it to equal the encountered component.
        Player target = component as Player;

        //Call the LoseFood function of hitPlayer passing it playerDamage, the amount of foodpoints to be subtracted.
        target.TakeDamage(characterStats.PhysAtk);

        //Set the attack trigger of animator to trigger Enemy attack animation.
        animator.SetTrigger("enemyAttack");

        //Call the RandomizeSfx function of SoundManager passing in the two audio clips to choose randomly between.
        SoundManager.instance.RandomizeSfx(attackSound1, attackSound2);
    }

    public override void PerformMagicAttack<T>(T component)
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

        // Sometimes damage can be negative, causing the character to be healed.  If that heal exceeds their max HP, then...
        if(characterStats.HP - damage > maxHP)
        {
            characterStats.HP = maxHP; // Forget how much it healed, and simply set their HP to their maxHP
        }
        else // otherwise...
        {
            //Subtract damage from players health
            characterStats.HP -= damage;
        }
        

        healthBar.fillAmount -= ((float)damage / (float)maxHP);   // Changes the fill amount to decrease when a character takes damage

        DisplayDamage(damage);

        //Check to see if the entity is dead
        CheckIfDead();
    }

    private void DisplayDamage(int damage)
    {
        if (damage > 0)
        {
            EnemyDamageText.text = "-" + damage.ToString();
        }
        else if (damage == 0)
        {
            EnemyDamageText.text = damage.ToString();
        }
        else if (damage < 0)
        {
            EnemyDamageText.text = "+" + damage.ToString().Split('-')[1];
        }


        //Update the healthbar with the new total.
        healthValue.text = characterStats.HP.ToString() + "/" + maxHP.ToString();
    }

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

    public virtual void OnDeath()
    {
        gameObject.SetActive(false);
    }

    public void AddNewResistance(IModifiesDamage newResistance)
    {

    }

    public void AddNewWeakness(IModifiesDamage newWeakness)
    {

    }
}



