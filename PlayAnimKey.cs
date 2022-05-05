using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DEBUG Key
public class PlayAnimKey : MonoBehaviour
{
    public Animator animator; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
        Debug.Log("Anim Key WOrking");
          animator.Play("ChakraSmash");
            //BattleAnimationScript.
        }
}
}