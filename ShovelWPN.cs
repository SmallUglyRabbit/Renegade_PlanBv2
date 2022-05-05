using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//This script trigger when the player moves over the 'Shovel' on the Sewer Overworld map. 
public class ShovelWPN : MonoBehaviour
{
  
  
    [SerializeField]
    public TextMeshProUGUI PlayerTalk;  
    public GameObject ThisWPN; 
    
  
    void  OnTriggerEnter2D(Collider2D other)
        { 
                if (other.tag == "Player")
                PlayerTalk.text = GlobalStringText.PlayerTalkStrings[37]; 
                GlobalsScript.WeaponsFlags[1] = true; //Adds the Shovel stat upgrades and attack animation
                ThisWPN.SetActive(false);
         }
}

