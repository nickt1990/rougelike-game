using UnityEngine;
using System.Collections;
using UnityEngine.UI;   //Allows us to use UI.

namespace Completed
{
    public class Enemy : LivingEntity, IMovement, IAttack
    {
        public AudioClip attackSound1;                      //First of two audio clips to play when attacking the player.
        public AudioClip attackSound2;                      //Second of two audio clips to play when attacking the player.

        private Transform target;                           //Transform to attempt to move toward each turn.
        private bool skipMove;                              //Boolean to determine whether or not enemy should skip a turn or move this turn.

        //Start overrides the virtual Start function of the base class.
        public override void Start()
        {
            base.Start();   // We call the base class Start function to give everything required to be a living entity

            //Register this enemy with our instance of GameManager by adding it to a list of Enemy objects. 
            //This allows the GameManager to issue movement commands.
            GameManager.instance.AddEnemyToList(this);

            // Set the enemy health for the user to see
            healthBar = GameObject.Find("HealthBarValue").GetComponent<Image>();
            healthValue = GameObject.Find("HealthNumberValue").GetComponent<Text>();

            healthValue.text = HP.ToString();

            //Find the Player GameObject using it's tag and store a reference to its transform component.
            target = GameObject.FindGameObjectWithTag("Player").transform;

        }

        #region Movement Functionality
        //MoveEnemy is called by the GameManger each turn to tell each Enemy to try to move towards the player.
        public void MoveEnemy()
        {
            //Declare variables for X and Y axis move directions, these range from -1 to 1.
            //These values allow us to choose between the cardinal directions: up, down, left and right.
            int xDir = 0;
            int yDir = 0;

            //If the difference in positions is approximately zero (Epsilon) do the following:
            if (Mathf.Abs(target.position.x - transform.position.x) < float.Epsilon)

                //If the y coordinate of the target's (player) position is greater than the y coordinate of this enemy's position set y direction 1 (to move up). If not, set it to -1 (to move down).
                yDir = target.position.y > transform.position.y ? 1 : -1;

            //If the difference in positions is not approximately zero (Epsilon) do the following:
            else
                //Check if target x position is greater than enemy's x position, if so set x direction to 1 (move right), if not set to -1 (move left).
                xDir = target.position.x > transform.position.x ? 1 : -1;

            //Call the AttemptMove function and pass in the generic parameter Player, because Enemy is moving and expecting to potentially encounter a Player
            AttemptMove<Player>(xDir, yDir);
        }


        public void AttemptMove<T>(int xDir, int yDir) where T : Component
        {
            //Check if skipMove is true, if so set it to false and skip this turn.
            if (skipMove)
            {
                skipMove = false;
                return;

            }

            //Call the AttemptMove function from MovingObject.
            //AttemptMove<T>(xDir, yDir);

            //Now that Enemy has moved, set skipMove to true to skip next move.
            skipMove = true;
        }

        /// <summary>
        /// This function is called when an entity cannot move due to something being in the way
        /// </summary>
        /// <param name="component"> The object that the entity is running into </param>
        public void OnCantMove<T>(T component) where T : Component
        {
            PerformPhysicalAttack(component);
        }

        public IEnumerator SmoothMovement(Vector3 end)
        {
            throw new System.NotImplementedException();
        }

        public bool Move(int xDir, int yDir, out RaycastHit2D hit)
        {
            throw new System.NotImplementedException();
        }
        #endregion


        public void CheckIfDead()
        {
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
    }
}


