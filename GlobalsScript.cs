using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

//This script holds all the global variables used throughout 
//the game. It passes variables back and forth between 
//the battlescene and is in charge of variables shown in the HUD.
public class GlobalsScript : MonoBehaviour
{

    public static GlobalsScript control; 
	[SerializeField]
	//public GameObject Player, gives the player physics; 
	public static Rigidbody2D Player_RigidBody;
	//Name of the Player
	public new string name;
	// string currentStatus = "Alive";  //To be added in Assignment 3
	public static int Heals = 5; //Number of Heals that the player has available
	public static bool new_level = false;
	//Array of names of Weapons & Armour
	public static bool[] WeaponsFlags  = new bool[10];
	public static string[] Armour  = new string[10];
	
	//Battle Stats 2 be added. - No longer required
	int HitPoints,ArmourClass,DamagePower,Chance2Hit,Chance2Evade,ExperiencePoints;
	
	//Inventory.Add(1);
	
	//BATTLESCENE PREFAB GLOBALS
	//For use with the battle monsters and player Prefabs. 
	//For Adjusting the Battle System to new enemies
    #region BattleScene Settings
    [SerializeField]
	[Header("BattleScene Settings")]
	public static string UnitName; 
	public static int UnitLevel; 
	public static int Damage;
	public static int MaxHP;
	public static int CurrentHP; 
	public static int EnemyEXP; //Experience Points
	public static int MoneyHeld; 
    //Replaced by combo systemm
	//string[] statusEffects = { "Alive", "Dead", "Asleep","Paralyzed","Hurt","FullHealth" };
	#endregion 
	//All added stats that stack onto the original stats for advanced levels.   
	//The battle system uses common stats for enemy and player, these enhance the stats specifically 
	//for the player.
    #region Player Settings
    [SerializeField]
    [Header("Player Settings")]
	public static int PlayerLevel = 0; //Current Player Level for flags. 
	public static int PlayerDamageBonus; //Player Damamge Bonuses
	public static int PlayerHPBonus; //Player Hit Points Bonuses
	public static int PlayerHealsBonus; //Player Heal Bonus Points
	public static int PlayerPsyPointBonus; 
	public static int PlayerEXP; //Player Experience Points [Total]
	public static int PlayerDEF;
	public static int PlayerATK;
    public static Vector3 PlayerPosition; 
	public static int PlayerCurrentPsyPoints = 30; 
	public static int PlayerCurrentMAXPsyPoints = 30;
	public static int PsyPotionsHeld = 0; 
	public static int ChargeUp = 0;
	//PLAYER OVERWORLD GLOBALS
	public static int PlayerCurrentHP = 25; //For Overworld LIFEBAR Slider [25 to start]
	public static int PlayerCurrentMAXHP = 25; //For Overworld LIFEBAR Slider [25 to start]
	#endregion
	//Player Specific Prefab
	public static int PlayerMoneyTotal; //Currency Held. 
	public Image EnemyImage;//Enemy Image(not sprite) on the Enemy->EnemyImage Prefab.
 
	public static bool EncounterStopper = false;
	public static bool Forcefieldoff = false; //Sewer Maze shuts off the forcefield.
	
	
	
	
 //INVENTORY GLOBALS
 //Instructions trigger the first time an Item is touched and not again. These flags trigger after the first time. 
   
	public static int SpikeBombsHeld;
	public static ArrayList Inventory  = new ArrayList();
	//Tracks the Item Flags [if an item has been recieved]
    [Header("Flags for Items")]
	public static bool[] ItemFlagsArray = new bool[10]; //tracks the progression of key points in the story
	
	public static bool ONDONEFLAG = false;
	public static bool STOPTALKINGFLAG = false;
    public static int LastStoredFlag; 
    public static int LastStoredWeaponsFlag; 
	/// </summary>
	//public static Scene CurrentScene = SceneManager.GetActiveScene; //Returns the player to the previous scene after the battle is over.
	//The Battle Scene will always be the last scene in the Menu. 
    #region Scene Transitions
    [Header("Scene Transition")]
    //OVERWORLD GLOBAL
    //Tracks the story flag in the story scripts. 
    public static bool[] StoryFlagsArray = new bool[50]; //tracks the progression of key points in the story
    
