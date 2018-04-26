using UnityEngine;
using System.Collections;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;
using System;

namespace Completed
{
    public class Player : Character, IAttack
    {
        public KeyCode left = KeyCode.A;
        public KeyCode right = KeyCode.D;
        public KeyCode up = KeyCode.W;
        public KeyCode down = KeyCode.S;
        public KeyCode use = KeyCode.E;

        public int playerNumber;
        public IClassType classType;
        public float restartLevelDelay = 1f;        //Delay time in seconds to restart level.

        public Player(IClassType _thisClass)
        {
            classType = _thisClass;
        }

        public override void Start()
        {
            base.Start();   // Base classes Start function gives Living Entity all things a Living Entity needs

            SetMovementBehavior(new PlayerMovement(this));
        }

        /// <summary>
        /// This will be called if the player has chosen to change their class
        /// </summary>
        /// <param name="newClass"></param>
        public void SetClass(IClassType newClass)
        {
            classType = newClass;
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

        #region Attack Functionality
        public void PerformPhysicalAttack<T>(T component) where T : Component
        {
            //Set hitWall to equal the component passed in as a parameter.
            Enemy target = component as Enemy;

            //Call the DamageWall function of the Wall we are hitting.
            target.TakeDamage(PhysAtk);

            //Set the attack trigger of the player's animation controller in order to play the player's attack animation.
            animator.SetTrigger("playerChop");
        }

        public void PerformMagicAttack<T>(T target) where T : Component
        {
            throw new NotImplementedException();
        }
        #endregion

        public override void OnDeath()
        {
            // ~~IMPLEMENT: Check if both players are dead

            // If both players are dead, then...
            GameManager.instance.GameOver();     //Call the GameOver function of GameManager.

        }

    }
}

