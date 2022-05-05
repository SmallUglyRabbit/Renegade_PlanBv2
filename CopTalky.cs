using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


//A special script written for the police NPC in the TOWN level 

public class CopTalky : MonoBehaviour
{
 public TextMeshProUGUI NPCTXT;
 
 public TextMeshProUGUI ParasiteTXT; 
 
 public TextMeshProUGUI PlayerTXT; 
 
 void Start()
 {
     GlobalsScript.NPCFlagsArray[1] = false;
 }
  void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && GlobalsScript.NPCFlagsArray[1] == false) 
        {
                NPCTXT.text = GlobalStringText.NPCText[4];
        ParasiteTXT.text = GlobalStringText.ParasiteTalkStrings[38];
        PlayerTXT.text = GlobalStringText.PlayerTalkStrings[41];
        
        Debug.Log("COP touched the player");
              // Do something;
         GlobalsScript.NPCFlagsArray[1] = true; //Conversation triggers just once
        }
    }   
  
   
}
