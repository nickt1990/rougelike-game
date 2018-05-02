using UnityEngine;
using System.Collections.Generic;
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

    [Header("Damage Modification")]
    public List<Element> ElementalWeaknesses = new List<Element>();   // List of element that the Character is weak against (2x damage taken)
    public List<Element> ElementalResistances = new List<Element>();  // List of element that the character is strong against (1/2 damage taken)

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

    [HideInInspector] public int maxHP;
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
        //DontDestroyOnLoad(gameObject);

        //Get a component reference to this object's BoxCollider2D
        boxCollider = GetComponent<BoxCollider2D>();

        //Get a component reference to this object's Rigidbody2D
        rb2D = GetComponent<Rigidbody2D>();

        //By storing the reciprocal of the move time we can use it by multiplying instead of dividing, this is more efficient.
        inverseMoveTime = 1f / moveTime;

        //Get a component reference to the Player's animator component
        animator = GetComponent<Animator>();

        SetClassType(new NoClass(this));    // Every Character starts with No Class - This can be changed at any time if a specific character needs one.
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

    #region Attack Functionality

    public void PerformPhysicalAttack<T>(T component) where T : Component
    {
        // The component that was passed in is the target that the Character is hitting, so we set it to be so.
        Enemy target = component as Enemy;

        //Call the TakeDamage function of the Character we are hitting.
        target.TakeDamage(PhysicalAttack);

        //Set the attack trigger of the player's animation controller in order to play the player's attack animation.
        animator.SetTrigger("playerChop");
        
    }

    public void CastSkill<T>(T component)
    {
        Character target = component as Character;

        classType.skills[0].Cast(this, target);

        animator.SetTrigger("playerChop");
    }

    public void PerformMagicAttack<T>(T target) where T : Component
    {
        throw new NotImplementedException();
    }
    #endregion

    public bool CheckIfDead()
    {
        //Check if food point total is less than or equal to zero.
        if (HP <= 0)
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
}
