using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//The CheatKeys are a selection of areas within the sewer maze
//that are used for testing different locations. They slot 
//into the inspector and operate off of the P key. 
public class CheatKeys : MonoBehaviour
{
    public GameObject Player;
    public GameObject StartingLocation; 
    public GameObject SecondVendoMax; 
    public GameObject ForceFieldMainSwitch; 
    public GameObject FactoryFloodSwitch; 
    // Start is called before the first frame update
   
  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Player.transform.position = StartingLocation.transform.position; 
        }
    }
}
