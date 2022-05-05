using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




	public class StoryScript6 : MonoBehaviour
	{
		[SerializeField] 
		public TextMeshProUGUI PlayerTalk;
		public TextMeshProUGUI ParasiteTalk;
		public TextMeshProUGUI GoalsText;
		public GameObject TheTrigger;//This stores the trigger
		public Rigidbody2D Player_RigidBody;
	
//This script is strange, the inspector goes a bit nuts  when editing it, might be a glitch in unity. Use
//the second line down to edit the one about it in some areas.

		//This script will be a template. Everytime the player steps on a trigger for dialog, a version of this 
		//script will execute. It will init the trigger, check if the player has entered on to it and 
		//in order to check a condition, will check a global flag to see if it needs to fire or will 
		//set a flag.
	
		//This is the first story script.
	 //This just sets a freeze position. 
	 
		public void press()
		{
			if(Input.anyKey)
			{
				Player_RigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;//Unfreeze

			}
			else
			{
				Player_RigidBody.constraints = RigidbodyConstraints2D.FreezePosition;//Freeze till dialog is done	
				
			}
		}
		void  OnTriggerEnter2D(Collider2D other)
		{  if (other.tag == "Player" && GlobalsScript.StoryFlagsArray[5] == false)
     			PlayerTalk.text = GlobalStringText.PlayerTalkStrings[5];
				ParasiteTalk.text = GlobalStringText.ParasiteTalkStrings[5];
				GoalsText.text = GlobalStringText.GoalStrings[1];
                GlobalsScript.StoryFlagsArray[5] = true;
				//	press();
				//	Player_RigidBody.constraints = RigidbodyConstraints2D.FreezePosition;//Freeze till dialog is done	
				//	this.Delay(3, ONDONE);
			} }
	
     //Story Script begins with 6 and ends with 34 from sewermaze.
	
