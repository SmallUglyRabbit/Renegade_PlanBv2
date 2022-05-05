using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//This is the last script in the game, it removes all 
//the map graphics and tells the player to buy the full version. 

public class ShipExitScript : MonoBehaviour
{
    public GameObject ShipExit; 
    public GameObject Player; 
    public GameObject MonsterZone; 
    public GameObject Background; 
    public TextMeshProUGUI Prologue; 
    public TextMeshProUGUI Clear1, Clear2; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") 
        {
            MonsterZone.SetActive(false);
            Background.SetActive(false);
            Clear1.text = ""; 
            Clear2.text = ""; 
            Prologue.text = "To follow Adam's continuing adventures, buy the full version of Plan B: Renegade at" +
                "www.itch.io                                                                                                                           Thanks For Playing.                                                " +
                "Dedicated to Adam Mitter 1987 - 2020";
            Debug.Log("Change to Deep Space, and finish. ");
        }
    }
}
