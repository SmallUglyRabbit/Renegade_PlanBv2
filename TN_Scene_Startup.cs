using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TN_Scene_Startup : MonoBehaviour
{
    public TextMeshProUGUI GoalText; 
    // Start is called before the first frame update
    void Start()
    {
        GoalText.text = GlobalStringText.GoalStrings[8];        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
