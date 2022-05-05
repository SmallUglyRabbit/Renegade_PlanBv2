using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupDiamond : MonoBehaviour
{
	[SerializeField] 
	public TextMeshProUGUI PlayerTalk;
	public TextMeshProUGUI ParasiteTalk;
	public GameObject TheTrigger;//This stores the trigger
	public Rigidbody2D Player_RigidBody; 
	public AudioSource PickupThisXPGem; 
	
	//This script executes when a player runs over the top of it. 
	//This item can be added to the inventory so that the player can use it and replenish their PSYpoints. 
		
	public void Start()
	{
		TheTrigger.SetActive(true);
		
	} 
	
 
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && FirstTimePickedUpScript.FirstXPGem == true)
		{
			PlayerTalk.text = "Wow, what is this? "; 
			ParasiteTalk.text = "... My Experience Gems, these are my memories.";
			FirstTimePickedUpScript.FirstXPGem = false;//Turns off this triggered text.  
			GlobalsScript.PlayerEXP += 5; 	
			PickupThisXPGem.Play();			
			
		}
		else
		{ 
			//Clear Text
			PlayerTalk.text = "";
			ParasiteTalk.text = ""; 
			GlobalsScript.PlayerEXP += 15; 	
			PickupThisXPGem.Play();
		}
			
		TheTrigger.SetActive(false);	
		 
	}
}
