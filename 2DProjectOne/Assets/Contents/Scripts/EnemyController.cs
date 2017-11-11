using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The EnemyController.cs script
 * Alisa Ordina
 * id: 100967526
 * October 22, 2017
 * 
 * This script component is attached to enemy game object in the scene.
 * This following code applies tranformation allowing the enemy game object
 * to move horizontally from x axis starting point 
 * and random y axis point and also with random minimum and maximum x and y speeds.
 * The random x and y axis position is applied with random speeds to the enemy object
 * in order to challenge the user.
*/

public class EnemyController : MonoBehaviour 
{
	
	//Declaire public variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated minimum horizontal x axis speed of the enemy
	//game object that is in the scene.
	[SerializeField] private float minSpeedX = 5f;

	//Declaire public variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated maximum horizontal x axis speed of the enemy
	//game object that is in the scene.
	[SerializeField] private float maxSpeedX = 25f;

	//Declaire public variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated minimum vertical y axis speed of the enemy
	//game object that is in the scene.
	[SerializeField] private float _minSpeedY = -2f;

	//Declaire public variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated maximum vertical y axis speed of the enemy
	//game object that is in the scene.
	[SerializeField] private float maxSpeedY = 15f;

	//Declaire public variables that would be accessible to Unity Inspector.
	//This variable is assigned to a designated y axis start point
	//which is one of the boundary points.
	//This is the start y axis point that is a top 
	//boundary point, where the enemy starts entering the camera view 
	//and stay within the camera's view scene.
	[SerializeField] private float startY = 233;

	//Declaire public variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated end y axis point
	//which is the bottom boundary point.
	//This is the end y axis point, which is a bottom boundary
	//where the enemy ends and resets.
	[SerializeField] private float endY = -235;

	//Declaire private variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated x axis start point
	//which is one of the boundary points.
	//This is the start x axis point that is at the right 
	//boundary point, where the enemy starts entering the camera view 
	//and stay within the camera's view scene.
	//[SerializeField] private float _startX = 378;

	//Declaire private variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated x axis which is the left boundary point.
	//This is the end x axis point is a left boundary x axis point where the enemy ends and resets.
	//[SerializeField] private float _endX = -399;

	//Declaire variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated game object that is called blueExplosion.
	[SerializeField] GameObject blueExplosion;

	//Declaire private variable
	//This variable is assigned to a designated AudioSource variable
	private AudioSource _fall;

	//This variable is from Unity the transform component 
	//The Trasform is defined in Unity as position, rotation and scale
	//Here it is going to be used for its coordinates, it is going to be used for the position.
	private Transform _tranform;

	//The private Vector2 is declaired 
	//later to be used to simply 
	//to track this game object's speed in x and y axis.
	private Vector2 _currentSpeed;

	//The private Vector2 is declaired 
	//later to be used to simply 
	//to track this game object's position in x and y axis.
	private Vector2 _currentPosition;

	// Use this for initialization
	void Start () 
	{
		//Here the set up of the Audio Source. This Audio Source Component is accessed from this specific game object
		//which the script is attached to, is the enemy game object in the scene.
		//Basically, from this game object the Get Component is invoked which allows to 
		//access the Audio Source.
		//This is set up, so the specific methods could be applied to control 
		//this game object's Audio Source and invoke Play method when appropriate.

		_fall = gameObject.GetComponent<AudioSource> ();

		//Here the set up of the Tranform. This Transform Component is accessed from this specific game object
		//which the script is attached to that is the enemy game object in the scene.
		//Basically, from this game object the Get Component is invoked which allows to 
		//access the Transform which is scale, rotation and its position.
		//This is set up so the specific methods could be applied to control 
		//this game object's position in the scene.

		_tranform = gameObject.GetComponent<Transform> ();

		//The _currentPosition will track the game object's position
		//here from _transform the position is invoked to access the game 
		//object's position in x and y coordinates
		_currentPosition = _tranform.position;

		//The reset function is invoked. This will reset this game
		//object's position to the start x axis point, 
		//random y axis point within its boundary and its random 
		//x and y speed
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
		//point in order for this enemy game object to stay in the camera's view.

		//The _currentPosition will track the game object's position
		//here from _transform the position is invoked to access the game 
		//object's position in x and y coordinates.
		//This tracks the game object's position.

		_currentPosition = _tranform.position;

		//The _currentPosition will track the game object's current speed
		//which is minus its _currentSpeed which means that it is in
		//left direction is applied for this game object.
		//Basically, setting up the speed of the game object where we want this
		//game object to be, the changes of the speed.
		_currentPosition -= _currentSpeed;

		//The the current position of the enemy which is _trasnform.position
		//will update to the _currentPosition with the indicated updated speed.
		//This change is applied to this game object
		_tranform.position = _currentPosition;

		//Checking the game object's boundaries.
		//Checking if the enemy game object is within its 
		//less than left x axis point which is -368 x point
		//It is checking if the enemy game object is less 
		//than the left x axis boundary point of the screen
		if(_currentPosition.x <= -368)
		{ 
			//If it is true and equals to the x axis point to: -368 point or less then reset
			//the enemy position and its speed

			Reset ();
		}
	}

