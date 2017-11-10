using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The singlenton
 * Player.cs script
 * Alisa Ordina
 * id: 100967526
 * October 22, 2017
 * 
 * This is a singleton class that will keep track of
 * score and life counters. A singleton class means that
 * only a single Player class copy could exist in this system.
 * For example if the second level is reloaded the player class 
 * could still exist and cannot be intantiated again.
 * This class will take some resposibility of the HUDController
 * because of this class's capabilities. This class could be
 * carried over to other levels if it was possible in this game. 
 * So, this class is implemented in a way that cannot be instantiated 
 * any where else just inside this class. This is done by private constructor.
 * 
*/
public class Player 
{

	//private Player declaired under _instance variable
	static private Player _instance;

	//So, this class is implemented in a way that cannot be instantiated 
	 //any where else just inside this class. This is done by private constructor.
	static public Player Instance
	{
		get 
		{
			//This condition checks if the Player class
			//exists if it does not exist this condition is invoked
			if(_instance == null)
			{
				//construct a new Player object with
				//its default contructor
				_instance = new Player ();
			}
			//return the Player's class intance
			return _instance;
		}
	}

	//Player default contructor
	private Player()
	{
	}

	//The HUDController class is added
	//This is for Player class to access the HUDController class 
	//in order to apply the HUDController's methods
	//It basically establishes a link a communication between 
	//Player and the HUDController class.
	public HUDController gameCtl;

	//setting up the score variable
	private int _score;

	//setting up the life variable
	private int _life;

	//Player's public property
	//Using the get (read) and set property
	//to update the score variable
	public int Score
	{
		//reading the score
		get 
		{
			return _score;
		}
		//setting the score to the new value
		set
		{
			_score = value;

			//scoreLabel.text = "Score: " + _score;
			//This will call the HUDController's
			//method called update UI in order to update 
			//the score label
			gameCtl.updateUI();
		}
	}

	//Player's public property
	//Using the get (read) and set property
	//to update the life variable
	public int Life
	{
		//reading the life counter variable
		get 
		{
			return _life;
		}
		//setting up a new value for the life variable
		set
		{
			_life = value;

			//If life has been dipleated
			if (_life <= 0) 
			{
				//If it is true
				//This will call the HUDController's
				//method called gameOver method in order to  
				//display the specific UI onto the scene
				gameCtl.gameOver ();
			} 
			else 
			{
				//If the life couter has not been dipleated
				//This will call the HUDController's
				//method called updateUI method in order to  
				//update the life label in the UI onto the scene
				gameCtl.updateUI ();
			}
		}
	}
}
