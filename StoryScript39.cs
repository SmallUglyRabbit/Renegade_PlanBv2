using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
public class StoryScript39 : MonoBehaviour
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
        if (other.tag == "Player" && GlobalsScript.StoryFlagsArray[38] == true) 
        {
            StarChargerTalk.text = GlobalStringText.StarChargerStrings[1];
            PlayerTalk.text = GlobalStringText.PlayerTalkStrings[45];
            ParasiteTalk.text =  GlobalStringText.ParasiteTalkStrings[42];  
            GoalTextString.Replace("<br>", "\n");
            GoalTextString = "Goals: Explore and locate the Star Charger <br> Meet the crew members";
            GoalText.text = GoalTextString;
            GlobalsScript.StoryFlagsArray[39] = true;
            
        }
    }   
     
}

