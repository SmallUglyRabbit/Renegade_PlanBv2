using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is for debugging and grants the player a 30 hit point max. I used it while I was testing the vending machines.
public class SUPER_CHEAT_SCRIPT : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            
            GlobalsScript.PlayerCurrentMAXHP = 30;  
        }
    }
}
