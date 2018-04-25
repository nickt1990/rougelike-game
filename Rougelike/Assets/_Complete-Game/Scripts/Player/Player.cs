using UnityEngine;
using System.Collections;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;
using System;

namespace Completed
{
    public class Player : LivingEntity, IMovement, IAttack
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

            // Then we add things specific attributes that only the player will have, such as...
            //healthText.text = "Health: " + HP;  // Displaying the HP to the user, using the proper Text field
            //manaText.text = "Mana: " + MP;      // Displaying the MP to the user, using the proper Text field
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

            if (Input.GetKey(left))
            {
                AttemptMove<Enemy>(-1, 0);
            }
            else if (Input.GetKey(right))
            {
                AttemptMove<Enemy>(1, 0);
            }
            else if (Input.GetKey(up))
            {
                AttemptMove<Enemy>(0, 1);
            }
            else if (Input.GetKey(down))
            {
                AttemptMove<Enemy>(0, -1);
            }

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

        #region Movement Functionality
        /// <summary>
        /// When it has been determined that a played CAN move, then this will run.
        /// </summary>
        /// <param name="xDir"> Direction of x the player will move. </param>
        /// <param name="yDir"> Direction of y that the player will move. </param>
        /// <param name="hit"> What the player hits, if anything. </param>
        /// <returns> TRUE: if the player has moved.  FALSE: If the player did not </returns>
        public bool Move(int xDir, int yDir, out RaycastHit2D hit)
        {
            //Store start position to move from, based on objects current transform position.
            Vector2 start = transform.position;

            // Calculate end position based on the direction parameters passed in when calling Move.
            Vector2 end = start + new Vector2(xDir, yDir);

            //Disable the boxCollider so that linecast doesn't hit this object's own collider.
            boxCollider.enabled = false;

            //Cast a line from start point to end point checking collision on blockingLayer.
            hit = Physics2D.Linecast(start, end, BlockingLayer);

            //Re-enable boxCollider after linecast
            boxCollider.enabled = true;

            //Check if anything was hit
            if (hit.transform == null)
            {
                //If nothing was hit, start SmoothMovement co-routine passing in the Vector2 end as destination
                StartCoroutine(SmoothMovement(end));

                //Return true to say that Move was successful
                return true;
            }

            //If something was hit, return false, Move was unsuccesful.
            return false;
        }

        /// <summary>
        /// This allows the player to smoothly move from one block into the next block
        /// </summary>
        /// <param name="end"> Where the player will end up </param>
        public IEnumerator SmoothMovement(Vector3 end)
        {
            //Calculate the remaining distance to move based on the square magnitude of the difference between current position and end parameter. 
            //Square magnitude is used instead of magnitude because it's computationally cheaper.
            float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

            //While that distance is greater than a very small amount (Epsilon, almost zero):
            while (sqrRemainingDistance > float.Epsilon)
            {
                //Find a new position proportionally closer to the end, based on the moveTime
                Vector3 newPostion = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);

                //Call MovePosition on attached Rigidbody2D and move it to the calculated position.
                rb2D.MovePosition(newPostion);

                //Recalculate the remaining distance after moving.
                sqrRemainingDistance = (transform.position - end).sqrMagnitude;

                //Return and loop until sqrRemainingDistance is close enough to zero to end the function
                yield return null;
            }
        }

        /// <summary>
        /// Whenever a button is hit to move the player, then this will get called to see if the player can actually move into the space the specified
        /// </summary>
        /// <typeparam name="T"> What the player will be running into (if anything) </typeparam>
        /// <param name="xDir"> The direction of x that the player will be moved </param>
        /// <param name="yDir"> The direction of y that the player will be moved</param>
        public void AttemptMove<T>(int xDir, int yDir)
            where T : Component
        {
            RaycastHit2D hit;
            //HealthText.text = "Health: " + newPlayer.healthPoints;

            CheckMove<T>(xDir, yDir);

            //Hit allows us to reference the result of the Linecast done in Move.
            if (Move(xDir, yDir, out hit))
            {
                //SoundManager.instance.RandomizeSfx(moveSound1, moveSound2);
            }

            //If Move returns true, meaning Player was able to move into an empty space.
            if (Move(xDir, yDir, out hit))
            {
                //Call RandomizeSfx of SoundManager to play the move sound, passing in two audio clips to choose from.
            }

            //Since the player has moved and lost food points, check if the game has ended.
            //CheckIfGameOver();

            //Set the playersTurn boolean of GameManager to false now that players turn is over.
            GameManager.instance.playersTurn = false;
        }

        public void CheckMove<T>(int xDir, int yDir)
            where T : Component
        {
            //Hit will store whatever our linecast hits when Move is called.
            RaycastHit2D hit;

            //Set canMove to true if Move was successful, false if failed.
            bool canMove = Move(xDir, yDir, out hit);

            //Check if nothing was hit by linecast
            if (hit.transform == null)
                //If nothing was hit, return and don't execute further code.
                return;

            //Get a component reference to the component of type T attached to the object that was hit
            T hitComponent = hit.transform.GetComponent<T>();

            //If canMove is false and hitComponent is not equal to null, meaning MovingObject is blocked and has hit something it can interact with.
            if (!canMove && hitComponent != null)

                //Call the OnCantMove function and pass it hitComponent as a parameter.
                OnCantMove(hitComponent);
        }

        /// <summary>
        /// If the player cannt move, then this is called
        /// </summary>
        /// <typeparam name="T"> What the player is running into</typeparam>
        /// <param name="component"> The actually type that the thing the player is running into will be </param>
        public void OnCantMove<T>(T component) where T : Component
        {
            PerformPhysicalAttack(component);
        }
        #endregion

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

