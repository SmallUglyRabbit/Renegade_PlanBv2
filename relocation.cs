using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class relocation : MonoBehaviour
{
    public GameObject ThisTrigger;
    public Rigidbody2D Player;
    bool switchedON; 
    public Transform StartingLocation; 
    protected void OnTriggerEnter2D(Collider2D other)
    {
        //PlayerBody.transform.localPosition.x = -57.4;
        //GlobalsScript.lastposition = StartingLocation.localPosition;
        //PlayerBody.transform.localPosition.y = 6.75;
        switchedON = true; 
        if(switchedON == true)
        {
            Destroy(ThisTrigger); 
        }
        
    }
}
