using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentItems8 : MonoBehaviour
{
 
   
    
     void  OnTriggerEnter2D(Collider2D other)
        {  if (other.tag == "Player")
           
           {
           GlobalsScript.AccidentItems[7] = 0;
           }
}
}
