using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

//This script is the exit for the 'Stage 1' that leads into the sewer system. 
public class StoryScriptExit : MonoBehaviour
{

    [SerializeField]
    internal GameSaver GameSaveScript; 
    
    public GameObject MedTeam;
    public TextMeshProUGUI Parasite; 
    public TextMeshProUGUI Player;
    public TextMeshProUGUI MedTeamText;

	void OnTriggerEnter2D(Collider2D other)
	{
        //Before the fight
		if (other.tag == "Player" && GlobalsScript.StoryFlagsArray[5] == false)
		{
            GlobalsScript.new_level = true; //Will be starting a new level
         
            MedTeamText.text = GlobalStringText.NPCText[2];
			GlobalsScript.StoryFlagsArray[5] = true;
            
            //Set the new player position
            float x = -124f; 
            float y = 39.64f;
            float z = 0f; 
            GlobalsScript.lastposition = new Vector3(x,y,z); //New Position
            GameSaveScript.Save();
            SceneManager.LoadScene(2); 
        }
	}
}
