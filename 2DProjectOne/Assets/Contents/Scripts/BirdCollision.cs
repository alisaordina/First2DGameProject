﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The BirdCollision.cs script
 * Alisa Ordina
 * id: 100967526
 * October 23, 2017
 * 
 * This script component is attached to Bird_Player gameObject in the scene.
 * This following code applies collision function to this game object.
 * And adds effects to the Bird_Player game object when the collision 
 * between the Bird_Player and enemy happends.
*/
public class BirdCollision : MonoBehaviour 
{
	//Declaire variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated game object that is called HUDController
	//from HUDController script that is attached to canvas game object
	[SerializeField] HUDController gameCtl;

	//Declaire variable that would be accessible to Unity Inspector.
	//This variable is assigned to a designated game object that is called explosion
	[SerializeField] GameObject explosion;

	//Declaire private variable
	//This variable is assigned to a designated AudioSource variable
	private AudioSource _starSoud;



	// Use this for initialization
	void Start () 
	{

		//Here the set up of the Audio Source. 
		//This Audio Source Component is accessed from this specific game object
		//which the script is attached to Bird_Player game object in the scene.
		//Basically, from this game object the Get Component is invoked which allows to 
		//access the Audio Source.
		//This is set up, so the specific methods could be applied to control 
		//this game object's Audio Source and invoke Play method when appropriate.
		_starSoud = gameObject.GetComponent<AudioSource> ();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	//This is the function that would detect the collision with
	//this Bird_Player game object. When Unity calculates that the enemy object
	//has intercepted with a different game object this function would be executed.
	//This is the fact that when the Bird_Player object has intercepted with another
	//game object it triggered (intercepted) with each other.
	//This function is executed and the follwoing conditions are invoked.
	public void OnTriggerEnter2D(Collider2D other)
	{
		//When the tags are created onto specific game objects, this is where
		//the tags are taken onto the advantage.
		//When the collision happends, the interception with the another game object happends
		//this function is triggered and the condition statements 
		//are invoked which compares the game object's tags.
		//When the game object's tag is equal to star
		if(other.gameObject.tag.Equals("star"))
		{

			//If it is true and the game object has intercepted the 
			//star game object with its defined tag of star.
			//Then log it on to the screen that the intercept
			//has happened with the star.
			Debug.Log ("Collision With The Star\n");

			//If the Bird_Player game object's Audio Source is assigned
			//and does not equal to null,
			//then this function gets invoked with its statement.
			if(_starSoud != null)
			{
				//If the Bird__player has Audio Source set up then 
				//play its attached audio clip
				_starSoud.Play ();
			}
			//When the Bird_Player has intercepted with the
			//star game object. The Bid_Player's points 
			//adds a 100 points
			//to its current score.
			//Since the HUDController script has access to the Player
			//class. The Player's public property could be
			//used to update the score counter and increase the value
			//by 100 points.
			Player.Instance.Score += 100;

		}

		//If the collision happends, the interception with another game object's 
		//defined tag as enemy this function is triggered and the condition statements 
		//are invoked which compares the game object's tags.
		//When the game object's tag is equal to an enemy.
		else if(other.gameObject.tag.Equals("enemy"))
		{

			//If it is true and the game object has intercepted the 
			//enemy game object with its defined tag of enemy. 
			//Then log it on to the screen that the intercept
			//has happened with the enemy.
			Debug.Log ("Collision With The Enemy\n");


			//If the intercepted game object does equal to enemy then
			//intansiate, create a red explosion game object on to the scene
			//within the enemy game object's position x and y coordinates. 
			//The enemy object's position is accessed through its Transform component which 
			//gets the enemy object's position, its coordinates.
			Instantiate (explosion).GetComponent<Transform> ().position = other.gameObject.GetComponent<Transform> ().position;

			//Because the collision (intercept) has happenned with the enemy
			//game object. Then the enemy game object is reset
			//This is done by accessing the tag's game object
			//and accessing, getting its component which is its script called
			//Enemy Controller and from that script invoke Reset function 
			//on to the enemy game object that had been intercepted with 
			//the Bird_Player.
			//This will make enemy disapear when collision with the
			//Bird_Player had happened.
			other.gameObject.GetComponent<EnemyController> ().Reset ();

			//Since the Bird_Player 
			//has intercepted with the enemy game object 
			//the Bird_Player's life would be decressed by 1 point.
			//Since the HUDController script has access to the Player
			//class. The Player's public property could be
			//used to update the life counter and decrese the value
			//by one point.
			Player.Instance.Life--;

			//Since the Bird_Player 
			//has intercepted with the enemy game object 
			//the coroutine function Blink() would be called.
			//To add color to the Bird_Player material to make the
			//game object blink with its apprence.
			//Calling simply by startCoroutine(function name)
			//by its name simply calls the couritine function.
			StartCoroutine("Blink");
		}
	}

	//This function will consist of fading the
	//game object it means gradually reducing 
	//an object's alpha (opasity) value until it because invisible
	//The in order for the fading to be visible alpha must be reduced over
	//a sequence of frames and then after curtain seconds this game object
	//will appear.
	//The coroutine is applied that returns the
	//IENumerator in order to step in and out and to
	//do the blinking of this game object.
	private IEnumerator Blink()
	{
		//declairing color
		Color c;

		//accessing this game object's components which is render
		//and storing it in the renderer variable.
		//Render is a component that allows to access and modify how the
		//sprite is rendered on the screen.
		//The renderer has a material which has colors that is 
		//can be painted over the game object. This material handles its colors.
		//So, through the render's material, can access the color
		//and play with the invisibility/transperancy apha (opasity) of this game object
		//of this sprite.
		Renderer renderer = gameObject.GetComponent<Renderer> ();

		//So this code starts with fully opaque 
		//Also this code delays the blinking 
		//by invoking waitforseconds
		//This slows the blinking down.
		//The blinking will happened only 3 times.
		for(int i =0; i <3; i++)
		{
			//since the invisibility in invoked the
			//whole loop in one frame rate the second
			//loop is also initialized and in the
			//next loop in the next frame the object should be visible
			for(float f = 1f; f >= 0; f -= 0.1f)
			{

				//accessing the material from the 
				//specific game object from its renderer
				//component.
				c = renderer.material.color;

				//setting up, updating its material's color of that game object
				c.a = f;

				//apply the updated color to the game object
				renderer.material.color = c;

				//Yield allows to get back to this loop 
				//it is similar to step in and out from the loop.
				yield return new WaitForSeconds (.1f);
			}
			//Apllying visibility to the game object to 
			//makeit visible in the next frame.
			for(float f = 0; f <= 1; f +=0.1f)
			{

				//accessing the material from the 
				//specific game object from its renderer
				//component.
				c = renderer.material.color;

				//setting up, updating its material's color of that game object
				c.a = f;

				//apply the updated color to the game object
				renderer.material.color = c;

				//Yield allows to get back to this loop 
				//it is similar to step in and out from the loop.
				yield return new WaitForSeconds (.1f);
			}
		}
	}
}
