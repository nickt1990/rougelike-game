using UnityEngine;
using System.Collections;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;
using System;

public class Character : MonoBehaviour, IStats
{
    #region Interfaces
    public IAttack attackBehavior;              // A character can attack in some way
    public IDialogueBehavior dialogueBehavior;  // A character can talk in some way
    public IMovementBehavior movementBehavior;  // A character can move in some way
    public IClassType classType;                // A character can have a class
    public ISkill[] skills;                     // A character can have skill(s)
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

    #region Stats

        // Used as a base for the class to go off of, and also used if character has no class
        #region Base Stats
        [Header("Base Stats")]
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
        private int BaseHealthPoints;
        public int HP
        {
            get
            {
                return BaseHealthPoints;
            }
            set
            {
                BaseHealthPoints = value;
            }
        }

        [SerializeField]
        private int BaseMagicPoints;
        public int MP
        {
            get
            {
                return BaseMagicPoints;
            }
            set
            {
                BaseMagicPoints = value;
            }
        }

        [SerializeField]
        private int BasePhysicalAttack;
        public int PhysAtk
        {
            get
            {
                return BasePhysicalAttack;
            }
            set
            {
                BasePhysicalAttack = value;
            }
        }
        [SerializeField]
        private int BaseMagicAttack;
        public int MagAtk
        {
            get
            {
                return BaseMagicAttack;
            }
            set
            {
                BaseMagicAttack = value;
            }
        }

        [SerializeField]
        private int BaseSpeed;
        public int baseSpeed
        {
            get
            {
                return BaseSpeed;
            }
            set
            {
                BaseSpeed = value;
            }
        }

        private int maxHP;
        #endregion

        // After the class modifies the base stats
        #region Modified Stats
        [Header("Class Modified Stats")]
        [NonSerialized]
        public int HealthPoints;

        [NonSerialized]
        public int MagicPoints;

        [NonSerialized]
        public int PhysicalAttack;

        [NonSerialized]
        public int MagicAttack;

        [NonSerialized]
        public int Speed;
        #endregion

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

        healthValue.text = HealthPoints.ToString();

        maxHP = HealthPoints; // Max amount of HP that a player starts with
    }

    public void SetMovementBehavior(IMovementBehavior mb)
    {
        movementBehavior = mb;
    }

    public void SetDialogueBehavior(IDialogueBehavior db)
    {
        dialogueBehavior = db;
    }

    public void SetClassType(IClassType ct)
    {
        classType = ct;
    }

    public void BeginDialogue()
    {
        
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
