using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The BirdController.cs script
 * Alisa Ordina
 * id: 100967526
 * October 21, 2017
 * 
 * The following script component is attached to Bird_Player gameObject in the scene.
 * This following code applies tranformation allowing the user to control their avatar
 * which is defined as Red_Player in the scene.
*/
public class BirdController : MonoBehaviour 

{
	//Declaire private variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated speed of the Bird_Player 
	//game object that is in the scene.
	[SerializeField] private float _speed = 3f;

	//Declaire private variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated x axis left boundary point.
	//This is the left x axis point boundary where the Bird_Player cannot cross over
	//in order to stay within the camera's view.
	[SerializeField] private float _leftX;

	//Declaire private variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated x axis right boundary point.
	//This is the right x axis point boundary where the Bird_Player cannot cross over
	//in order to stay within the camera's view.
	[SerializeField] private float _rightX;

	//Declaire private variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated y axis top boundary point.
	//This is the top y axis point boundary where the Bird_Player cannot cross over
	//in order to stay within the camera's view.
	[SerializeField] private float _topY;

	//Declaire private variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated y axis bottom boundary point.
	//This is the bottom y axis point boundary where the Bird_Player cannot cross over
	//in order to stay within the camera's view.
	[SerializeField] private float _bottomY;

	//[SerializeField] GameObject redExplosion;

	//Declaire variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated game object that is called cloud
	[SerializeField] GameObject cloud;

	//This variable is from Unity the transform component 
	//The Transform is defined in Unity as position, rotation and scale
	//Here it is going to be used for its coordinates, it is going to be used for the position.
	private Transform _tranform;

	//The private Vector2 is declaired 
	//later to be used to simply 
	//to track this game object's movement position in x and y axis.
	private Vector2 _currentPosition;



	// Use this for initialization
	void Start () 
	{
		//Here the set up of the Tranform. This Transform is accessed from this specific game object
		//which the script is attached to Bird_Player game object in the scene.
		//Basically, from this game object the Get Component is invoked which allows to 
		//access the Transform which is scale, rotation and its position.
		//This is set up so the specific methods could be applied to control 
		//this game object's position in the scene.
		_tranform = gameObject.GetComponent<Transform> ();

		//The the _currentPosition will track the game object's position
		//here from _transform the position is invoked to access the game 
		//object's position in x and y coordinates
		_currentPosition = _tranform.position;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//In the update function that is executed per frame,
		//this is where it is good idea to apply update position of this game object 
		//and track its x and y coordinates. This is where
		//the controllers of the gameobject is applied and the 
		//boundaries are applied in order to keep this game object within its boundaries
		//in x left and x right points and y bottom and y top boundaries in order to stop
		//this game object from crossing its specified boundaries points in 
		//order for this game object to stay within the camera's view.

		//The the _currentPosition will track the game object's position
		//here from _transform the position is invoked to access the game 
		//object's position in x and y coordinates.

		_currentPosition = _tranform.position;

		//The Input is a class defined in Unity API and 
		//here it is used as a user's input. For example using the keyboard and
		//keybpard's keys. This is where the Input get invoked and indicates
		//which key is pressed in order to this method to occur. When the user's
		//input is registered, the specific condition should be invoked in order
		//to invoke the specific state condition.
		//Here the hardcoding of the specific keys is applied 
		//in order to apply the specific
		//tranformation of this game object.
		//When the key is pressed, this invokes the key event. 
		//The GetKey is a general event, this event occurs when this
		//specific key is pressed, it will return true, while the USER is
		//HOLDING the identified key with the name of that key which is indicated
		//by the KeyCode enum parameter. This method is invoked while user holds the
		//identified key and this game object will be moved with either in vertical direction
		//or horizontal direction, depending on the identity of the key.

		if(Input.GetKey(KeyCode.A))
		{
			
			//Once the _currentPosition gets updated with the object's 
			//current position with x and y coordinates.
			//Then Vector2 get invoked while user is pressing the A key. 
			//While this return to true, the movement 
			//in the left direction of this game object 
			//is applied with specified speed, horizontally.
			//Then the minus sighn will move
			//this game object to the left, with specific predifined speed.
			//This is applying movement only in x axis direction.

			_currentPosition -= new Vector2 (_speed, 0);
		}

		if(Input.GetKey(KeyCode.D))
		{


			//The Vector2 get invoked while user is pressing the D key. 
			//While this return to true, the movement of this game object 
			//is applied with specified speed, horizontally.
			//Then the plus sighn will move
			//this game object to the right, with specific predifined speed.
			//This is applying movement only in x axis direction.

			_currentPosition += new Vector2 (_speed, 0);
		}

		if(Input.GetKey(KeyCode.W))
		{
			

			//The Vector2 get invoked while user is pressing the W key. 
			//While this return to true, the movement of this game object 
			//is applied with specified speed, vertically.
			//Then the plus sighn will move
			//this game object up, with specific predifined speed.
			//This is applying movement only in y axis direction.

			_currentPosition += new Vector2 (0, _speed);
		}

		if(Input.GetKey(KeyCode.S))
		{


			//The Vector2 get invoked while user is pressing the S key. 
			//While this return to true, the movement of this game object 
			//is applied with specified speed, vertically.
			//Then the minus sighn will move
			//this game object down, with specific predifined speed.
			//This is applying movement only in y axis direction.

			_currentPosition -= new Vector2 (0, _speed);
		}

		if(Input.GetKeyDown(KeyCode.Space))
		{


			//The Vector2 get invoked when the user has pressed the space bar key. 
			//When this returns true, this game object will intantiate (create) a cloud
			//game object, that represents the Bird_Player's fire, the defence againt the enemy.
			//First the Bird_Player game object's tranform gets accessed to get
			//the x and y coordinates of the Bird_Player's position.
			//Storing the current Bird_Player's position in Vector2 positionOfBird variable 

			Vector2 positionOfBird = new Vector2 (_tranform.position.x, _tranform.position.y);

			//Then Intansiate the cloud game object onto the Bird_Player's position from the
			//positionOfBird Vector2 variable, without any rotation. 
			//Without any rotation the Quaternion.identity is applyied for defult no rotation.

			Instantiate (cloud, positionOfBird, Quaternion.identity);


		}

		//Check the Bird_Player's boundaries if the following x axis boudary or y axis boundary 
		//are not crossed by this game object.
		//So, the Bird_Player could not leave the came view.
		CheckBounds ();

		//If this game object has not reached its x and y boundaries
		//the game object position will be updated.
		_tranform.position = _currentPosition;

		
	}

