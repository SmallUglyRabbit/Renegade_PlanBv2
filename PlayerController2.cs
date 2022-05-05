using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

//This script is a hold over from Playmaker, I had to convert certain //functions to work with plain unity. 
//Converted to just take care of animation and player position. 

public class PlayerController2 : MonoBehaviour
{
	//public GameObject HUD_CANVAS; 
	//public GameObject InventoryHUD; 
	//Movement Variables
	Rigidbody2D body;
	float horizontal;
	float vertical;
	public float runSpeed = 20.0f;
	
	//Animation Variables
	[SerializeField]
	Animator animator;
	private string currentState;
	//The Animations
    [SerializeField]
	public const string PLAYER_WALK_UP = "Up_Anim_Player";
	public const string PLAYER_WALK_DOWN = "Down_Anim_Player";
	const string PLAYER_WALK_RIGHT = "Right_Anim_Player";
	const string PLAYER_WALK_LEFT = "Left_Anim_Player";
	const string IDLE = "Idle";
	
	public TextMeshProUGUI Parasitetext;
	public TextMeshProUGUI Playertext; 
	
    //For Player Animation
	void ChangeAnimationState(string newState)
	{
		if(currentState == newState) return;
		//play the animation
		animator.Play(newState);
		//re-assign the current state
		currentState = newState;
	}
    
	void Start ()
	{
	    	 
		body = GetComponent<Rigidbody2D>();
		this.transform.position = GlobalsScript.lastposition; //returns the player to the last position
        //needs to be handled by a different script. 
	}
	
	void Update ()
	{
		
		
		 horizontal = Input.GetAxisRaw("Horizontal");
		//print(horizontal);
	
		vertical = Input.GetAxisRaw("Vertical"); 
		//print(vertical);
	}
	
	private void FixedUpdate()
	{  
		body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
		//////
		///Animation
		//Debug.Log("X:");
		//Debug.Log(horizontal); 
		//Debug.Log("Y:");
		//Debug.Log(vertical); 
		PlayerAnimationController();
		//GlobalsScript.lastposition = this.transform.position; //saves the last position at regular intervals
	
	}
	
	//Player Animations Controller
	
	void PlayerAnimationController()
	{
		//Play IDLE
		if(horizontal == 0 && vertical == 0)
		{
			ChangeAnimationState(IDLE);
		}
		//Play UP
		else if(vertical > 0 && horizontal == 0)
		{
			ChangeAnimationState(PLAYER_WALK_UP);
			//	Debug.Log("Go Up");
		}
		//Play DOWN
		if(vertical < 0 && horizontal == 0)
		{
			ChangeAnimationState(PLAYER_WALK_DOWN);
			//	Debug.Log("Go Down!");
		}
		//Play RIGHT
		else if(horizontal > 0 && vertical == 0)
		{
			ChangeAnimationState(PLAYER_WALK_RIGHT);
			//Debug.Log("Go Right");
		}
		//Play LEFT
		else if(horizontal < 0 && vertical == 0)
		{
			ChangeAnimationState(PLAYER_WALK_LEFT);
			//Debug.Log("Go Left");
		}
		//These are the player animations if both directions are pressed.
		//Play LEFT UP
		else if(horizontal < 0 && vertical > 0)
		{
			ChangeAnimationState(PLAYER_WALK_LEFT);
			//	Debug.Log("Go Left Up");
		}

		//Play RIGHT UP
		else if(horizontal < 0 && vertical > 0)
		{
			ChangeAnimationState(PLAYER_WALK_RIGHT);
			//Debug.Log("Go Right Up");
		}

		//Play LEFT DOWN 
		else if(horizontal < 0 && vertical < 0)
		{
			ChangeAnimationState(PLAYER_WALK_LEFT);
			//Debug.Log("Go Left Down");
		}

		//Play RIGHT DOWN
		else if(horizontal > 0 && vertical > 0)
		{
			ChangeAnimationState(PLAYER_WALK_RIGHT);
			//Debug.Log("Go Right Down");
		}

	 
		
	}
	

}
	

