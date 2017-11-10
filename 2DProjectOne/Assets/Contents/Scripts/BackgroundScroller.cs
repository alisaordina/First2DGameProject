using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The BackgroundScroller.cs script
 * Alisa Ordina
 * id: 100967526
 * October 21, 2017
 * This following script component is attached to scrollingBackgrounsEvn gameObject in the scene.
 * This following code applies tranformation to the game 
 * object allowing the background to move to the left in horizontal direction, in x axis.
*/

//This is the first script that was created for this game
//As noted in this script that, all scripts
//inherit from MonoBehaviour. Which ties in with Unity and
//this code could not only control this specific game object in the scene.
//Such as apply transformation like scale, rotate and position in x and y
//coordinates but it also exposes certain elements to Unity Inspector.

public class BackgroundScroller : MonoBehaviour 
{
	//Declaire private variables that would be accessible to Unity Inspector.
	//This variable is assigned to a designated scrolling speed of the 
	//background game object that is in the scene.
	[SerializeField] private float _speedScroller;

	//Declaire private variables that would be accessible to Unity Inspector.
	//This variable is assigned to a designated x axis starting point.
	//This is the starting x point where the background would start to move from.
	//This is were the background would reset itself, this is one of x axis boundary.
	[SerializeField] private float _startingPointX;

	//Declaire private variables that would be accessible to Unity Inspector.
	//This variable is assigned to a designated x axis ending point.
	//This is the background end x point and it is also a boundary 
	//point,this is where the background would 
	//apply reset function and start from the x starting point.
	[SerializeField] private float _endingPointX;

	//This variable is from Unity the transform component 
	//The Transform is defined in Unity as position, rotation and scale
	//Here it is going to be used for its coordinates, the position.
	private Transform _tranform;

	//The private Vector2 is declaired 
	//later to be used to simply 
	//to track this game object's movement position in x and y axis.
	private Vector2 _currentPosition;


	// Use this for initialization
	void Start () 
	{
		//Here the set up of the Tranform. This Transform is accessed from this specific game object
		//which the script is attached to which is background image game object in the scene.
		//Basically, from this game object the Get Component is invoked which allows to 
		//access the Transform which is scale, rotation and its position.
		//This is set up so the specific methods could be applied to control 
		//this game object's position in the scene.
		_tranform = gameObject.GetComponent<Transform> ();

		//The the _currentPosition will track the game object's position
		//here from _transform the position is invoked to access the game 
		//object's position in the x and y coordinates.
		_currentPosition = _tranform.position;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//In the update function that is executed per frame,
		//this is where it is good idea to move this game object 
		//and track its x and y coordinates. This is where
		//the boundaries are applied in order to reset this game object when it 
		//reached its ending x axis point and reset function is applied. 
		//The Reset function will start the background game object at the start x axis
		//point in order for this background image, game object to stay within the camera view.

		//The the _currentPosition will track the game object's position
		//here from _transform the position is invoked to access the game 
		//object's position in the x and y coordinates
		_currentPosition = _tranform.position;

		//Once the _currentPosition gets updated with the object's 
		//current position with x and y coordinates.
		//Then Vector2 get invoked in order to move this
		//game object in the scene. Then the minus sighn will move
		//this gameobject to the left, with the specific predifined x axis speed.
		//This is applying movement only in x axis direction.
		_currentPosition -= new Vector2 (_speedScroller, 0);

		//Here where the position of this game object gets to reset when the
		//ending x axis poing is reached.
		if(_currentPosition.x < _endingPointX)
		{
			//When this condition is true and game object has reached its x axis ending point
			//The reset function is invoked. This will reset this game
			//object position to the start x axis point.
			Reset ();
		}

		//If this game object has not reached its x axis ending point 
		//the game object position will be updated.

		_tranform.position = _currentPosition;

		
	}

	private void Reset()
	{
		//This is reseting the game object to its initial position.
		//Resetting this game object's position to the strating x axis point.
		_currentPosition = new Vector2 (_startingPointX, 0);
	}

}
