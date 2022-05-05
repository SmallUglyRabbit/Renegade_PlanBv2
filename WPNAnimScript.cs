using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script handles all of the weapons animations and triggers. 
public class WPNAnimScript : MonoBehaviour
{
     [SerializeField]
    [Header("The Animator holding the Animations")]
    Animator animator;
    private string currentState;
    [Header("The Player Object and it's stationary image object")]
    public GameObject PlayerImageObject; 
    public Transform PlayerObjectTransform; 
    public SpriteRenderer SpriteRenderer; 
    public GameObject TwigAnim;
    public GameObject WeightAnim; 
    public GameObject ShovelAnim; 
    public GameObject DualToothAnim; 
    public GameObject HandCannonAnim; 
    public GameObject StarChargerCannonAnim; 
    
    //The Animations
    //The Mechanism works by addressing the animator and requesting the animations that are already present there.
    
    //Test For Debug
    [Header("Used to Debug Animations")]
    [SerializeField] public Animation animationDebugandTest; 
    //Player Attacks
    //Instead of using UNITY's native animations, we use a function that calls 
    //the animations through code. 
    const string CANNON_LVL1_WPN = "HandCannon";
    const string STARCHARGER_CANNON_WPN = "OrangeCannon";
    const string STICK_WPN = "Twig";
    const string SHOVEL_WPN = "Shovel";
    const string STAR_WPN = "StarSmash";
    const string DOUBLE_EDGE_WPN = "DoubleSided";
    const string CHAKRA_WPN = "ChakraSmash";
    const string ARM_WPN = "ArmSmash";   
    const string WEIGHT_SET_WPN  = "WeightSmash";
    const string STAFF_WPN = "Staff";
    const string IDLE = "Idle";
    
    //This function smoothly transitions the animations from start to finish. 
   public void ChangeAnimationState(string newState)
    {
        if(currentState == newState) return;
        //play the animation
        animator.Play(newState);
        //re-assign the current state
        currentState = newState;
    }
    //This is called for the cannon. 
     void Player_CannonL1_Anim()
    {
       ChangeAnimationState(CANNON_LVL1_WPN);
    
    }
    //This calls the StarChargerCannon Animation
    public void Player_StarChargerCannon_Anim()
    {
        //This will also have to have a bunch of stats in it and then add then into the BattleSystem. 
       ChangeAnimationState(STARCHARGER_CANNON_WPN);
    }
    //This calls the Twig animation
    void Player_Stick_Anim()
    { 
        //SpriteRenderer.("Twig");
        ChangeAnimationState("Twig");
    
    }
    //This calls the Shovel animation
     public void Player_Shovel_Anim()
    {
       ChangeAnimationState(SHOVEL_WPN);
    
    }
    //This calls the Throwing Star animation MOTHBALLED
     void Player_ThrowingStar_Anim()
    {
       ChangeAnimationState(STAR_WPN);
    
    }
    //This calls the dualtooth.
     public void Player_DarthMaul_Anim()
    {
       ChangeAnimationState(DOUBLE_EDGE_WPN);
    
    }
    //This calls the Chakra animation MOTHBALLED
     void Player_Wheel_Anim()
    {
       ChangeAnimationState(CHAKRA_WPN);
    
    }
    //This calls the tentacle arm animation MOTHBALLED
     void Player_Arm_Anim()
    {
       ChangeAnimationState(ARM_WPN);
    
    }
    //This calls the Weight Set animation
     public void Player_WeightSet_Anim()
    {
       ChangeAnimationState(WEIGHT_SET_WPN);
    
    }
    //This calls the grav staff animation MOTHBALLED
     void Player_Staff_Anim()
    {
       ChangeAnimationState(STAFF_WPN);
    
    }
    void Player_Idle_Anim()//Clears animation buffer.
    {
    ChangeAnimationState(IDLE);
    }
   
    //This function looks at the saved weapons flags and loads the appropriate weapons for the battle. 
    public void WPN_Decider()
    {if(GlobalsScript.WeaponsFlags[5] == false && GlobalsScript.WeaponsFlags[4] == true)
    {
        //Weapon used is the StarChargerCannon 
        //Player_Idle_Anim();
        //   Player_StarChargerCannon_Anim();
        GlobalsScript.PlayerDamageBonus += 20;
        HandCannonAnim.SetActive(true);
        Debug.Log("Hand Cannon");
    }
        else if(GlobalsScript.WeaponsFlags[4] == false && GlobalsScript.WeaponsFlags[3] == true)
        {
        //Weapon used is the StarChargerCannon 
            //Player_Idle_Anim();
            //   Player_StarChargerCannon_Anim();
            GlobalsScript.PlayerDamageBonus += 15; 
            StarChargerCannonAnim.SetActive(true);
            Debug.Log("Star Charger Cannon");
        }
        else if(GlobalsScript.WeaponsFlags[3] == false && GlobalsScript.WeaponsFlags[2] == true)
        {
            //Player_Idle_Anim();
            //        Player_DarthMaul_Anim(); 
            GlobalsScript.PlayerDamageBonus += 10; 
            DualToothAnim.SetActive(true);
            Debug.Log("Dual Tooth Edge");
        //Weapon used is the Dual Toother
        }
        else if(GlobalsScript.WeaponsFlags[2] == false && GlobalsScript.WeaponsFlags[1] == true) 
        {
            //Player_Idle_Anim();
            //     Player_Shovel_Anim();
            GlobalsScript.PlayerDamageBonus += 5; 
            ShovelAnim.SetActive(true);
            Debug.Log("Shovel 2 da brain!");
            //Weapon used is the Shovel? 
      
        }
        else if(GlobalsScript.WeaponsFlags[1] == false && GlobalsScript.WeaponsFlags[0] == true)
        {
            //Player_Idle_Anim();
         //Player_WeightSet_Anim();
         //ChangeAnimationState(WEIGHT_SET_WPN);
            GlobalsScript.PlayerDamageBonus += 2; 
            WeightAnim.SetActive(true);
            Debug.Log("Slammer Jammer");
         //Weapon used is the WeightSet?
    
        }
        else if(GlobalsScript.WeaponsFlags[0] == false)
        {
            //WPNObject.setActive(true)
            //Player_Idle_Anim();
         //Player_Stick_Anim();
            GlobalsScript.PlayerDamageBonus += 0; 
         TwigAnim.SetActive(true);
         Debug.Log("Twig");
         //Picks up a twig.
        }
        
      Debug.Log("Weapon Decided");
     }
        
     
        
}    

