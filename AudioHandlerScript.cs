using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandlerScript : MonoBehaviour
{
	[SerializeField]
     BattleSystem BattleSystemScript;
	//The audio effects and soundtrack for the battle are kept here and on the Hierarchy. 
	public AudioSource[] BattleSongArray;
	public AudioSource[] BattleSoundEffectArray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