	public static int PreviousScene; //Holds the previous scene for transitioning to the battle scene or checking if a flag has been completed. 
	public static Vector3 lastposition; //Records the last position of the player on the overworld map;
    public static bool key1 = false; //Has Key? 
    public static int CurrentMapScene; //Set in the playercontroller script on the Player Object in the start()
	public const int BattleScene = 4; //Sets the battlescene from the Build Settings 
	public static bool StartSceneOverrideFlag = false;
    #endregion Scene Transitions
    #region Random Encounters
    [Header("Random Encounters")]
	public static int RandomEncounterCategory; //Sets the monster category of the random encounter
    #endregion Random Encounters
	[Header("Flag for NPC Dialogs")]
    public static bool[] NPCFlagsArray = new bool[10];
    
    #region Flags for reloading items
    [Header("Flags to reload items")]
    
    //SAVE SYSTEM
    //These flags will be saved before the battlescene executes and when it reloads the/a scene, the items flagged 0, will 
    //be removed from the scene. This is to ensure that picked up items don't respawn. 
    //Accident Level
    public static int[] AccidentItems = new int [12];
    public GameObject[] ReloadedAccidentItems = new GameObject[12];
    
    //Sewer Level
    public static int[] SewerItems = new int [10];
    public GameObject[] ReloadedSewerItems = new GameObject[11];
    
    //Town Level
    public static int[] TownItems = new int [10];
    public GameObject[] ReloadedTownItems = new GameObject[11];
    
    //Ship Level
    public static int[] ShipItems = new int [10];
    public GameObject[] ReloadedShipItems = new GameObject[11];
    
    
    
    public GameObject[] ReloadedTriggers = new GameObject[10];
    public GameObject[] ReloadedNPCs = new GameObject[10];
    #endregion 
    public static int SceneBuildIndex; 
    
    #region Awake(),Update(),Start()
    public void Awake()
    {
        // GlobalsScript.new_level = true; 
        SceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        //Sets the scene
        GlobalsScript.CurrentMapScene = SceneBuildIndex;
        control = this; 
        //  DontDestroyOnLoad(transform.gameObject);
    }
     void Update() 
     {
      //  AccidentTestArray();
     }
    void Start()
	{
      
	
		
    }
    #endregion
//BATTLESCENE FUNCTIONS
    //For changing stats on the fly. 
    public void Addpoints(int points, int BattleStats)
    {
        BattleStats += points;
    }
    public void Subpoints(int points, int BattleStats)
    {
        BattleStats -= points;
    }
    public void Mulpoints(int points, int BattleStats)
    {
        BattleStats *= points;
    }
    public void Divpoints(int points, int BattleStats)
    {
        BattleStats /= points;
    }
	//A static randomizer. 
	public static int Roll(int MinNum, int MaxNum)
	{
		int num = Random.Range(MinNum, MaxNum);
		return num;
	}
	
	//The ability to check for used heals. 
	public static bool CheckForHeals()
	{
		if(GlobalsScript.Heals > 0)
		{
			return true; //Enable HEAL Button 
		}
		else 
		{
			return false;
		}
	}
	
   
	//Had to build this as a response to the SimpleMan Coroutine not working properly in WEBGL. 
	//I use this function in all 30 StoryScripts as a Delay Timer, so I have to adjust each 
	//Script now to match the timer in the old co-routine. 
	public static IEnumerator JustWait(float time2wait)
	{
		print(Time.time);
		Debug.Log("go Just Wait for seconds:" + time2wait);//Wait how long?
		yield return new WaitForSeconds(time2wait * Time.deltaTime); 
		
	}
	
 
	public static RigidbodyConstraints2D originalConstraints;
	
	
	public static void UnFreezeConstraints()
	{
		Player_RigidBody.constraints = originalConstraints;
	}
	
	public static void FreezeConstraints()
	{
		Player_RigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
	}
	     
    public void AccidentTestArray()
    {
        
        Debug.Log(AccidentItems[0]);
     
    }
}

 