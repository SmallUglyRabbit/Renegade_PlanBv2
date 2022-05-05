using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupLifeGem : MonoBehaviour
{
	
	[SerializeField] 
	public TextMeshProUGUI PlayerTalk;
	public TextMeshProUGUI ParasiteTalk;
	
	public GameObject TheTrigger;//This stores the trigger
	public Rigidbody2D Player_RigidBody; 
	public AudioSource LifeGemSound; 
    // Start is called before the first frame update
    void Start()
    {
	    TheTrigger.SetActive(true);
		
    } 
	
 
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && FirstTimePickedUpScript.FirstLifeGem == true)
		{
			PlayerTalk.text = "It's beautiful, what is it? "; 
			ParasiteTalk.text = "... My... Our, life force. ";
			FirstTimePickedUpScript.FirstLifeGem = false;//Turns off this triggered text.  
			GlobalsScript.PlayerCurrentMAXHP += 5; 	
			LifeGemSound.Play();			
			
		}
		else
		{ 
			//Clear Text
			PlayerTalk.text = "";
			ParasiteTalk.text = ""; 
			GlobalsScript.PlayerCurrentMAXHP += 5; 	
			LifeGemSound.Play();
		}
			
		TheTrigger.SetActive(false);	
		 
	}
 }
  
