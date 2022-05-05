using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script was used to set the starting location from the inspector when a new map loads. 
public class StartingLocation : MonoBehaviour
{

public GameObject player; 
public Transform TargetStartingLocation;
public GameObject SelfDestruct;

    void Awake()
    {
    //Fires every time the level reloads from the battlescene. 
        if(GlobalsScript.new_level == true) 
        {
       // player.transform.localPosition.x = -124.82; 
           player.transform.position = TargetStartingLocation.transform.position;
         
        }
        else
        {
            SelfDestruct.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
