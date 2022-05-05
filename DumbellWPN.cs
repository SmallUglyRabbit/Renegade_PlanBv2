using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DumbellWPN : MonoBehaviour
{
    public TextMeshProUGUI PlayerTalk; 
     public GameObject ThisWPN; 
    
    void  OnTriggerEnter2D(Collider2D other)
        {  if (other.tag == "Player" && GlobalsScript.WeaponsFlags[0] == false)
                PlayerTalk.text = GlobalStringText.PlayerTalkStrings[38];
            GlobalsScript.WeaponsFlags[0] = true; 
           
            ThisWPN.SetActive(false);
          
         }
}
