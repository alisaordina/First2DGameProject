using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * The HUDController.cs script
 * Alisa Ordina
 * id: 100967526
 * October 22, 2017
 * 
 * This script component is attached to Canvas game object in the scene.
 * This script will connect with UI interface and keeps track of user's points.
 * To be able to access these UI elements the UnityEngine.UI class is imported
 * by coding: using UnityEngine.UI
 * Since the following change of the scene is applied on to the button event
 * the ScneManagement is imported
 * by coding: using UnityEngine.SceneManagement
 * This following code applies updates to score label, life label,
 * Gave Over label, and button. This code in ables to apply
 * changes to the UI display and display specific labels 
 * when appropriate and apply an event to a button game object.
 * 
*/

public class HUDController : MonoBehaviour 
{

	//Declaire variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated game object that is called enemy.
	[SerializeField] GameObject enemy; 

	//Declaire variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated game object that is called player.
	//[SerializeField] GameObject bird;
	[SerializeField] GameObject bird; 


	//Declaire variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated lifeLabel game object of the Canvas UI.
	[SerializeField] Text lifeLabel;

	//Declaire variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated scoreLabel game object of the Canvas UI.
	[SerializeField] Text scoreLabel;

	//Declaire variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated gameOverLabel game object of the Canvas UI.
	[SerializeField] Text gameOverLabel;

	//Declaire variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated highScoreLabel game object of the Canvas UI.
	[SerializeField] Text highScoreLabel;

	//Declaire variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated resetBtn game object of the Canvas UI.
	[SerializeField] Button resetBtn;

	//Declaire private variable
	//This variable is assigned to a designated AudioSource variable
	//private AudioSource _gameOverSound;

	/*private int _score = 0;

	private int _life = 3;

	public int Score
	{

		get 
		{
			return _score;
		}
		set
		{
			_score = value;

			scoreLabel.text = "Score: " + _score;
		}
	}

	public int Life
	{

		get 
		{
			return _life;
		}
		set
		{
			_life = value;

			if (_life <= 0) 
			{
				gameOver ();
			} 
			else 
			{
				lifeLabel.text = "Life: " + _life;
			}
		}
	}*/

	//This function is called at the start function
	//where it would display the score and the life labels.
	//This function will make certain labels in Active state
	//which means enabled state that appear on the camera view. 
	//While making other labels in non Active mode setting the
	//game object in disabled mode, 
	//which means that this game object labels will not
	//appear in the scene and not interact with any thing in the scene.
	private void initialize()
	{

		//Creates, clones the enemy game object onto the
		//scene

		bird.gameObject.SetActive (true);

		//First setting up the score label to 0 value.
		Player.Instance.Score = 0;

		//First setting up the life label to a value of 3.
		Player.Instance.Life = 3;

		//First setting up the high score label to a value of 0.
		Player.Instance.HighScore = 0;

		//Setting life label in Heads Up Display
		//in UI in active mode
		//An active means that this life label game object 
		//is enabled and is appeared in the scene.
		lifeLabel.gameObject.SetActive (true);

		//Setting score label in Heads Up Display
		//in UI in active mode
		//An active means that this score label game object 
		//is enabled and is appeared in the scene
		scoreLabel.gameObject.SetActive (true);

		//Setting the bird player game object 
		//in an active mode
		//An active means that this bird player game object 
		//is enabled and is appeared in the scene.
		//player.SetActive (true);

		//Setting Game Over label in Heads Up Display
		//in UI in non-active mode
		//A non-active means that this GameOver label game object 
		//is disabled and it is not appeared in the scene
		gameOverLabel.gameObject.SetActive (false);

		//Setting high score label in Heads Up Display
		//in UI in non-active mode
		//A non-active means that this high score label game object 
		//is disabled and it is not appeared in the scene
		highScoreLabel.gameObject.SetActive (false);

		//Setting up the button in Heads Up Display
		//in UI in non-active mode.
		//A non-active means that the button game object 
		//is disabled and it is not appeared in the scene
		resetBtn.gameObject.SetActive (false);


		//Since the initialize function 
		//has been called the enemy game object would be instantiated (created)  
		//onto the scene.
		//The coroutine function AddEnemy() would be called.
		//To add enemy game object onto the scene with random specified delayed seconds.
		StartCoroutine ("AddEnemy");
	}