	//This function is invoked to make this game object appear within its boudaries
	//and not leave or cross its predifined bondary points, in order to stay in the came view.
	//Basically, this function makes sure that the Bird_Player sprite remains on screen at all times.

	private void CheckBounds()
	{
		//Checking if the Bird_Player is within its less than left x axis point
		//It is checking if the Bird_Player is less than the left x axis point of the screen.

		if (_currentPosition.x < _leftX) 
		{
			//If its at that the left x axis point apply left axis point,
			//let game object to stay within its left x axis point.
			//If true, moves the player back on screen || resets the Bird_Player to the left most position.

			_currentPosition.x = _leftX;
		}

		//Checking if the Bird_Player is within its greater than right x axis point.
		//It is checking if the Bird_Player is greater than the right x axis point of the screen.

		if (_currentPosition.x > _rightX) 
		{
			//If its at that the right x axis point apply right axis point,
			//let game object to stay within its right x axis point.
			//If true, moves the player back on screen || resets the Bird_Player to the right most position.

			_currentPosition.x = _rightX;
		}

		//Checking if the Bird_Player is within its greater than top y axis point.
		//It is checking if the Bird_Player is greater than the top y axis point of the screen.

		if (_currentPosition.y > _topY) 
		{
			//If its at that the top y axis point apply top y axis point,
			//let game object to stay within its top y axis point.
			//If true, moves the player back on screen || resets the Bird_Player to the top y most position.

			_currentPosition.y = _topY;
		}

		//Checking if the Bird_Player is within its less than bottom y axis point.
		//It is checking if the Bird_Player is less than the bottom y axis point of the screen.

		if (_currentPosition.y < _bottomY) 
		{
			//If its at that the bottom y axis point apply bottom y axis point,
			//let game object to stay within its bottom y axis point.
			//If true, moves the player back on screen || resets the Bird_Player to the bottom y most position.

			_currentPosition.y = _bottomY;
		}

	}
}
