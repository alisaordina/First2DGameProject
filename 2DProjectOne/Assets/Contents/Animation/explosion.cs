using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Alisa Ordina
 * id: 100967526
 * October 21, 2017
 * 
 * The following script component is attached to red explosion gameObject in the prefab folder.
 * This following code applies the destroy method of this object 
 * in order to destroy this game object and remove it from the scene.
 * This is done at the end of the last red explosion's animation frame
*/
public class explosion : MonoBehaviour 
{
	//This function is public, so this could be declaired in unity's
	//animation window for the last, at the end of the frame of this game object's animation.
	public void DestroyMe()
	{
		//destroys, removes this red explosion game object from the scene.
		Destroy (gameObject);
	}

}
