﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace SimpleMan.CoroutineExtensions
{ 

	public class StoryScript18 : MonoBehaviour
	{
		[SerializeField] 
		public TextMeshProUGUI PlayerTalk;
		public TextMeshProUGUI ParasiteTalk;
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
		//This is independent of the trigger game object so each story script.cs would need to be different 
		//ala storyscript1 for this one storyscript2 for another. 
	
		void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Player" & GlobalsScript.StoryFlagsArray[17] == false)
			{
				PlayerTalk.text = GlobalStringText.PlayerTalkStrings[17];
				ParasiteTalk.text = GlobalStringText.ParasiteTalkStrings[17];
				//	Player_RigidBody.constraints = RigidbodyConstraints2D.FreezePosition;//Freeze till dialog is done	
		    GlobalsScript.StoryFlagsArray[17] = true;
			}
		}
		private void ONDONE()
		{
			Player_RigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;//Unfreeze
			
			
			 
		}
	
		private void StopTalking()
		{ 
		 //Changes the first story flag to false.
			
		}
		void FixedUpdate()
		{
 	}
	
     
	}
}
