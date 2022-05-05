using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//The C key is used to clear the dialog and goal text from 
//the screen. 
public class ClearScreenKeyTown : MonoBehaviour
{
    public TextMeshProUGUI GoalText; 

   public TextMeshProUGUI ParasiteText; 
public TextMeshProUGUI PlayerText; 
public TextMeshProUGUI COPText; 
public TextMeshProUGUI StarChargerText;
 
   
   // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
          
           ParasiteText.text = ""; 
           PlayerText.text = "";
            COPText.text = "";
            GoalText.text = ""; 
          // NPC2Text.text = ""; 
            StarChargerText.text = ""; 
         //  ShavenAuggerText.text = ""; 
        }
    }
}


