using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//This script trigger when the player moves over the 'StarCannon' on the Town Overworld map.
public class StarCannon_WPN_PickUp : MonoBehaviour
{
    public TextMeshProUGUI PlayerText; 
    public TextMeshProUGUI ParasiteText;
    public GameObject ThisCannon; 
    void  OnTriggerEnter2D(Collider2D other)
        { 
                if (other.tag == "Player")
                { 
                PlayerText.text = GlobalStringText.PlayerTalkStrings[43];
                ParasiteText.text = GlobalStringText.ParasiteTalkStrings[40];  
                GlobalsScript.WeaponsFlags[3] = true; 
                ThisCannon.SetActive(false);
                }
         }
}
