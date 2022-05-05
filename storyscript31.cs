using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class storyscript31 : MonoBehaviour
{
	[SerializeField] 
	public TextMeshProUGUI PlayerTalk;
	public TextMeshProUGUI ParasiteTalk;
	public GameObject TheTrigger;//This stores the trigger
	public Rigidbody2D Player_RigidBody;
    public TextMeshProUGUI GoalsText; 
    public AudioSource computersounds; 


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
		if (other.tag == "Player" && GlobalsScript.StoryFlagsArray[31] == false)
		{
			PlayerTalk.text = GlobalStringText.PlayerTalkStrings[31];
			ParasiteTalk.text = GlobalStringText.ParasiteTalkStrings[31];
			GlobalsScript.StoryFlagsArray[31] = true;
            GoalsText.text = GlobalStringText.GoalStrings[4];
            computersounds.Play(); 
		}
	}
}
