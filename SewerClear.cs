using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SewerClear : MonoBehaviour
{
    //This script is another 'clear' dialog key.
    public TextMeshProUGUI RoamingRatText,ParasiteText,PlayerText; 
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            RoamingRatText.text = "";
            ParasiteText.text = ""; 
            PlayerText.text = "";
            
        }  
    }
}
