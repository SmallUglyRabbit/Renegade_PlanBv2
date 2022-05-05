using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
//namespace SimpleMan.CoroutineExtensions

//Each story script is used to take advantage of the TEXT ANIMATOR ASSET which 
//doesn't exactly work like it should. The instructions say to just add 
//certain tags but then including the namespace or whatever doesn't give access 
//to the objects required to utilize the co-routines. 



public class StoryScript : MonoBehaviour
{
	[SerializeField] 
	public TextMeshProUGUI PlayerTalk;
	public TextMeshProUGUI ParasiteTalk;
	public TextMeshProUGUI GoalText; 
	public GameObject TheTrigger;//This stores the trigger
	public Rigidbody2D Player_RigidBody; 
	

	
	//This script will be a template. Everytime the player steps on a trigger for dialog, a version of this 
	//script will execute. It will init the trigger, check if the player has entered on to it and 
	//in order to check a condition, will check a global flag to see if it needs to fire or will 
	//set a flag.
	
	//This is the first story script.
	 
	void Start()//Turns on this trigger
	{
		TheTrigger.SetActive(true);
		
	}
	 
	
 
	
	 void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && GlobalsScript.StoryFlagsArray[0] == false)
		{
			PlayerTalk.text = GlobalStringText.PlayerTalkStrings[0]; 
			ParasiteTalk.text = GlobalStringText.ParasiteTalkStrings[0];
	        GoalText.text = GlobalStringText.GoalStrings[0];
	 	 
	        GlobalsScript.StoryFlagsArray[0] = true; 
		}
		 
	}
	 
   


}
	
