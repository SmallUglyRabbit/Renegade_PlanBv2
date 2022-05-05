using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 

 

public class StoryScript36 : MonoBehaviour
{
    [SerializeField] 
    public TextMeshProUGUI PlayerTalk;
    public TextMeshProUGUI GoalText;
    public TextMeshProUGUI ParasiteTalk;
    public GameObject TheTrigger;//This stores the trigger
    public Rigidbody2D Player_RigidBody;
  
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && GlobalsScript.StoryFlagsArray[35]==true && GlobalsScript.StoryFlagsArray[36] == false) 
        {
            PlayerTalk.text = GlobalStringText.PlayerTalkStrings[42];
            ParasiteTalk.text = GlobalStringText.ParasiteTalkStrings[39];
            GoalText.text = GlobalStringText.GoalStrings[8];
            GlobalsScript.StoryFlagsArray[36] = true;
            
        }
    }   
     
}


//
 
             
             
