using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Component of the Parking Lot to open the doors. 
public class ParkingLotKeyTrigger : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI PlayerText;
    public TextMeshProUGUI ParasiteText;
    public GameObject ThisKey; 
      
      //Parking Lot Key
     void  OnTriggerEnter2D(Collider2D other)
        { 
                if (other.tag == "Player" && GlobalsScript.StoryFlagsArray[39] == false)
                PlayerText.text = GlobalStringText.PlayerTalkStrings[40];
                GlobalsScript.StoryFlagsArray[39] = true; 
                ThisKey.SetActive(false);
         }
}
