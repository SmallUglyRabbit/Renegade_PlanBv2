using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class PickupSpikeBallDEF : MonoBehaviour
{
 [SerializeField] 
	public TextMeshProUGUI PlayerTalk;
	public TextMeshProUGUI ParasiteTalk;
	public GameObject TheTrigger;//This stores the trigger
	public Rigidbody2D Player_RigidBody; 
	public AudioSource PickupThisSpikeBallDEF; 

	
	//This script executes when a player runs over the top of it. 
	//This item can be added to the inventory so that the player can use it and replenish their PSYpoints. 
		
	public void Start()
	{
		TheTrigger.SetActive(true);
		
	} 
	
 
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && FirstTimePickedUpScript.FirstSpikeBallDEFGem == true)
		{
			PlayerTalk.text = "Ouch, what the heck is this? "; 
			ParasiteTalk.text = "Swallow it, these pills are designed to make us tougher.";
			FirstTimePickedUpScript.FirstSpikeBallDEFGem = false;//Turns off this triggered text.  
			GlobalsScript.PlayerDEF += 1; 	
			PickupThisSpikeBallDEF.Play();			
			
		}
		else
		{ 
			//Clear Text
			PlayerTalk.text = "";
			ParasiteTalk.text = ""; 
			GlobalsScript.PlayerDEF += 1; 	
			PickupThisSpikeBallDEF.Play();
		}
			
		TheTrigger.SetActive(false);	
		 
	}
	
}
