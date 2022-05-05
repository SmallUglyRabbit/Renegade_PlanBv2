using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Clears the text on the screen.
public class ClearTheScreen_AC : MonoBehaviour
{
    [Header("Text To Wipe [Press C]")]
    public TextMeshProUGUI ParasiteText; 
    public TextMeshProUGUI PlayerText; 
    public TextMeshProUGUI NPC1Text; 
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ParasiteText.text = ""; 
            PlayerText.text = "";
            NPC1Text.text = "";
        }
    }

}