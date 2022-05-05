using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCMovementScript : MonoBehaviour
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
    public const string RAT_WALK_UP = "Rat_Up";
    public const string RAT_WALK_DOWN = "Rat_Down_1";
    public const string RAT_WALK_RIGHT = "Rat_Right";
    public const string RAT_WALK_LEFT = "Rat_Left";
    public const string IDLE = "Rat_Down";
    [Header("Colliders")]
    public Collider2D RoamingRatCollider;
    public Collider2D PlayerCollider;
    [Header("Dialog Object")]
    public TextMeshProUGUI RoamingRatTXT; 
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
    
 
 private void NearPlayer()
 {
     if (RoamingRatCollider.IsTouching(PlayerCollider) && GlobalsScript.NPCFlagsArray[0] == false)
     {
        
        RoamingRatTXT.text = GlobalStringText.NPCText[3];
        ParasiteTXT.text = GlobalStringText.ParasiteTalkStrings[34];
        PlayerTXT.text = GlobalStringText.PlayerTalkStrings[34];
        
        Debug.Log("Rat touched the player");
         // Do something;
         GlobalsScript.NPCFlagsArray[0] = true; //Conversation triggers just once
     }
 }
 
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
        NearPlayer(); //Check if Rat has touched the player. 
        
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
                    ChangeAnimationState(RAT_WALK_UP);
                    break;
                    
                    
                    case 2://Down
                    NPCBody.velocity = new Vector2(0,-moveSpeed);
                    StopWalkingCheck(); 
                    ChangeAnimationState(RAT_WALK_DOWN);
                    break;
                    
                    
                    
                    case 3://Right
                    NPCBody.velocity = new Vector2(moveSpeed,0);
                    StopWalkingCheck();
                    ChangeAnimationState(RAT_WALK_RIGHT);
                    break;
                    
                    
                    
                    case 4://Left
                    NPCBody.velocity = new Vector2(-moveSpeed,0);
                    StopWalkingCheck();
                    ChangeAnimationState(RAT_WALK_LEFT);
                    break;
                }
        
            }
            
        }
    }
}
