using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//This was going to be a dialog with the 'Auggers' but was remvoed later.
public class ShavenAuggerDialog : MonoBehaviour
{ 
    
    public TextMeshProUGUI PlayerText;
    
    public TextMeshProUGUI ParasiteText;
    
    
    // Start is called before the first frame update
      
     void  OnTriggerEnter2D(Collider2D other)
        { 
            if (other.tag == "Player" && GlobalsScript.StoryFlagsArray[38] == false)
                { 
                PlayerText.text = GlobalStringText.PlayerTalkStrings[39];
                ParasiteText.text = GlobalStringText.ParasiteTalkStrings[37];  
                GlobalsScript.StoryFlagsArray[38] = true; 
                
                  
                }
         }
}