	//The Reset function will do few things for this enemy game object.
	//First this function will reset the position of this game object
	//in order to stay within the camera view. So, move the enemy game object
	//back to its initial position when the enemy game object has hit 
	//its boundary x axis point.
	//This function will aso change this game object's speed as well.

	public void Reset()
	{
		//Setting up a random speed number withim the boundaries of maximum and
		//its minimum speed number of the enemy's speed in x axis direction.
		
		float xSpeed = Random.Range (minSpeedX, maxSpeedX);

		//Setting up a random speed number withim the boundaries of maximum and
		//its minimum speed number of the enemy's speed in y axis direction.
		float ySpeed = Random.Range (_minSpeedY, maxSpeedY);

		//applying the random x speed and random y speed into this enemy game oject
		_currentSpeed = new Vector2 (xSpeed, ySpeed);

		//Setting up a random y axis point within the y axis boundary of the camers's view
		float yAxis = Random.Range (startY, endY);

		//Apply the current position
		//which is the _trasform.position of the enemy
		//game object to an updated Random x axis and y axis points.
		//When setting up a new position to reset the enemy game object
		//position within the camera's view, the starting x axis point: 442 
		//is the x axis starting position,
		//then the added delay which will push the object to have some delay, 
		//so they appear in some way to the camera's view.
		//So, starting at 442 add some delay which allows this object
		//to not appear in the same spot, and push the object in x direction to the right. So
		//some delay would be occured before this object appears in the camera view with random
		//value from 1 to 40 and y would be a random point within its y axis boundary.
		_tranform.position = new Vector2 (442 + Random.Range(0, 40), yAxis);
	}

	//This is the function that would detect the collision with
	//this enemy game object. When Unity calculates that the enemy object
	//has intercepted with a different game object this function would be executed.
	//This is the fact that when the enemy object has intercepted with another
	//game object, it triggered (intercepted) with each other.
	//function is executed and the following conditions are invoked.
	public void OnTriggerEnter2D(Collider2D other)
	{
		//When the tags are created onto specific game objects, this is where
		//the tags are taken onto the advantage.
		//When the collision, the interception happened with another game object, 
		//this function is triggered and the condition statements 
		//are invoked which compares the game object's tags.
		//When the game object's tag is equal to cloud
		if (other.gameObject.tag.Equals ("cloud")) 
		{

			//setting up the audio sourse of the cloud's game component.
			AudioSource cloudAudioS = other.gameObject.GetComponent<AudioSource>();

			//If it is true and the intecepted game object's tag is equal to 
			//cloud then access the cloud game object's component 
			//which is Audio Source. If the cloud's Audio Source is assigned and not
			//eaquals to null, then this function gets invoked with its statement.
			if (cloudAudioS!= null) 
			{
				//If the cloud's Audio Source is set up and not null then 
				//play its attached audio clip.
				cloudAudioS.Play();
			}
			/*if (other.gameObject.GetComponent<AudioSource>()!= null) 
			{
				//If the cloud's Audio Source is set up and not null then 
				//play its attached audio clip.
				other.gameObject.GetComponent<AudioSource>().Play ();
			}*/

			//If the intercepted game object does equal to cloud then
			//instantiate, create a blue explosion game object on to the scene
			//within in the cloud object's position with its x and y coordinates.
			//The cloud object's position is accessed through its Transform component which 
			//gets the cloud's position, its coordinates.
			Instantiate (blueExplosion).GetComponent<Transform> ().position = other.gameObject.GetComponent<Transform> ().position;

			//other.gameObject.GetComponent<EnemyController> ().Reset ();
			//Destroy(this.gameObject);

			//When the collision with the cloud has happened, 
			//the enemy object gets to be reset. This 
			//is done when called the reset function
			//which resets the enemy position and its speed.
			Reset ();
		} 

		//If the trigger (intercept) happends with the game object's
		//tag named birdPlayer then this function get invoked
		else if (other.gameObject.tag.Equals ("birdPlayer")) 
		{
			//If the enemy game object's Audio source is assigned
			//and it is not null, this statement gets invoked
			if (_fall != null) 
			{
				//If the enemy Audio source component
				//is assigned and it is true
				//Then invoke the Audio source and
				//play its audio clip
				_fall.Play ();
			}
		}
	}
}
