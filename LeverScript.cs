using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

//This script is activated when the player touches the level 
//after the forcefield door. 
public class LeverScript : MonoBehaviour
{
    public TextMeshProUGUI parasiteTalk;
    public TextMeshProUGUI playerTalk;
    public TextMeshProUGUI GoalsText; 
	public GameObject MonsterZone2;
	public AudioSource Alarm;
    public GameObject LeverGraphic; 
    public bool switchedOn;
     
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" )
        {
            switchedOn = true;
            Alarm.Play(); 
            Alarm.Play(); 
            Alarm.Play(); 
            Alarm.Play(); 
            MonsterZone2.SetActive(true);
            LeverGraphic.SetActive(true);
            parasiteTalk.text = "";
            playerTalk.text = "";
            GoalsText.text = "Goals: Find the controls to drain the sewage.";
        }
        if(switchedOn==true)
        {
            //do nothing
        }
    }
    
    
}
