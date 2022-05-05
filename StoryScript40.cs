using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
public class StoryScript40 : MonoBehaviour
{
    [SerializeField] 
    public TextMeshProUGUI PlayerTalk;
    public TextMeshProUGUI GoalText;
    public TextMeshProUGUI ParasiteTalk;
    public TextMeshProUGUI StarChargerTalk; 
    public GameObject TheTrigger;//This stores the trigger
    public Rigidbody2D Player_RigidBody;
  
    public string GoalTextString; 
    public GameObject Pond1Barrier, Pond2Barrier, Pond3Barrier; 
    public GameObject StarChargerBridge; 
    public GameObject Auggers; 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && GlobalsScript.StoryFlagsArray[39] == true) 
        {
            PlayerTalk.text = "{fade}You come from another dimension?{/fade} ";
            ParasiteTalk.text = GlobalStringText.ParasiteTalkStrings[43]; 
            StarChargerTalk.text = GlobalStringText.StarChargerStrings[2];
            GlobalsScript.StoryFlagsArray[40] = true; 
            GoalText.text = GlobalStringText.GoalStrings[9]; 
            Pond1Barrier.SetActive(false);
            Pond2Barrier.SetActive(true);
            Pond3Barrier.SetActive(true);
            StarChargerBridge.SetActive(true);
            Auggers.SetActive(true);
        }
    }   
     
}
