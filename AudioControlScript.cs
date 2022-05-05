using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//These two keys are used to turn the sound on and off. 
//Initially I wanted to use one but there were a few bugs with 
//that and I just settled on using two for simplicity. 

public class AudioControlScript : MonoBehaviour
{
    public GameObject AudioObject;
    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.O))
        {
        
         AudioObject.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            AudioObject.SetActive(true);
        }
}
}
