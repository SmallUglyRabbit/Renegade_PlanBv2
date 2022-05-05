using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This is the exit for the Sewer Level, it triggers the Town level to 
//load.
public class TriggerExitLevel : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && GlobalsScript.StoryFlagsArray[34] == true)
		{
            PlayerPrefs.Save(); 
			SceneManager.LoadScene(3);
			
		}
	}
}
