using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MEDTEAM_NPC : MonoBehaviour
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
    public const string WALK_UP = "Evil_Doctor_Up";
    public const string WALK_DOWN = "Evil_Doctor_Down";
    public const string WALK_RIGHT = "Evil_Doctor_Right";
    public const string WALK_LEFT = "Evil_Doctor_Left";
    public const string IDLE = "Idle";
    [Header("Colliders")]
    public Collider2D NPCCollider;
    public Collider2D PlayerCollider;
    [Header("Dialog Object")]
 
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
     if (NPCCollider.IsTouching(PlayerCollider))
     {
     
        
        Debug.Log("EvilDoc touched the player");
  
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
                    ChangeAnimationState(WALK_UP);
                    break;
                    
                    
                    case 2://Down
                    NPCBody.velocity = new Vector2(0,-moveSpeed);
                    StopWalkingCheck(); 
                    ChangeAnimationState(WALK_DOWN);
                    break;
                    
                    
                    
                    case 3://Right
                    NPCBody.velocity = new Vector2(moveSpeed,0);
                    StopWalkingCheck();
                    ChangeAnimationState(WALK_RIGHT);
                    break;
                    
                    
                    
                    case 4://Left
                    NPCBody.velocity = new Vector2(-moveSpeed,0);
                    StopWalkingCheck();
                    ChangeAnimationState(WALK_LEFT);
                    break;
                }
        
            }
            
        }
    }
}

