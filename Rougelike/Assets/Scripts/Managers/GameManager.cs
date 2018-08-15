using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

using System.Collections.Generic;       //Allows us to use Lists. 
using UnityEngine.UI;                   //Allows us to use UI.

public class GameManager : MonoBehaviour
{
	public float levelStartDelay = 2f;                      //Time to wait before starting level, in seconds.
	public float turnDelay = 0.2f;                          //Delay between each Player turn.
	public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
	[HideInInspector] public bool playersTurn = true;       //Boolean to check if it's players turn, hidden in inspector but public.

	public Player player1;
	//public Player player2;

	private Text levelText;                                 //Text to display current level number.
	private Text levelUpText;
	private GameObject levelImage;                          //Image to block out level as levels are being set up, background for levelText.
	//private BoardManager boardScript;                     //Store a reference to our BoardManager which will set up the level.
	private int level = 1;                                  //Current level number, expressed in game as "Day 1".
	private List<Character> enemies;                        //List of all Enemy units, used to issue them move commands.
	private bool enemiesMoving;                             //Boolean to check if enemies are moving.
	private bool doingSetup = false;                        //Boolean to check if we're setting up board, prevent Player from moving during setup.

	private IControlBehavior currentControls;

	//Awake is always called before any Start functions
	void Awake()
	{
		//Check if instance already exists
		if (instance == null)

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);

		//Assign enemies to a new List of Enemy objects.
		enemies = new List<Character>();

		//Call the InitGame function to initialize the first level 
		//InitGame();
	}

	//this is called only once, and the paramter tell it to be called only after the scene was loaded
	//(otherwise, our Scene Load callback would be called the very first load, and we don't want that)
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	public static void CallbackInitialization()
	{
		//register the callback to be called everytime the scene is loaded
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	//This is called each time a scene is loaded.
	static private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
	{
		instance.level++;
		instance.InitGame();
	}


	//Initializes the game for each level.
	void InitGame()
	{
		//While doingSetup is true the player can't move, prevent player from moving while title card is up.
		doingSetup = true;

		//Call the HideLevelImage function with a delay in seconds of levelStartDelay.
		Invoke("HideLevelImage", levelStartDelay);

		//Clear any Enemy objects in our List to prepare for next level.
		enemies.Clear();

		//Call the SetupScene function of the BoardManager script, pass it current level number.
		//boardScript.SetupScene(level);
	}


	//Hides black image used between levels
	void HideLevelImage()
	{

		//Set doingSetup to false allowing player to move again.
		doingSetup = false;
	}

	public void ShowNotification(string textToDisplay, Color colorOfText)
	{
		levelUpText = GameObject.Find("LevelUp").GetComponent<Text>();

		levelUpText.color = colorOfText;
		levelUpText.text = textToDisplay;

		Invoke("HideLevelUpNotification", levelStartDelay);

	}

	void HideLevelUpNotification()
	{
		levelUpText.text = "";
	}

	//Update is called every frame.
	void Update()
	{
		//Check that playersTurn or enemiesMoving or doingSetup are not currently true.
		if (playersTurn || enemiesMoving || doingSetup)
			return; //If any of these are true, return and do not start MoveEnemies.

		playersTurn = true;
		//Start moving enemies.
		StartCoroutine(MoveEnemies());
	}

	//Call this to add the passed in Enemy to the List of Enemy objects.
	public void AddEnemyToList(Character script)
	{
		//Add Enemy to List enemies.
		enemies.Add(script);
	}


	//GameOver is called when the player reaches 0 food points
	public void GameOver()
	{
		//Set levelText to display number of levels passed and game over message
		//levelText.text = "After " + level + " days, " + newPlayer.playerName + " the " + newPlayer.classType.GetClassName() + " starved.";

		//Enable black background image gameObject.
		levelImage.SetActive(true);

		//Disable this GameManager.
		enabled = false;
	}

	//Coroutine to move enemies in sequence.
	IEnumerator MoveEnemies()
	{
		//While enemiesMoving is true player is unable to move.
		enemiesMoving = true;

		//Wait for turnDelay seconds, defaults to .1 (100 ms).
		yield return new WaitForSeconds(turnDelay);

		//If there are no enemies spawned (IE in first level):
		if (enemies.Count == 0)
		{
			//Wait for turnDelay seconds between moves, replaces delay caused by enemies moving when there are none.
			yield return new WaitForSeconds(turnDelay);
		}

		//Loop through List of Enemy objects.
		for (int i = 0; i < enemies.Count; i++)
		{
			//Call the MoveEnemy function of Enemy at index i in the enemies List.
			//enemies[i].MoveEnemy();

			//Wait for Enemy's moveTime before moving next Enemy, 
			yield return new WaitForSeconds(enemies[i].moveTime);
		}
		//Once Enemies are done moving, set playersTurn to true so player can move.
		playersTurn = true;

		//Enemies are done moving, set enemiesMoving to false.
		enemiesMoving = false;
	}
}

