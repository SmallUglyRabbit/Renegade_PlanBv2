using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Clears the text on the screen.
public class ClearScreenKey : MonoBehaviour
{
[Header("Text To Wipe [Press C]")]
public TextMeshProUGUI RoamingRatText;   
public TextMeshProUGUI ParasiteText; 
public TextMeshProUGUI PlayerText; 
public TextMeshProUGUI NPC1Text; 
public TextMeshProUGUI NPC2Text;
public TextMeshProUGUI StarChargerText;
public TextMeshProUGUI ShavenAuggerText; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            RoamingRatText.text = "";
            ParasiteText.text = ""; 
            PlayerText.text = "";
            NPC1Text.text = "";
            NPC2Text.text = ""; 
            StarChargerText.text = ""; 
            ShavenAuggerText.text = ""; 
        }
    }
}
