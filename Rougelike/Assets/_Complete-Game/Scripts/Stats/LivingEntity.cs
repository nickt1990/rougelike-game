using UnityEngine;
using System.Collections;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;
using System;

public class LivingEntity : MonoBehaviour, IStats
{
    [HideInInspector] public Animator animator;					//Used to store a reference to the Player's animator component.

    public Text healthText;
    public Text manaText;

    public float inverseMoveTime;           //Used to make movement more efficient.
    public float moveTime = 0.1f;           //Time it will take object to move, in seconds.

    #region Inherits From
    public IAttackBehavior attackBehavior;
    public IDialogueBehavior dialogueBehavior;
    public IMovementBehavior movementBehavior;
    #endregion

    #region IStats Variables
    public int healthPoints
    {
        get
        {
            return HP;
        }
        set
        {
            _healthPoints = HP;
        }
    }
    public int magicPoints
    {
        get
        {
            return MP;
        }
        set
        {
            _magicPoints = value;
        }
    }
    public int physicalAttack
    {
        get
        {
            return PhysicalAttack;
        }
        set
        {
            _physicalAttack = value;
        }
    }
    public int magicAttack
    {
        get
        {
            return MagicAttack;
        }
        set
        {
            _magicAttack = value;
        }
    }
    public int speed
    {
        get
        {
            return Speed;
        }
        set
        {
            _speed = value;
        }
    }
    #endregion

    public string Name;
    public int HP;
    public int MP;
    public int PhysicalAttack;
    public int MagicAttack;
    public int Speed;

    private int _healthPoints;
    private int _magicPoints;
    private int _physicalAttack;
    private int _magicAttack;
    private int _speed;

    public LivingEntity()
    {
        playerName = Name;
        healthPoints = HP;
        magicPoints = MP;
        physicalAttack = PhysicalAttack;
        magicAttack = MagicAttack;
        speed = Speed;
    }

    private void Start()
    {
        //Get a component reference to the Player's animator component
        animator = GetComponent<Animator>();

        //Set the foodText to reflect the current player food total.
        healthText.text = "Health: " + healthPoints;
        manaText.text = "Mana: " + magicPoints;

    }

    public string playerName { get; set; }

    public void SetAttackBheavior(IAttackBehavior _attackBehavior)
    {
        attackBehavior = _attackBehavior;
    }

    public void SetDialogueBehavior(IDialogueBehavior _dialogueBehavior)
    {
        dialogueBehavior = _dialogueBehavior;
    }

    public void SetMovementBehavior(IMovementBehavior _movementBehavior)
    {
        movementBehavior = _movementBehavior;
    }

    public void PerformAttack()
    {
        attackBehavior.Attack();
    }

    public void BeginDialogue()
    {
        dialogueBehavior.Talk();
    }

    public void Move()
    {
        //movementBehavior.Move();
    }

    /// <summary>
    /// Called when an entity is going to lose health points
    /// </summary>
    /// <param name="loss"> The amount of health points the entity will lose</param>
    public void TakeDamage(int loss)
    {
        //Set the trigger for the player animator to transition to the playerHit animation.
        animator.SetTrigger("playerHit");

        //Subtract lost food points from the players total.
        healthPoints -= loss;

        //Update the food display with the new total.
        healthText.text = "-" + loss + " Health: " + healthPoints;

        //Check to see if game has ended.

        //> DONT FORGET ABOUT THIS <
        //CheckIfGameOver(); 
    }
}
