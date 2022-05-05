using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandCannon : MonoBehaviour
{
    public TextMeshProUGUI PlayerText; 
    public TextMeshProUGUI ParasiteText;
    public GameObject ThisCannon; 
    void  OnTriggerEnter2D(Collider2D other)
    { 
        if (other.tag == "Player")
        { 
            PlayerText.text = GlobalStringText.PlayerTalkStrings[48];
            ParasiteText.text = GlobalStringText.ParasiteTalkStrings[47];  
            GlobalsScript.WeaponsFlags[4] = true; 
            ThisCannon.SetActive(false);
        }
    }
}

