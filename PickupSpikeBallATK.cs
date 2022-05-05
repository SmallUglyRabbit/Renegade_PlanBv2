using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupSpikeBallATK : MonoBehaviour
{
	[SerializeField] 
	public TextMeshProUGUI PlayerTalk;
	public TextMeshProUGUI ParasiteTalk;
	public GameObject TheTrigger;//This stores the trigger
	public Rigidbody2D Player_RigidBody; 
	public AudioSource PickupThisSpikeBallATK; 

	
	//This script executes when a player runs over the top of it. 
	//This item can be added to the inventory so that the player can use it and replenish their PSYpoints. 
		
	public void Start()
	{
		TheTrigger.SetActive(true);
		
	} 
	
 
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && FirstTimePickedUpScript.FirstSpikeBallATKGem == true)
		{
			PlayerTalk.text = "What do I do with this one? "; 
			ParasiteTalk.text = "Squeeze it, this will raise the damage we can do.";
			FirstTimePickedUpScript.FirstSpikeBallDEFGem = false;//Turns off this triggered text.  
			GlobalsScript.PlayerATK += 1; 	
			PickupThisSpikeBallATK.Play();			
			
		}
		else
		{ 
			//Clear Text
			PlayerTalk.text = "";
			ParasiteTalk.text = ""; 
			GlobalsScript.PlayerATK += 1; 	
			PickupThisSpikeBallATK.Play();
		}
			
		TheTrigger.SetActive(false);	
		 
	}
}
