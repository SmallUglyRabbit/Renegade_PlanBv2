using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
	public AudioSource[] SongArray;
	public AudioSource[] SoundEffectArray;
	public AudioSource ExampleSong; 
	
    // Start is called before the first frame update
    void Start()
	{
		//ExampleSong.Play();
		SongArray[0].Play();
	  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
