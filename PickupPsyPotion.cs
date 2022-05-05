using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class PickupPsyPotion : MonoBehaviour
{
 
	 
		[SerializeField] 
		public TextMeshProUGUI PlayerTalk;
		public TextMeshProUGUI ParasiteTalk;
	
		public GameObject TheTrigger;//This stores the trigger
		public Rigidbody2D Player_RigidBody; 
        
	
		//This script executes when a player runs over the top of it. 
		//This item can be added to the inventory so that the player can use it and replenish their PSYpoints. 
		
		public void Start()
		{
			TheTrigger.SetActive(true);
		
		} 
	
 
	
	 void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Player" && FirstTimePickedUpScript.FirstPsy == true)
			{
				ParasiteTalk.text = "Drink this when you need to replenish your Psy strength!";
				PlayerTalk.text = "...replenish my what?"; 
			FirstTimePickedUpScript.FirstPsy = false;//Turns off this triggered text.  
                GlobalsScript.PlayerCurrentPsyPoints = GlobalsScript.PlayerCurrentMAXPsyPoints;
                TheTrigger.SetActive(false);
             
             }
		}
	 
 
 

	}
 
