using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
public class StoryScript41 : MonoBehaviour
{
    [SerializeField]  
    public GameObject TheTrigger;//This stores the trigger
    public Rigidbody2D Player_RigidBody;
    public GameObject ShipEntrance; 
    public GameObject Player; 
 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") 
        {
            Player.transform.position = ShipEntrance.transform.position; 
            Debug.Log("Change To StarCharger, more code required here");
        }
    }   
     
}
