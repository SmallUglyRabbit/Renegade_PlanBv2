using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//This is the script for the key that opens the final sewer exit. 
public class Key1 : MonoBehaviour
{
    public TextMeshProUGUI GoalsText; 
    public GameObject ThisObject; 
    public AudioSource KeySound; 
    public GameObject ExitArea; 
    public GameObject ExitDoor; 
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            KeySound.Play();
            GlobalsScript.StoryFlagsArray[34]=true; 
            GlobalsScript.key1 = true;
            GoalsText.text = "Goals: Exit the sewer";
            ExitArea.SetActive(true);
            ExitDoor.SetActive(false);
            ThisObject.SetActive(false);
           
        }
     
}
}