
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 


 
public class StoryScript30 : MonoBehaviour
{
	[SerializeField] 
	public TextMeshProUGUI PlayerTalk;
    public TextMeshProUGUI GoalText;
	public TextMeshProUGUI ParasiteTalk;
	public GameObject TheTrigger;//This stores the trigger
	public Rigidbody2D Player_RigidBody;
	
	/*Made it global, keeping as a backup
	IEnumerator JustWait(int time2wait)
	{
		yield return new WaitForSeconds(time2wait); 
	}
	*/

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && GlobalsScript.StoryFlagsArray[35]==false) 
		{
		 	PlayerTalk.text = GlobalStringText.PlayerTalkStrings[35];
			ParasiteTalk.text =  GlobalStringText.ParasiteTalkStrings[35];
            GoalText.text = GlobalStringText.GoalStrings[4];
            //Ensures all triggers up to date when saved. 
            GlobalsScript.StoryFlagsArray[31] = true;
            GlobalsScript.StoryFlagsArray[32] = true;
            GlobalsScript.StoryFlagsArray[33] = true;
            GlobalsScript.StoryFlagsArray[34] = true;
            GlobalsScript.StoryFlagsArray[35] = true;
            
		}
	}	 
}


//
 
			 
			 
