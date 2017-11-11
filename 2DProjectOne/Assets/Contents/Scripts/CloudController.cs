using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The CloudController.cs script
 * Alisa Ordina
 * id: 100967526
 * October 22, 2017
 * 
 * This script component is attached to cloud game object in the prefab folder.
 * This following code applies tranformation allowing the 
 * cloud object to move in the right direction, horizontally in x axis.
*/

public class CloudController : MonoBehaviour 
{
	//Declaire public variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated horizontal x axis speed of the cloud object.
	[SerializeField] private float speed = 20f;

	//Declaire variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated game object that is called enemy
	[SerializeField] GameObject enemy;

	//This variable is from Unity the transform component 
	//The Trasform is defined in Unity as position, rotation and scale
	//Here it is going to be used for its coordinates, the position.
	private Transform _transform;

	//The private Vector2 is declaired 
	//later to be used to simply 
	//to track this game object's position in x and y axis.
	private Vector2 _currentPosition;

	//Declaire private variable
	//This variable is assigned to a designated Audio Source variable
	//private AudioSource _hit;


	// Use this for initialization
	void Start () 
	{

		//Here the set up of the Audio Source component. 
		//This Audio Source Component is accessed from this specific game object
		//which the script is attached to, the cloud game object in the scene.
		//Basically, from this game object the Get Component is invoked which allows to 
		//access the Audio Source.
		//This is set up so the specific methods could be applied to control 
		//this game object's Audio Source and invoke Play method when appropriate.
		//_hit = gameObject.GetComponent<AudioSource> ();

		//Here the set up of the Tranform. 
		//The Transform is accessed from this specific game object
		//which the script is attached to which is cloud game object in the scene.
		//Basically, from this game object the Get Component is invoked which allows to 
		//access the Transform which is scale, rotation and its position.
		//This is set up so the specific methods could be applied to control 
		//this game object's position in the scene.
		_transform = gameObject.GetComponent<Transform> ();

		//The _currentPosition will track the game object's position
		//here from _transform the position is invoked to access the game 
		//object's position in x and y coordinates
		//Update the game object's position
		_currentPosition = _transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{

		//In the update function that is executed per frame,
		//this is where it is good idea to move this game object 
		//and track its x and y coordinates. This is where
		//the boundaries are applied in order to reset this game object when it 
		//has reached the ending x axis point and reset it to the starting x axis
		//point in order for this star game object to stay in the camera view.

		//The _currentPosition will track the game object's position
		//here from _transform the position is invoked to access the game 
		//object's position in x and y coordinates.
		//This tracks the game object's position
		_currentPosition = _transform.position;

		//Once the _currentPosition gets updated with the object's 
		//current position with x and y coordinates.
		//Then Vector2 get invoked in order to move this
		//game object in the scene. The the plus sighn will move
		//this game object to the right, with specific predifined x axis speed.
		//This is applying movement only in x axis direction.
		_currentPosition += new Vector2 (speed, 0);

		//Check if this game object has reached its x axis boundary
		//point. If it has the CheckBounds() function gets called.
		CheckBounds ();

		//if the game object has not reached the 
		//x axis boundary point. Then
		//the game object position will be updated.
		//Update the game object's position
		_transform.position = _currentPosition;
		
	}

	/*public void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag.Equals ("enemy")) 
		{
			if (_hit != null) {
				_hit.Play ();
			}
		}
	}*/



	private void CheckBounds()
	{
		
		//If the game object's x axis position is greater than the 
		//x axis point is: 420 then Destroy the cloud game object.
		if(_currentPosition.x > 420)
		{
			//Setting the x axis boundary point
			_currentPosition.x = 420;

			//Destroy the cloud game object 
			//from the scene
			DestroyObject (this.gameObject);
			
		}
	}
}
