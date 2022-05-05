using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject Barrier; 
    public GameObject Graphic; 
    public Collider2D Door; 
    public Collider2D Player; 
    
    // Start is called before the first frame update
  void OpenTheDoor()
  {
  if (Door.IsTouching(Player) && GlobalsScript.StoryFlagsArray[39] == true)
     {
        
         
        Debug.Log("Door touched the player");
         // Do something;
         
        Graphic.SetActive(false); 
        Barrier.SetActive(false);
      }
 }
  
    // Update is called once per frame
    void Update()
    {
        OpenTheDoor();
    }
}
