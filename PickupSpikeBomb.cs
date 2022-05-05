using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupSpikeBomb : MonoBehaviour
{
	[SerializeField] 
	public TextMeshProUGUI PlayerTalk;
	public TextMeshProUGUI ParasiteTalk;
	public GameObject TheTrigger;//This stores the trigger
	public Rigidbody2D Player_RigidBody; 
	public AudioSource PickupThisSpikeBomb; 

	
	//This script executes when a player runs over the top of it. 
	//This item can be added to the inventory so that the player can use it and replenish their PSYpoints. 
		
	public void Start()
	{
		TheTrigger.SetActive(true);
		
	} 
	
 
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && FirstTimePickedUpScript.FirstSpikeBomb == true)
		{
			PlayerTalk.text = "Is that thing looking at me? "; 
			ParasiteTalk.text = "Oh my pets, it's been too long. Careful Human they bite... and then explode.";
			FirstTimePickedUpScript.FirstSpikeBomb = false;//Turns off this triggered text.  
			GlobalsScript.SpikeBombsHeld += 1; 
			PickupThisSpikeBomb.Play();			
			
		}
		else
		{ 
			//Clear Text
			PlayerTalk.text = "";
			ParasiteTalk.text = ""; 
			GlobalsScript.SpikeBombsHeld += 1; 	
			PickupThisSpikeBomb.Play();
		}
			
		TheTrigger.SetActive(false);	
		 
	}
}
