using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
public class StoryScript42 : MonoBehaviour
{
    [SerializeField] 
    public TextMeshProUGUI PlayerTalk;
    public TextMeshProUGUI GoalText;
    public TextMeshProUGUI ParasiteTalk; 
    public TextMeshProUGUI StarChargerTalk; 
    public GameObject TheTrigger;//This stores the trigger
    public Rigidbody2D Player_RigidBody;
  
    public string GoalTextString; 
     
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && GlobalsScript.StoryFlagsArray[42] == false) 
        {
            PlayerTalk.text =   GlobalStringText.PlayerTalkStrings[46];
            ParasiteTalk.text = GlobalStringText.ParasiteTalkStrings[45]; 
            StarChargerTalk.text = ""; 
            GlobalsScript.StoryFlagsArray[42] = true; 
            GoalText.text = GlobalStringText.GoalStrings[10]; 
        }       
    }        
     
}