using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This was  a quick script built to setup the game for the player to use a specified amount of Hitpoints. They get saved right away so that they can transition into the battlescene. 
public class Ac_Specific_Setup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        GlobalsScript.PlayerCurrentHP = 20; 
        GlobalsScript.PlayerCurrentMAXHP = 20; 
        PlayerPrefs.Save();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
