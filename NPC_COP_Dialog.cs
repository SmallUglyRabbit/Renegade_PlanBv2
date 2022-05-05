using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//This script controls the COP NPC and his animations.
public class NPC_COP_Dialog : MonoBehaviour
{
 
 [Header("Movement Mechanics")]
    [SerializeField]
    //The variables that will control the NPC Behaviour 
    public GameObject NPC; 
    public Rigidbody2D NPCBody;
    public float waitTime; 
    public float waitCounter; 
    public float walkTime; 
    public float walkCounter; 
    private int walkDirection;
    public float moveSpeed; 
    public bool isWalking = false;
    //For constraining the NPC to a certain location
    private Vector2 minWalkPoint; 
    private Vector2 maxWalkPoint; 
    [Header("The Zone Constraints")]
    public Collider2D walkZone; 
    private bool hasWalkZone; 
    // Start is called before the first frame update
    [SerializeField]
    [Header("Animator / ChangeAnimationState")]
    Animator animator;
    private string currentState;
    [SerializeField]
    [Header("Animations")]
    public const string POLICE_WALK_UP = "PoliceUp";
    public const string POLICE_WALK_DOWN = "PoliceDown";
    public const string POLICE_WALK_RIGHT = "PoliceLeft";
    public const string POLICE_WALK_LEFT = "PoliceRight";
    public const string IDLE = "Idle";
    [Header("Colliders")]
    public Collider2D CopCollider;
    public Collider2D PlayerCollider;
    [Header("Dialog Object")]
    public TextMeshProUGUI NPCTXT; 
    public TextMeshProUGUI ParasiteTXT; 
    public TextMeshProUGUI PlayerTXT; 
    
 
    void ChangeAnimationState(string newState)
    {
        if(currentState == newState) return;
        //play the animation
        animator.Play(newState);
        //re-assign the current state
        currentState = newState;
    }
    
 /*
 private void NearPlayer()
 {
     if (CopCollider.IsTouching(PlayerCollider) && GlobalsScript.NPCFlagsArray[1] == false)
     {
        
        NPCTXT.text = GlobalStringText.NPCText[4];
        ParasiteTXT.text = GlobalStringText.ParasiteTalkStrings[38];
        PlayerTXT.text = GlobalStringText.PlayerTalkStrings[41];
        
        Debug.Log("COP touched the player");
         // Do something;
         GlobalsScript.NPCFlagsArray[1] = true; //Conversation triggers just once
     }
 }
 */
 
    void StopWalkingCheck()
    {
        if(hasWalkZone && NPCBody.transform.position.y > maxWalkPoint.y)
        {
            isWalking = false;
            waitCounter = waitTime;
        }
        if(hasWalkZone && NPCBody.transform.position.x > maxWalkPoint.x)
        {
        
            isWalking = false;
            waitCounter = waitTime;
        }
        if(hasWalkZone && NPCBody.transform.position.y < minWalkPoint.y)
        {
            isWalking = false;
            waitCounter = waitTime;
        
        }
        if(hasWalkZone && NPCBody.transform.position.x < minWalkPoint.x)
        {
            isWalking = false;
            waitCounter = waitTime;
        }
    }
    void Start()
    {
    
        if(walkZone != null)
        {
            hasWalkZone = true; 
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
        }
        waitCounter = waitTime;
        walkCounter = walkTime; 
        ChooseDirection();
        
    }
    
    void ChooseDirection()
    {
        walkDirection = Random.Range(0,5);
        isWalking = true; 
    }

    // Update is called once per frame
    void Update()
    {
       // NearPlayer(); //Check if Rat has touched the player. 
        
        if(isWalking == true)
        {
            walkCounter -= Time.deltaTime;
            if (walkCounter < 0)
            {
                isWalking = false; 
                waitCounter = waitTime; 
            }
            }
            else
            {
            NPCBody.velocity = Vector2.zero;
            waitCounter -= Time.deltaTime; 
            if (waitCounter < 0)//Time to wait has ended
            {
            ChooseDirection();//NPC will choose a direction and
                switch(walkDirection)//walk in that direction
                {
                    case 0:
                    break; 
                    
                    
                    case 1://Up
                    NPCBody.velocity = new Vector2(0,moveSpeed);
                    StopWalkingCheck(); 
                    ChangeAnimationState(POLICE_WALK_UP);
                    break;
                    
                    
                    case 2://Down
                    NPCBody.velocity = new Vector2(0,-moveSpeed);
                    StopWalkingCheck(); 
                    ChangeAnimationState(POLICE_WALK_DOWN);
                    break;
                    
                    
                    
                    case 3://Right
                    NPCBody.velocity = new Vector2(moveSpeed,0);
                    StopWalkingCheck();
                    ChangeAnimationState(POLICE_WALK_LEFT);
                    break;
                    
                    
                    
                    case 4://Left
                    NPCBody.velocity = new Vector2(-moveSpeed,0);
                    StopWalkingCheck();
                    ChangeAnimationState(POLICE_WALK_RIGHT);
                    break;
                }
        
            }
            
        }
    }
}
