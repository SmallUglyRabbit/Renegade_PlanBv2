using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Script that executes when player steps over the StarCharger Dual Tooth weapon
public class DualTooth : MonoBehaviour
{
    public TextMeshProUGUI PlayerTalk; 
    public TextMeshProUGUI ParasiteTalk;
    public GameObject ThisWPN; 
    
    void  OnTriggerEnter2D(Collider2D other)
        {  if (other.tag == "Player")
                PlayerTalk.text = GlobalStringText.PlayerTalkStrings[36];
                ParasiteTalk.text = GlobalStringText.ParasiteTalkStrings[36];
                GlobalsScript.WeaponsFlags[2] = true; 
                ThisWPN.SetActive(false);
         }
}
