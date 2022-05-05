using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PLEF stands for Player Effect 
//This controls the player status effects during the BattleScene
public class PLEFAnimScript : MonoBehaviour
{

[SerializeField]
    [Header("The Animator holding the Animations")]
    Animator animator;
    private string currentState;
    [Header("The Player Object and it's stationary image object")]
    public GameObject PlayerImageObject; 
    public GameObject ThisObject; 
   
  
    Vector3 startPosition; //Target for the animation
    
public const string PLAYER_HURT_PLEF = "RedFlashHurt";
      const string PLAYER_HEAL_PLEF = "Heal";
      const string PLAYER_DIE_PLEF = "DieAnim";
      const string CYCLE_PLEF = "Cycle";
      const string MULTICLR_PLEF = "DiscoAnim";
      const string WAVE_PLEF = "wave";
      const string MISSEDPLAYER_PLEF = "MissedMe";
      const string RGB_SPLIT_PLEF = "DimensionShift";
      const string PLAYER_HIT_PLEF  = "BeenHit";
      const string IDLE_PLEF = "Idle";
      
        public void ChangeAnimationState(string newState)
    {
        if(currentState == newState) return;
        //play the animation
        animator.Play(newState);
        //re-assign the current state
        currentState = newState;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.F))
        {
        Debug.Log("Anim Key WOrking");
            ChangeAnimationState(PLAYER_HURT_PLEF);
     //     animator.Play("ChakraSmash");
            //BattleAnimationScript.
        }
           if(Input.GetKeyDown(KeyCode.H))
        {
        Debug.Log("Anim Key WOrking");
            ChangeAnimationState(PLAYER_HEAL_PLEF);
     //     animator.Play("ChakraSmash");
            //BattleAnimationScript.
        }
           if(Input.GetKeyDown(KeyCode.D))
        { 
        Debug.Log("Anim Key WOrking");
            ChangeAnimationState(PLAYER_DIE_PLEF);
     //     animator.Play("ChakraSmash");
            //BattleAnimationScript.
        }
            if(Input.GetKeyDown(KeyCode.L))
        {
        Debug.Log("LightSwitch Key WOrking");
           // LightSwitch(PlayerImageObject);
     //     animator.Play("ChakraSmash");
            //BattleAnimationScript.
        }
    }
    /*
    public bool LightSwitch(GameObject ThisObject)
    {
        if(ThisObject.SetActive(false))
        {
            ThisObject.SetActive(true);
        }
        else
        { 
          ThisObject.SetActive(false);
        }
        return true;
    }
    */
     //Player Effect - PLEF Anims 
     //EnemyTurn()
    public void Player_Hurt_Anim()
    {  //(PlayerImageObject);
        PlayerImageObject.SetActive(false);
       ChangeAnimationState(PLAYER_HURT_PLEF);
    }
    
    public void Player_Heal_Anim()
    {
        ChangeAnimationState(PLAYER_HEAL_PLEF);
    }
    
    public void Player_Die_Anim()
    {
        ChangeAnimationState(PLAYER_DIE_PLEF);
        
      //  ThisObject.SetActive(false);
        
    }
    
     public void Player_Idle_Anim() 
    {
        ChangeAnimationState(IDLE_PLEF);
    }
    public void Player_Wave_Anim()//Charge()
    { 
        ChangeAnimationState(WAVE_PLEF);
    }
    
    public void Player_Missed_Anim()
    {
      PlayerImageObject.SetActive(false);
        ChangeAnimationState(MISSEDPLAYER_PLEF);
         
          
    }
    public void Player_3Way_Anim()
    {
        ChangeAnimationState(RGB_SPLIT_PLEF);
    }
    void Player_Hit_Anim()
    {
        ChangeAnimationState(PLAYER_HIT_PLEF);
    }
    public void Player_FlashMultiClr_Anim() //CheckForLevelUp()
    {
        ChangeAnimationState(MULTICLR_PLEF);
    }
    
}
