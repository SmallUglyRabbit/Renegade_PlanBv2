using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
public class StoryScript37 : MonoBehaviour
{
    [SerializeField] 
    public TextMeshProUGUI PlayerTalk;
    public TextMeshProUGUI GoalText;
    public TextMeshProUGUI ParasiteTalk;
    public GameObject TheTrigger;//This stores the trigger
    public Rigidbody2D Player_RigidBody;
  
  public string GoalTextString; 
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && GlobalsScript.StoryFlagsArray[37] == false) 
        {
            PlayerTalk.text = GlobalStringText.PlayerTalkStrings[47];
            ParasiteTalk.text = GlobalStringText.ParasiteTalkStrings[46];
            GoalText.text = GlobalStringText.GoalStrings[11];
            GlobalsScript.StoryFlagsArray[37] = true;
            
        }
    }   
     
}
