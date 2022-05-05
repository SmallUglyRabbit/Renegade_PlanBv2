using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAnimationScript : MonoBehaviour
{

    [SerializeField]
    Animator animator; 
    private string currentState;
    [Header("The Player Object and it's stationary image object")]
    public GameObject PlayerImageObject; 
    //The Animations
    //The Mechanism works by addressing the animator and requesting the animations that are already present there.
    
    //Test For Debug
    [Header("Used to Debug Animations")]
    [SerializeField] public Animation animationDebugandTest; 
    //Player Attacks
     
    const string CANNON_LVL1_WPN = "HandCannon";
    const string CANNON_LVL2_WPN = "OrangeCannon";
    const string STICK_WPN = "Twig";
    const string SHOVEL_WPN = "Shovel";
    const string STAR_WPN = "StarSmash";
    const string DOUBLE_EDGE_WPN = "DoubleSided";
    const string CHAKRA_WPN = "ChakraSmash";
    const string ARM_WPN = "ArmSmash";   
    const string WEIGHT_SET_WPN  = "WeightSmash";
    const string STAFF_WPN = "Staff";
    
    //Player Status Effects11
    public const string PLAYER_HURT_PLEF = "RedFlashHurt";
      const string PLAYER_HEAL_PLEF = "Heal";
      const string PLAYER_DIE_PLEF = "DieAnim";
      const string CYCLE_PLEF = "Cycle";
      const string MULTICLR_PLEF = "DiscoAnim";
      const string WAVE_PLEF = "wave";
      const string MISSEDPLAYER_PLEF = "MissedMe";
      const string RGB_SPLIT_PLEF = "DimensionShift";
      const string PLAYER_HIT_PLEF  = "BeenHit";
      //const string IDLE_PLEF = "Idle";
  
  
    public void ChangeAnimationState(string newState)
    {
        if(currentState == newState) return;
        //play the animation
        animator.Play(newState);
        //re-assign the current state
        currentState = newState;
    }
    
  /*
    public void PLEF(string statusEffect)//Displays a PLEF
    {
        Debug.Log("PLEF:" + statusEffect);
        LeftTarget.transform.localPosition = PlayerObjectTransform.transform.localPosition;
        PlayerImageObject.SetActive(false);
        ChangeAnimationState(statusEffect);
        //animator.Play (statusEffect); 
        //PlayerObject.SetActive(true);
    }
    
    */
    void WPN(string wpnAttack)
    {
        ChangeAnimationState(wpnAttack);
    }
    //PLEF
    //PlayerImage.Setactive(false) 
    //Play PLEF Animation
    //When Done set PlayerActive to true again.. 
    
    //WPN ATTACK
    //need global variable about this thing setup somewhere. 
    //switch (WPN) play this thing 
     //Use target 
   
    //if this btn is pressed and is a success then PlayerImage.setactive(false) and  play ChangeAnimationState(PLAYER_WALK_UP);
    // Start is called before the first frame update
    void Start()
    {
         //PLEF(PLAYER_DIE_PLEF);
         
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
      //Player Effect - WPN Anim
    void Player_CannonL1_Anim()
    {
       ChangeAnimationState(CANNON_LVL1_WPN);
    
    }
    void Player_CannonL2_Anim()
    {
       ChangeAnimationState(CANNON_LVL2_WPN);
    
    }
    void Player_Stick_Anim()
    {
       ChangeAnimationState(STICK_WPN);
    
    }
    public void Player_Shovel_Anim()
    {
       ChangeAnimationState(SHOVEL_WPN);
    
    }
     void Player_ThrowingStar_Anim()
    {
       ChangeAnimationState(STAR_WPN);
    
    }
     void Player_DarthMaul_Anim()
    {
       ChangeAnimationState(DOUBLE_EDGE_WPN);
    
    }
     void Player_Wheel_Anim()
    {
       ChangeAnimationState(CHAKRA_WPN);
    
    }
     void Player_Arm_Anim()
    {
       ChangeAnimationState(ARM_WPN);
    
    }
     void Player_WeightSet_Anim()
    {
       ChangeAnimationState(WEIGHT_SET_WPN);
    
    }
     void Player_Staff_Anim()
    {
       ChangeAnimationState(STAFF_WPN);
    
    }
    //Player Effect - PLEF Anims 
    public void Player_Hurt_Anim()
    {
       ChangeAnimationState(PLAYER_HURT_PLEF);
    }
    
    void Player_Heal_Anim()
    {
        ChangeAnimationState(PLAYER_HEAL_PLEF);
    }
    
    void Player_Die_Anim()
    {
        ChangeAnimationState(PLAYER_DIE_PLEF);
    }
    
    void Player_Wave_Anim()
    {
        ChangeAnimationState(WAVE_PLEF);
    }
    
    void Player_Missed_Anim()
    {
        ChangeAnimationState(MISSEDPLAYER_PLEF);
    }
    void Player_3Way_Anim()
    {
        ChangeAnimationState(RGB_SPLIT_PLEF);
    }
    void Player_Hit_Anim()
    {
        ChangeAnimationState(PLAYER_HIT_PLEF);
    }
     void Player_FlashMultiClr_Anim()
    {
        ChangeAnimationState(MULTICLR_PLEF);
    }
    
}
