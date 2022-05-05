using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupItemScript : MonoBehaviour

 { 
	[SerializeField] 
	public TextMeshProUGUI PlayerTalk;
	public TextMeshProUGUI ParasiteTalk;
	
	public GameObject TheTrigger;//This stores the trigger
	public Rigidbody2D Player_RigidBody; 
	

	
	 //This script will execute anytime the player picks up an item. 
	
	 
	 
	void Start()//Turns on this trigger
	{
		TheTrigger.SetActive(true);
		
	}
	 
	
 
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			//GlobalsScript.Inventory.Add()
			//this.Delay(4,ONDONE);
			TheTrigger.SetActive(false);
		}
	}
	
	}
 
