using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;
using System;

public class Character : MonoBehaviour
{
    #region Interfaces
    public IAttack characterAttackBehavior;              // A character can attack in some way
    public IDialogueBehavior characterDialogueBehavior;  // A character can talk in some way
    public IMovementBehavior characterMovementBehavior;  // A character can move in some way
    public IStats characterStats = new Stats();
    #endregion

    public ClassType characterClass;            // Class of a character
    [HideInInspector] public Animator animator; // Used to store a reference to the Player's animator component.

    [Header("Character Name")]
    [SerializeField]
    private string characterName;
    public string Name
    {
        get
        {
            return characterName;
        }
        set
        {
            characterName = value;
        }
    }

    [Header("Helpful Components")]
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

    [HideInInspector] public int maxHP;

    [Header("Damage Modification")]
    public List<Effect> weaknesses = new List<Effect>();   // Damage modifiers that deal double damage to this character
    public List<Effect> resistances = new List<Effect>();  // Damage modifiers that deal half damage to this character
    public List<Effect> immunities = new List<Effect>();   // Damage modifiers that deal no damage to this character
    public List<Effect> advantages = new List<Effect>();   // Damage modifiers that heal this character

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
    }

    public void SetMovementBehavior(IMovementBehavior mb)
    {
        characterMovementBehavior = mb;
    }

    /// <summary>
    /// Set how the character will speak
    /// </summary>
    /// <param name="db"> The specific way a character will speak </param>
    public void SetDialogueBehavior(IDialogueBehavior db)
    {
        characterDialogueBehavior = db;
    }

    /// <summary>
    /// Set the class type of the character
    /// </summary>
    /// <param name="newClass">The class you would like the character to become </param>
    public void SetClassType(ClassType newClass)
    {
        characterClass = newClass;
    }

    public void BeginDialogue()
    {

    }

    #region Attack Functionality

    public virtual void PerformPhysicalAttack<T>(T component) where T : Component
    {
        // The component that was passed in is the target that the Character is hitting, so we set it to be so.
        Enemy target = component as Enemy;

        //Call the TakeDamage function of the Character we are hitting.
        target.TakeDamage(characterClass.classStats.PhysAtk);

        //Set the attack trigger of the player's animation controller in order to play the player's attack animation.
        animator.SetTrigger("playerChop");

    }

    public void CastSkill<T>(T component)
    {
        Character target = component as Character;

        characterClass.skills[0].Cast(this, target);

        animator.SetTrigger("playerChop");
    }

    public virtual void PerformMagicAttack<T>(T target) where T : Component
    {
        throw new NotImplementedException();
    }
    #endregion


}
