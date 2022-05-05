using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the trigger for the vending machine screen to turn on infront of the player. 
public class VendingMachineTrigger : MonoBehaviour
{
	public Canvas ShopScreen; 
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			ShopScreen.enabled = true; 
		}
	}
			
}
