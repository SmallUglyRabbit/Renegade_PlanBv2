using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupCoin : MonoBehaviour
{
	[SerializeField] 
	public TextMeshProUGUI PlayerTalk;
	public TextMeshProUGUI ParasiteTalk;
	public GameObject TheTrigger;//This stores the trigger
	public Rigidbody2D Player_RigidBody; 
	public AudioSource PickupThisCoin; 
	
	//This script executes when a player runs over the top of it. 
	//This item can be added to the inventory so that the player can use it and replenish their PSYpoints. 
		
	public void Start()
	{
		TheTrigger.SetActive(true);
		
	} 
	
 
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && FirstTimePickedUpScript.FirstCoin == true)
		{
			PlayerTalk.text = "...Money... now to find something to buy."; 
			ParasiteTalk.text = "... What is this thing?";
			FirstTimePickedUpScript.FirstCoin = false;//Turns off this triggered text.  
			GlobalsScript.PlayerMoneyTotal += 5; 	
			PickupThisCoin.Play();			
			
		}
		else
		{ 
			//Clear Text
			PlayerTalk.text = "";
			ParasiteTalk.text = ""; 
			GlobalsScript.PlayerMoneyTotal += 5; 	
			PickupThisCoin.Play();
		}
			
		TheTrigger.SetActive(false);	
		 
	}
	 
 
 

}
