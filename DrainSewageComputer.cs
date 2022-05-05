using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrainSewageComputer : MonoBehaviour
{
    public TextMeshProUGUI parasiteTalk;
    public TextMeshProUGUI playerTalk;
    public TextMeshProUGUI GoalsText; 
    public AudioSource ComputerSounds;
    public GameObject Sewage;  
   // public bool switchedOn;
     
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && GlobalsScript.StoryFlagsArray[33]==false)
        {
           // switchedOn = true; 
           
            parasiteTalk.text = GlobalStringText.ParasiteTalkStrings[33];
            playerTalk.text = GlobalStringText.PlayerTalkStrings[33];
            GoalsText.text = GlobalStringText.GoalStrings[6];
            GlobalsScript.StoryFlagsArray[33] = true; 
            Sewage.SetActive(false);
            ComputerSounds.Play(); 
        }
        if(GlobalsScript.StoryFlagsArray[33]==true)
        {
            parasiteTalk.text = "";
            playerTalk.text = ""; 
              Sewage.SetActive(false);
            //do nothing
        }
        
        
    }
    void Update()
    {
     if(GlobalsScript.StoryFlagsArray[33]==true)
     {
     Sewage.SetActive(false);
     }
    }
    
}
