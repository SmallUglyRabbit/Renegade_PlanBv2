using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MOTHBALLED THIS CODE: It was initially being built as a 'Star Wars' like scroll text that would trigger between scenes. It didn't work very well and was scrapped due to time constraints. 
public class ScrollText : MonoBehaviour
{
	
	public float scrollspeed = 20; 
  

    // Update is called once per frame
    void Update()
	{
		//get current position of parent gameobject
	    Vector3 pos = transform.position; 
	    
	    //get vector pointing into distance
		Vector3 LocalVectorUp = transform.TransformDirection(0,1,0);
	    
		//move the text object into the distance to give the 3D scrolling effect
		pos += LocalVectorUp * scrollspeed * Time.deltaTime; 
		transform.position = pos; 
    }
}
