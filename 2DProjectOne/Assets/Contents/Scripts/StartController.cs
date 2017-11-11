using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*StartController.cs script
 * supposed to be name StarController script
 * Alisa Ordina
 * id: 100967526
 * October 22, 2017
 * 
 * This script component that is attached to the star game object in the scene.
 * This following code applies tranformation allowing the 
 * star to move horizontally in x axis.
*/

public class StartController : MonoBehaviour 

{

	//Declaire public variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated horizontal x axis speed of the star
	//the game object that is in the scene.
	[SerializeField] private float speed = 20f;

	/*[SerializeField] private float _startY;

	[SerializeField] private float _endY;

	[SerializeField] private float _startX;

	[SerializeField] private float _endX;*/

	//This variable is from Unity the transform component 
	//The Trasform is defined in Unity as position, rotation and scale
	//Here it is going to be used for its coordinates, the position.
	private Transform _transform;

	//private Vector2 _currentSpeed;

	//The private Vector2 is declaired 
	//later to be used to simply 
	//to track this game object's movement position in x and y axis.
	private Vector2 _currentPosition;




	// Use this for initialization
	void Start () 
	{

		//Here the set up of the Tranform. This Transform is accessed from this specific game object
		//which the script is attached to which is the star game object in the scene.
		//Basically, from this game object the Get Component is invoked which allows to 
		//access the Transform which is scale, rotation and its position.
		//This is set up, so the specific methods could be applied to control 
		//this game object's position in the scene.
		_transform = gameObject.GetComponent<Transform> ();

		//The _currentPosition will track the game object's position
		//here from _transform the position is invoked to access the game 
		//object's position in the x and y coordinates
		//Basically update the position
		_currentPosition = _transform.position;

		//Reset is applied in order to keep this 
		//game object within the camera's view
		Reset ();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//In the update function that is executed per frame,
		//this is where it is good idea to move this game object 
		//and track its x and y coordinates. This is where
		//the boundaries are applied in order to reset this game object when it 
		//reached the ending x axis point and reset this game object to the starting x axis
		//point in order for this star game object to stay in the camera's view.

		//The _currentPosition will track the game object's position
		//here from _transform the position is invoked to access the game 
		//object's position in x and y coordinates.
		//This tracks the game object's position.

		_currentPosition = _transform.position;

		//Once the _currentPosition gets updated with the object's 
		//current position with x and y coordinates.
		//Then Vector2 get invoked in order to move this
		//game object in the scene. Then the minus sighn will move
		//this gameobject to the left, with specific predifined x axis speed.
		//This is applying movement only in x axis direction.
		_currentPosition -= new Vector2 (speed, 0);

		//If the game object's x axis position is less than of 
		//x axis point is: -422 then Reset function is applied
		//The -422 is the ending x axis point of this game object and then reset
		//is applied to reset this game object to the starting x axis point.
		if(_currentPosition.x < -422)
		{
			//When the star game object's position is 
			//the x axis is less than -422.
			//The Reset function gets invoked which resets the star game object
			//into its initial start x axis point.
			Reset ();
			
		}

		//If this gameobject has not reached its x axis ending point 
		//the game object position will be updated.
		_transform.position = _currentPosition;

		
	}

	//Reset function that would reset the game object's position.
	public void Reset()
	{
		//Getting a random y axis point within the y axis boundary.
		float yAxis = Random.Range (-253, 238);

		//This resets the game object to the initial x axis position,
		//while y axis is a random y axis point within its y axis boundary.
		//Resetting this game object's position to the strating x axis point with y random point.
		_currentPosition = new Vector2 (439, yAxis);
	}

}
