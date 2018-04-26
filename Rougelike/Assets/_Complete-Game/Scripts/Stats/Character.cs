using UnityEngine;
using System.Collections;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;
using System;

public class Character : MonoBehaviour, IStats
{
    #region Interfaces
    public IAttack attackBehavior;
    public IDialogueBehavior dialogueBehavior;
    public IMovement movementBehavior;
    #endregion

    [HideInInspector] public Animator animator;					//Used to store a reference to the Player's animator component.

    public Image healthBar;
    public Text healthValue;

    public BoxCollider2D boxCollider { get; set; }
    public Rigidbody2D rb2D { get; set; }
    public float moveTime { get; set; }
    public float inverseMoveTime { get; set; }

    [SerializeField]
    private LayerMask _blockingLayer;
    public LayerMask BlockingLayer
    {
        get
        {
            return _blockingLayer;
        }
        set
        {
            _blockingLayer = value;
        }
    }

    #region Get/Set Stats
    [SerializeField]
    private string entityName;
    public string Name
    {
        get
        {
            return entityName;
        }
        set
        {
            entityName = value;
        }
    }

    [SerializeField]
    private int HealthPoints;
    public int HP
    {
        get
        {
            return HealthPoints;
        }
        set
        {
            HealthPoints = value;
        }
    }

    [SerializeField]
    private int MagicPoints;
    public int MP
    {
        get
        {
            return MagicPoints;
        }
        set
        {
            MagicPoints = value;
        }
    }

    [SerializeField]
    private int PhysicalAttack;
    public int PhysAtk
    {
        get
        {
            return PhysicalAttack;
        }
        set
        {
            PhysicalAttack = value;
        }
    }
    [SerializeField]
    private int MagicAttack;
    public int MagAtk
    {
        get
        {
            return MagicAttack;
        }
        set
        {
            MagicAttack = value;
        }
    }

    [SerializeField]
    private int speed;
    public int Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    private int maxHP;
    #endregion

    public virtual void Start()
    {
        //Get a component reference to this object's BoxCollider2D
        boxCollider = GetComponent<BoxCollider2D>();

        //Get a component reference to this object's Rigidbody2D
        rb2D = GetComponent<Rigidbody2D>();

        //By storing the reciprocal of the move time we can use it by multiplying instead of dividing, this is more efficient.
        inverseMoveTime = 1f / moveTime;

        //Get a component reference to the Player's animator component
        animator = GetComponent<Animator>();

        healthValue.text = HP.ToString();

        maxHP = HP; // Max amount of HP that a player starts with
    }

    public void BeginDialogue()
    {
        dialogueBehavior.Talk();
    }

    /// <summary>
    /// Called when an entity is about to take damage
    /// </summary>
    /// <param name="loss"> The amount of HP that the entity is going to lose </param>
    public void TakeDamage(int loss)
    {
        //Set the trigger for the player animator to transition to the playerHit animation.

        //Subtract lost food points from the players total.
        HP -= loss;

        healthBar.fillAmount -= ((float)loss / (float)maxHP);   // Changes the fill amount to decrease when a character takes damage

        //Update the food display with the new total.
        healthValue.text = HP.ToString();

        //Check to see if the entity is dead
        CheckIfDead(); 
    }

    private void CheckIfDead()
    {
        //Check if food point total is less than or equal to zero.
        if (HP <= 0)
        {
            OnDeath();
        }
    }

    public virtual void OnDeath()
    {
        gameObject.SetActive(false);
    }
}