	public void gameOver()
	{

		//if(_gameOverSound !=null)
		//{
			//_gameOverSound.Play ();
		//}
		//Setting life label in Heads Up Display
		//in UI in Non-active mode
		//Non-active means that this life label game object 
		//is disabled and it is not appeared in the scene.
		lifeLabel.gameObject.SetActive (false);

		//Setting score label in Heads Up Display
		//in UI in Non-active mode
		//Non-active means that this score label game object 
		//is disabled and it is not appeared in the scene
		scoreLabel.gameObject.SetActive (false);

		//diactivate the bird player on the scene

		bird.gameObject.SetActive (false);

		//Setting game over label in Heads Up Display
		//in UI in active mode
		//An active means that this Game Over label game object 
		//is enabled and is appeared in the scene.
		gameOverLabel.gameObject.SetActive (true);

		//Setting high score label in Heads Up Display
		//in UI in active mode
		//An active means that this high score label game object 
		//is enabled and is appeared in the scene.
		highScoreLabel.gameObject.SetActive (true);

		//Update the high score label with its highest score's counter variable from 
		//the Player's public property which is high score counter
		//that keeps track of the Bird_player's high score counter.
		highScoreLabel.text = "Highest Score: " +Player.Instance.HighScore + "\nYour Score: " +Player.Instance.Score; 

		//Setting reset button in Heads Up Display
		//in UI in active mode
		//An active means that the button game object 
		//is enabled and is appeared in the scene.
		resetBtn.gameObject.SetActive (true);

		//_bird.gameObject.SetActive (false);
		
	}

	//This function will apply change to the life 
	//and score labels by referencing the player class's
	//public score and life properties. The Player class
	//keeps the track of the score and life counters.
	public void updateUI()
	{
		//Update the score label with its score's counter from 
		//the Player's public property which is score counter
		//that keeps track of the Bird_player's score counter.
		scoreLabel.text = "Score: " + Player.Instance.Score;

		//Update the life label with its life's counter variable from 
		//the Player's public property which is life counter
		//that keeps track of the Bird_player's life counter.
		lifeLabel.text = "Life: " + Player.Instance.Life; 

	}
	// Use this for initialization
	void Start () 
	{

		//This establishes the link between 
		//the HUDController class and between
		//the Player class. This way the HUDController could access 
		//the Player's public score and life counter variables properties. 
		//This only works because the Player class has access of the HUDCOntroller 
		//class that is noted in the Player script code.
		//Without that this would not work.
		//Then the Player has to be intantiated in order for the
		//HUDController to communicate the score and life variable.
		//So, here the Player class is introduced to the HUDController class.
		Player.Instance.gameCtl = this;

		//Here the set up of the Audio Source. 
		//This Audio Source Component is accessed from this specific game object
		//which the script is attached to Canvas game object in the scene.
		//Basically, from this game object the Get Component is invoked which allows to 
		//access the Audio Source.
		//This is set up, so the specific methods could be applied to control 
		//this game object's Audio Source and invoke Play method when appropriate.
	//	_gameOverSound = gameObject.GetComponent<AudioSource> ();

		//The initialize function is called to display the appropriate 
		//UI labels in Heads Up Display in the scene.
		initialize();

		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	//This function is attached to the button gameobject
	//in order to invoke this appropriate event once the
	//button is clicked by the user.
	public void ResetBtnClick()
	{
		//This is simply creating a name of the current scene and reloading it
		//by invoking this function. This will get the active scene which 
		//is just the one we have here. It will reload it and get
		//the only scene that is stored in Unity. The start function would be called and
		//the inistialize function would be called 
		//Which will invoke the approapriate methods and the
		//game will start all over again with appropriate labels and its counters.
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);

	}

	//This coroutine will intantiate (create/clone) an enemy
	//game object onto the scene within a minute from the 
	//range of 30 seconds to 60 seconds
	private IEnumerator AddEnemy()
	{
		int time = Random.Range (30, 60);

		//The WaitForSeconds method is added to
		//delay certain amount of seconds untill it is hit the specified
		//time variable in amount of seconds till
		//the enemy game object is instantiated (added/created) onto
		//the scene.
		yield return new WaitForSeconds ((float)time);

		//Creates, clones the enemy game object onto the
		//scene
		Instantiate (enemy);

		//Recalls itself again to invoke this function again
		StartCoroutine ("AddEnemy");
	}
}
