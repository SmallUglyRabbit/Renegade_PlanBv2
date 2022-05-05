using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Description:
//This script keeps the audio track playing throughout the scene 
//manager mode. 
public class DontDestroyThisSong : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
	    DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
