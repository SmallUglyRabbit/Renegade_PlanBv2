using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentItems11 : MonoBehaviour
{
 
   
    
     void  OnTriggerEnter2D(Collider2D other)
        {  if (other.tag == "Player")
           
           {
           GlobalsScript.AccidentItems[10] = 0;
           }
}
}
 
