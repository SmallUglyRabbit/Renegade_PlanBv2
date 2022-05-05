using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ForceFieldShutOff : MonoBehaviour
{
	[SerializeField] 
	public TextMeshProUGUI PlayerTalk;
	public TextMeshProUGUI ParasiteTalk;
	public TextMeshProUGUI GoalsText;
	public Rigidbody2D Player_RigidBody;
    public GameObject FFdoorgraphic;
    public GameObject ForceFieldBarrier; 


	  
	//This is independent of the trigger game object so each story script.cs would need to be different 
	//ala storyscript1 for this one storyscript2 for another. 
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && GlobalsScript.Forcefieldoff == false)
		{
			GlobalsScript.Forcefieldoff = true; 
			PlayerTalk.text = "What does this button do?";
			ParasiteTalk.text ="... This is the control to turn the Force field doors off";
			GoalsText.text = "Goals: Get to the Force field door";
			FFdoorgraphic.SetActive(false);
            Destroy(ForceFieldBarrier);
            
		}
		else 
		{
			PlayerTalk.text = "";
			ParasiteTalk.text = ""; 
		}
  
}
}