using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls all of the mutation animations. 
public class MUTAnimScript : MonoBehaviour
{
  
 
     [SerializeField]
    [Header("The Animator holding the Animations")]
    public Animator animator;
    private string currentState;
    [Header("The Player Object and it's stationary image object")]
    public GameObject PlayerImageObject; 
    
    
     
    //Player Mutations
     
    const string FIREBALL_MUT = "FireBall";
    const string SHOCK_MUT = "ThunderAnim";
    const string ICE_MUT = "ShockDamage";
    const string MIST_MUT = "MistAnim";
    const string ACID_MUT = "ExplosionAnim";
    const string LIFESTEAL_MUT = "BloodHit";
    const string ENEMY_ATTACK = "ClawAnim";
    public const string IDLE = "Idle";
     
   public void ChangeAnimationState(string newState)
    {
        if(currentState == newState) return;
        //play the animation
        animator.Play(newState);
        //re-assign the current state
        currentState = newState;
    }
    public void Idle_Mutation_Anim()
    {
        ChangeAnimationState(IDLE);
    }
    public void Fire_Mutaion_Anim()
    {
        ChangeAnimationState(FIREBALL_MUT);
    }
    public void Shock_Mutaion_Anim()
    {
        ChangeAnimationState(SHOCK_MUT);
    }
    public void Ice_Mutaion_Anim()
    {
        ChangeAnimationState(ICE_MUT);
    }
    public void Mist_Mutaion_Anim()
    {
        ChangeAnimationState(MIST_MUT);
    }
    public void Acid_Mutaion_Anim()
    {
        ChangeAnimationState(ACID_MUT);
    }
    public void LifeSteal_Mutaion_Anim()
    {
        ChangeAnimationState(LIFESTEAL_MUT);
    }
}
