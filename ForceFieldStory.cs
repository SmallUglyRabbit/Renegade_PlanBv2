using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 


public class ForceFieldStory : MonoBehaviour
{
	[SerializeField]
	public GameObject ThisTrigger; 
	public GameObject Forcefield;
	public TextMeshProUGUI parasitetext;
	public TextMeshProUGUI playertext; 
	public TextMeshProUGUI Goalstext; 
    // Start is called before the first frame update
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && GlobalsScript.Forcefieldoff == false && GlobalsScript.StoryFlagsArray[32]==false)
		{
			parasitetext.text = "The Disassembly plant's forcefield is still active, we need to find the shut off point.";
			Goalstext.text = "Goals: Find a way to shut off the force field.";
            
		}
		else if(other.tag == "Player" && GlobalsScript.Forcefieldoff == true)
		{
        GlobalsScript.StoryFlagsArray[32] =true; 
			Forcefield.SetActive(false);
			parasitetext.text = "";
			playertext.text = ""; 
			Goalstext.text = "Goals: Continue exploring the sewer";

		}
		
     
	}
}
