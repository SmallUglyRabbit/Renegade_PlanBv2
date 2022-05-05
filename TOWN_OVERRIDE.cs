using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script was used to override a bug in the town level that placed the Player in the middle of town. The bug was later fixed and this code was mothballed.
public class TOWN_OVERRIDE : MonoBehaviour
{ 
    public GameObject Player;
  
    public Transform StartingLocationHere; 
    void Awake() 
    {  
      
    }
    void Start()
    {
        Debug.Log(GlobalStringText.CurrentLevel);
        if(GlobalStringText.CurrentLevel == "None")
        {
            Player.transform.position = new Vector2 (StartingLocationHere.position.x, StartingLocationHere.position.y);
            GlobalStringText.CurrentLevel = "Town";
            
            Debug.Log(GlobalStringText.CurrentLevel);
            GlobalsScript.CurrentMapScene = 3; 
            GlobalsScript.SceneBuildIndex = 3; 
            // Player.transform.position = StartingLocation.transform.position;   
        }
    }
    /*
    void Update()
    {
        Debug.Log(GlobalStringText.CurrentLevel);
        if(GlobalStringText.CurrentLevel == "None")
        {
            Player.transform.position = new Vector2 (StartingLocationHere.position.x, StartingLocationHere.position.y);
            GlobalStringText.CurrentLevel = "Town";
            
            Debug.Log(GlobalStringText.CurrentLevel);
            // Player.transform.position = StartingLocation.transform.position;   
        }
    }
    */
}
