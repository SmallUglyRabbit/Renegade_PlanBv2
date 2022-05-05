
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using TMPro;

//Description: 

//This script controls the battlesystem, leveling and enemy prefabs. 
//It works in tandem with the Randomization script utilizing Global Variables. It also applies sound effects to the different actions 
//in the battle scene. 

//This enum tracks the current step of the battle. 
public enum BattleState {START, PLAYERTURN, ENEMYTURN, WON, LOST }


public class BattleSystem : MonoBehaviour
{

    #region Internalized Scripts
	//These make it so the battle system can be split over several scripts. The file was growing out of control. 
    [Header("Battle Mechanics Scripts")]
    [SerializeField]
    internal GameSaver GameSaverScript;
	[SerializeField]
	internal ComboScript ComboScript;
	[SerializeField]
	internal UnitScript UnitScript;  
	[SerializeField]
	internal BattleHUD BattleHUDScript; 
	[SerializeField]
	internal AudioHandlerScript AudioHandlerScript; 
    [Header("Dialog Script")]
	[SerializeField]
	internal GlobalStringText GlobalStringText;
    [Header("Animation Scripts")]
    [SerializeField]
    internal WPNAnimScript WPNScript;
    [SerializeField]
    internal PLEFAnimScript PLEFScript;
     [SerializeField]
    internal MUTAnimScript MUTScript;
    
    #endregion
    #region Animation Objects
     [Header("Animation Objects")]
    public GameObject PlayerBattleObject_ImageFile;//For turning the Player Image file off and on
    public GameObject EnemyBattleObject_ImageFile;//For turning the Enemy Image file on and off
    public GameObject PLEFObject;//The Player Effects Object
    public GameObject MUTObject;
    public GameObject WPNObject;
    public GameObject WPNAnims; 
    
 #endregion
	//internal GlobalsScript GlobalsScript; 
  
	
	
	
	//These variables hold the prefab objects that spawn into the battle scene. 
    [Header("Prefab")]
	public GameObject playerPrefab;
	public GameObject enemyPrefab;
	
	//This holds several Enemy Prefabs
	public GameObject[] EnemyArray;
	
    //This variable returns the player to the specified area of the previous scene where they left off. 
    public Transform PlayerMAPTransform;
	//These are the areas where the player/enemy graphics appear at .
	public Transform playerBattleStation;
	public Transform enemyBattleStation;
	#region HUD
	//These help interface with the HUD
	public UnitScript playerUnit; 
	public UnitScript enemyUnit;
	
	public BattleHUD enemyHUD; 
	public BattleHUD playerHUD; 
	#endregion
	//
    #region BTN Variables
	[SerializeField]
    [Header("Mutation Buttons")]
	public GameObject FireBallBTN; 
	public GameObject SpitAcidBTN;
	public GameObject FreezeBTN; 
	public GameObject ElectrifyBTN;
	public GameObject LifeStealBTN;
	public GameObject HealBTN; 
	public GameObject MistBTN; 
	//Amount of experience required for each level gain in the array. 
	int[] Levels = new int[] { 50, 50, 50, 75, 75, 75, 100, 100, 100, 100 };
	//These host the HUD settings.
	//public BattleHUD playerHUD; 
	//public BattleHUD enemyHUD; 
	
	[SerializeField]
	public GameObject MutationsMenu;
	public GameObject ItemsMenu; 
	public GameObject MainMenu;
    #endregion
    #region Dialogs
	//This variable is used to display battle status/updates. 
	public TextMeshProUGUI dialogueText; 
	public TextMeshProUGUI PlayerHPNumbers; 
	public TextMeshProUGUI EnemyHPNumbers;
	public TextMeshProUGUI PlayerPSYNumbers; 
    public TextMeshProUGUI BigBattleTextRED; //Displays bigger text on combo damage. 
    
    public TextMeshProUGUI BigBattleTextBLUE; //Displays bigger text on combo damage.
    public TextMeshProUGUI BigBattleTextGREEN; //Displays bigger text on combo damage. 
    public GameObject WPN_Anim_Holder;
    #endregion
	//Check to see if a button has been pressed already. 
	public bool PlayerActionTaken = false; 
	
	//
	public bool TempDefense = false; 
	public GameObject eliminate;
	public BattleState state;
	
   
    //Material PlayerObjectMaterial = GetComponent<Renderer>().material;

	
	#region Start() and Update()
    // Start is called before the first frame update
    void Start()
	{
        GlobalsScript.new_level = false; //ensures that the starting location isn't used once the battle is over.
        GameSaverScript.Determine_Level_And_Save(); //Save this into memory
		Debug.Log("Player HP" + playerUnit.CurrentHP);
	    state = BattleState.START;
		StartCoroutine(SetupBattle());
		MutationsMenu.SetActive(false);
		ItemsMenu.SetActive(false);
		playerUnit.CurrentHP = GlobalsScript.PlayerCurrentHP;
		playerUnit.MaxHP = GlobalsScript.PlayerCurrentMAXHP;
		
		Debug.Log("Player HP after Globalscript" + playerUnit.CurrentHP);
		UpdateHUD();
    }
	
   
    // Update is called once per frame
    void Update()
    {
      CheatsON(); 
    }
    
    #endregion
    
    #region RunTime Bug Testing
    
    
    public void WeaponTestKey()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            GlobalsScript.WeaponsFlags[0] = true; 
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            GlobalsScript.WeaponsFlags[1] = true; 
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
         GlobalsScript.WeaponsFlags[2] = true; 
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
         GlobalsScript.WeaponsFlags[3] = true; 
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            GlobalsScript.WeaponsFlags[4] = true; 
        }
    }
    

    public void CheatsON()
    {
        AllMutations(); //Tests the Different Mutations
        BigTextTest(); //Tests the Damage Text
        WeaponTestKey(); //Tests the Different Weapon Animations
    }
    public void BigTextTest()
    {
     if(Input.GetKeyDown(KeyCode.V))
       {
          MUTScript.Idle_Mutation_Anim();
          FireBallSpell(); 
          BigBattleTextGREEN.text = "TRIPLE DAMAGE! ";
       }
       if(Input.GetKeyDown(KeyCode.D))
{

        BigBattleTextRED.text = "DOUBLE DAMAGE!";
}
    if(Input.GetKeyDown(KeyCode.S))
{

        BigBattleTextBLUE.text = "HALF DAMAGE";
}
    }
     public void AllMutations()
    {
     if(Input.GetKeyDown(KeyCode.M))
       {
         ENABLE_ALL_MUTS(); 
       }
    }
    public void ENABLE_ALL_MUTS()//Allows the player to try all the Mutations. 
    {
            HealBTN.SetActive(true);
            FireBallBTN.SetActive(true);
            SpitAcidBTN.SetActive(true);            
            FreezeBTN.SetActive(true);
            ElectrifyBTN.SetActive(true);
            LifeStealBTN.SetActive(true);
            MistBTN.SetActive(true);
    }
    #endregion 
    
    public void ClearBattleText()
    {
        BigBattleTextRED.text = "";
        BigBattleTextGREEN.text ="";
        BigBattleTextBLUE.text = ""; 
    }
    #region EnemyDeadCheck()
    public void EnemyDeadCheck()
    {
        if(enemyUnit.CurrentHP <= 0)
        {
            Debug.Log("Enemy IS DEAD");
             
        }
    }
    #endregion 
    #region PlayerDeadCheck()
    public void PlayerDeadCheck()
    {
        Debug.Log("Player Dead Check?");
         //Check if lost. 
       if(playerUnit.CurrentHP <= 0)
       {
            PLEF_ON(); 
            PLEFScript.Player_Die_Anim();
            state = BattleState.LOST;
            Debug.Log("Restart Game");
            dialogueText.text = playerUnit.UnitName + " was defeated.";
            
            PLEF_OFF(); 
            SceneManager.LoadScene(0);

//            
        }
        else
        {
        Debug.Log("Alive");
        
        }
        
    }
    #endregion
    #region WPN_ON()
    public void WPN_ON()
    {   
        
        
     //Chooses the Weapon from the weapon array.
        // WPNObject.SetActive(true); //Turns the display on
        WPN_Anim_Holder.SetActive(true);
        WPNScript.WPN_Decider();
        
        Debug.Log("Weapon Animation ON!");
    
    }
    #endregion
    #region WPN_OFF()
    public void WPN_OFF()//Used on EnemyTurn() to ensure that the WPN animation doesn't play during the Nurses turn.
    {
        WPN_Anim_Holder.SetActive(false);
        //WPNObject.SetActive(false);//Turns off the Animation
        PLEFScript.Player_Idle_Anim();//Clears the Animation Buffer. 
     
    }
    #endregion
    #region MUT_ON()
    public void MUT_ON()
    {
        PLEF_ON();
        PLEFScript.Player_3Way_Anim(); //Displays the player Anim that uses 'magic'
        MUTObject.SetActive(true);
    }
    #endregion
    #region MUT_OFF()
    public void MUT_OFF()
    {
        MUTObject.SetActive(false);
        PlayerBattleObject_ImageFile.SetActive(true);
        MUTScript.Idle_Mutation_Anim();//Clears the Animation Buffer. 
    }
    #endregion
    #region PLEF_ON()
	public void PLEF_ON()
    {
        PlayerBattleObject_ImageFile.SetActive(false);
        PLEFObject.SetActive(true);
    }
    #endregion
    #region PLEF_OFF()
    public void PLEF_OFF()
    {
        PLEFObject.SetActive(false);
        PlayerBattleObject_ImageFile.SetActive(true);
        PLEFScript.Player_Idle_Anim();//Clears the Animation Buffer. 
    }
    #endregion 
	//Random Number Generator that takes two values and rolls a random number between them.
    #region Roll(MinNum, MaxNum)
	public int Roll(int MinNum, int MaxNum) //This is a script local roll system
	{
		
		int num = Random.Range(MinNum, MaxNum);
		return num;
	}
    #endregion
    #region EnemyPreFabSelector()
	void EnemyPrefabSelector()
	{
		if(GlobalsScript.RandomEncounterCategory == 0 )
		{
			GameObject enemyGO= Instantiate(EnemyArray[0], enemyBattleStation);
			enemyUnit = enemyGO.GetComponent<UnitScript>();

			//
		}
		if(GlobalsScript.RandomEncounterCategory == 1 )
		{
			GameObject enemyGO= Instantiate(EnemyArray[1], enemyBattleStation);
			enemyUnit = enemyGO.GetComponent<UnitScript>();

		}
		if(GlobalsScript.RandomEncounterCategory == 2 )
		{
			GameObject enemyGO= Instantiate(EnemyArray[2], enemyBattleStation);
			enemyUnit = enemyGO.GetComponent<UnitScript>();

		}
		
		if(GlobalsScript.RandomEncounterCategory == 3 )
		{
			GameObject enemyGO= Instantiate(EnemyArray[3], enemyBattleStation);
			enemyUnit = enemyGO.GetComponent<UnitScript>();

		}
		if(GlobalsScript.RandomEncounterCategory == 4 )
		{
			GameObject enemyGO= Instantiate(EnemyArray[4], enemyBattleStation);
			enemyUnit = enemyGO.GetComponent<UnitScript>();

		}
		if(GlobalsScript.RandomEncounterCategory == 5 )
		{
			GameObject enemyGO= Instantiate(EnemyArray[5], enemyBattleStation);
			enemyUnit = enemyGO.GetComponent<UnitScript>();

		}
		if(GlobalsScript.RandomEncounterCategory == 6 )
		{
			GameObject enemyGO= Instantiate(EnemyArray[6], enemyBattleStation);
			enemyUnit = enemyGO.GetComponent<UnitScript>();

		}
		if(GlobalsScript.RandomEncounterCategory == 7 )
		{
			GameObject enemyGO= Instantiate(EnemyArray[7], enemyBattleStation);
			enemyUnit = enemyGO.GetComponent<UnitScript>();

		}
		if(GlobalsScript.RandomEncounterCategory == 8 )
		{
			GameObject enemyGO= Instantiate(EnemyArray[8], enemyBattleStation);
			enemyUnit = enemyGO.GetComponent<UnitScript>();
		}
	}
		#endregion


	//This function is called to setup the battle and instantiate 
	//the player and enemy prefabs
	#region UpdateHUD()
	//This updates Player and Enemy Life Totals on the HUD. 
	public void UpdateHUD()
	{
		//Player PSY Points Update HUD
		if(playerUnit.PsyPoints <= 0)
		{
			playerUnit.PsyPoints = 0; 
		}
		string playerPSYcurrent = playerUnit.PsyPoints.ToString(); 
		PlayerPSYNumbers.text = playerPSYcurrent.ToString();
		
		//Player Hit Points Update HUD
		if(playerUnit.CurrentHP <= 0)
		{
			playerUnit.CurrentHP = 0; 
		}
		
        if(playerUnit.MaxHP <= 0)
        {
            Debug.Log("Error here MAXHP Cannot be zero!");
        }
		string playerHPcurrent = playerUnit.CurrentHP.ToString(); 
		string playerHPmax = playerUnit.MaxHP.ToString();  
		PlayerHPNumbers.text = playerHPcurrent + "/" + playerHPmax; 
		
		//Enemy Update HUD
		if(enemyUnit.CurrentHP <= 0)
		{
			enemyUnit.CurrentHP = 0;
            EnemyDeadCheck();
            EndBattle();
		}
      
		Debug.Log("EnemyHP:" + enemyUnit.CurrentHP + "/" + enemyUnit.MaxHP);
		string enemyHPcurrent = enemyUnit.CurrentHP.ToString(); 
		string enemyHPmax = enemyUnit.MaxHP.ToString();  
		Debug.Log("EnemyHP string format:" + enemyHPcurrent + "/" + enemyHPmax);
		EnemyHPNumbers.text = enemyHPcurrent + "/" + enemyHPmax; 
		
		
		
	}
    #endregion
    #region SetupBattle()
	IEnumerator SetupBattle()
	{
		Debug.Log("SetupBattle() - BATTLE _ STARTS_ HERE _ WE _ GO!");
        //WPN_Decider(); 
		//AudioHandlerScript.BattleSongArray[0].Play();//Play Battle soundtrack
		GameObject playerGO = Instantiate(playerPrefab,playerBattleStation); //Load Player Prefab
		playerUnit = playerGO.GetComponent<UnitScript>(); //Setup Player Stats
		EnemyPrefabSelector(); //Select Enemy Prefab
		
		//DEBUG LINE: GlobalsScript.PlayerLevel = 6;
		//DEBUG LINE: GameObject enemyGO= Instantiate(EnemyArray[1], enemyBattleStation);
		dialogueText.text = GlobalStringText.BattleStrings[36] + enemyUnit.UnitName + GlobalStringText.BattleStrings[37]; //Notify Player in status window
		
		SetLevel(); //Apply Level Bonuses to basic Player Prefab based on player level / Activate Mutation Buttons.
		//playerHUD.SetHUD(playerUnit); //Set Player HUD to reflect player stats
		//enemyHUD.SetHUD(enemyUnit); //Set Player HUD to reflect enemy stats
		UpdateHUD();
		yield return new WaitForSeconds(2f); //Allow 2 seconds to load	
		state = BattleState.PLAYERTURN; //Switch turn to player control
		PlayerPrompt(); //Display a message. 
	}
	#region PlayerPrompt()
	void PlayerPrompt()//Used in several places to prompt user on the MainMenu. //Used to activate and deactivate animations. //And to end the game if the player's current HP is zero or below.
	{
   
        EnemyDeadCheck();
         PlayerDeadCheck(); //Checks if the player is dead
         MUT_OFF();//Turns off mutation animations
         PLEF_OFF();//Turns off status effect animations
         WPN_OFF();//Turns off the weapon animations
         dialogueText.text = GlobalStringText.BattleStrings[0];//Displays a prompt for the user. 
         ClearBattleText();
	}
	#endregion
	//This function randomizes the enemy and player's chance to hit each other.  
	//Low is the lowest number and High is the highest needed to pass. The Mod number changes the difficulty.
    #region DidIHit()
	public bool DidIHit(int Low, int High,int Mod)
	{
		float Med = (High/2) - Mod; 
		float RollNumber = Roll(Low,High);
		if (RollNumber > Med)
		{
			//Hit
			return true; 
		}
		else
		{
			//Miss
			return false; 
		}
	}
	
    #endregion
    #region PlayerAttack()
	//This function takes care of the player's attack
	IEnumerator PlayerAttack()
	{
    
        PlayerDeadCheck(); 
       // BattleAnimScript.Player_Hurt_Anim();
		Debug.Log("PlayerAttack()");
		Debug.Log("Player Turn");
        
		WPN_ON(); //Turns the proper weapon animation on. 
        // WPNAnimScript.
		bool DidIHitIt = DidIHit(1,6,1);//Returns a random true or false
		Debug.Log("DidIHitIt = " + DidIHitIt);
		if(DidIHitIt == true)//The Player hit the enemy
		{
            
            
			AudioHandlerScript.BattleSoundEffectArray[0].Play();//Play a sound
			dialogueText.text = playerUnit.UnitName + GlobalStringText.BattleStrings[1];//Output dialog
			enemyUnit.TakeDamage(playerUnit.Damage + GlobalsScript.PlayerDamageBonus);//Do I need this? 
			UpdateHUD(); //enemyHUD.SetHP(enemyUnit.CurrentHP);//HUD Updates
		
            //Explosion.Play(); //Animation of Explosion -- This needs to be replaced with 
            //Multiple Hit Images --------------------------
            //----------------------------------------------------------------------
            
           //This needs to be its own function because it uses a different type of weapon and a different anim
           //for each hit 
            
            
			//Player's attack hits
			//bool isDead = enemyUnit.TakeDamage(playerUnit.Damage); //enemy takes damage
			//Status bar notifies player
			yield return new WaitForSeconds(4f);
			
			//Checks if the player killed the enemy
			if(enemyUnit.CurrentHP <= 0)
			{
				AudioHandlerScript.BattleSoundEffectArray[4].Play();
				GlobalsScript.EncounterStopper = false; 
				state = BattleState.WON;
                EnemyDeadCheck();
                Debug.Log("End the battle from PlayerAttack()");
				EndBattle();
				
					//End the battle, player has won
			}
			else //This line switches the turn, the other is redundant and not used
			{
				Debug.Log("Keep Fighting");
				state = BattleState.ENEMYTURN;
				StartCoroutine(EnemyTurn());
				//Enemy Turn, still fighting
			}
			
		
		}
		else if(DidIHitIt == false)//Player Missed. 
		{
			AudioHandlerScript.BattleSoundEffectArray[2].Play();//Play sound
			dialogueText.text = playerUnit.UnitName + GlobalStringText.BattleStrings[2];
			yield return new WaitForSeconds(2f);
		
			//Missed the attack, switch to enemy turn
			StartCoroutine(SwitchTurns()); 
		}
	}
	#endregion
    #region EnemyTurn()
	//This functions takes care of the enemies turn. 
	IEnumerator EnemyTurn()
	{ 
        PlayerDeadCheck(); 
        EnemyDeadCheck(); 
		Debug.Log("EnemyTurn()");
        WPN_OFF();//Clears the WPN Anim. 
		int defenseapplied = 0; //For the DefendBTN()
		PlayerActionTaken = false;//reset for next turn. 
		//AI
		//if player is near death, then don't attack
		//if player is full health attack
		//if enemy is near death, heal or use special attack 
		bool DidIHitIt = DidIHit(0,6,0);
		if(TempDefense == true)
		{
			defenseapplied = enemyUnit.Damage / 2; //When the player defends for an action, he can dodge the attack and use Heal potions or Attack 
		}
		
		if(DidIHitIt == true)
		{
			//Enemy hits the player
            PLEF_ON();
            PLEFScript.Player_Hurt_Anim();
			AudioHandlerScript.BattleSoundEffectArray[1].Play();
			dialogueText.text = enemyUnit.UnitName + GlobalStringText.BattleStrings[3];
			yield return new WaitForSeconds(1f);
			bool isDead = playerUnit.TakeDamage(enemyUnit.Damage - defenseapplied);
				dialogueText.text = playerUnit.UnitName + GlobalStringText.BattleStrings[4];
			UpdateHUD(); //HUD_Update_Life_Totals();
			yield return new WaitForSeconds(1f);
			if(isDead)//Find out if the player is dead or not
			       {
                PlayerDeadCheck(); 
		           }
			else
			{// player still alive, switch to players turn
            
				dialogueText.text = playerUnit.UnitName + GlobalStringText.BattleStrings[5];
				yield return new WaitForSeconds(1f);
                PlayerBattleObject_ImageFile.SetActive(true);
			state = BattleState.PLAYERTURN;
				PlayerPrompt();
			         }
		}
		else
		{
			//Enemy missed, switch to player's turn
            PLEF_ON();
                PLEFScript.Player_Missed_Anim();
            yield return new WaitForSeconds(3f);
            //PlayerBattleObject_ImageFile.SetActive(true);
			AudioHandlerScript.BattleSoundEffectArray[2].Play();
			dialogueText.text = enemyUnit.UnitName + GlobalStringText.BattleStrings[2];
			yield return new WaitForSeconds(1f);
			TempDefense = false; //Turn off the temp defense bonus gained from charging. 
		    state = BattleState.PLAYERTURN;
			PlayerPrompt();
		}
	}
	#endregion
    #region SwitchTurns()
    
    IEnumerator SwitchTurns()//Changes from player to enemy turn. 
    {
        PlayerDeadCheck();  
        EnemyDeadCheck();
        
            if(enemyUnit.CurrentHP <= 0)//End the battle... unless...
            {
                AudioHandlerScript.BattleSoundEffectArray[4].Play();
                state = BattleState.WON;
                EndBattle();
                //End the battle, player has won
            }
            else//The enemy is still alive
            {
                Debug.Log("switch turns");
                ClearBattleText();
                dialogueText.text = GlobalStringText.BattleStrings[15] + enemyUnit.UnitName + GlobalStringText.BattleStrings[5];
                yield return new WaitForSeconds(3f);
                state = BattleState.ENEMYTURN; 
                StartCoroutine(EnemyTurn());
            }
        
        // yield return "Switch Complete";
        //UpdateHUD();
        
    
    }
    #endregion
	//Player Level UP: Checks to see if the player has gained a new level. Simplistic system at the moment. Assignment 3 will see different levels of exp to attain higher levels and new perks at 
	//certain levels.
	
	#region CheckForLevelUp()
	void CheckForLevelUp()//Check if the player has enough experience to go up a level and then reset the experience accumulated
	//This goes at EndBattle()
	{
		if(GlobalsScript.PlayerEXP == Levels[GlobalsScript.PlayerLevel])
		{
            PLEF_ON();
            PLEFScript.Player_FlashMultiClr_Anim();
			AudioHandlerScript.BattleSoundEffectArray[6].Play();
			dialogueText.text = playerUnit.UnitName + GlobalStringText.BattleStrings[6];
			GlobalsScript.PlayerLevel += 1; 
			GlobalsScript.PlayerEXP = 0; //Reset the amount of experience for the next level
		}
	}
	#endregion
    #region Level Functions
	void ConvertBonustoNormal()
	{
		playerUnit.CurrentHP = GlobalsScript.PlayerCurrentHP; 
		playerUnit.MaxHP += GlobalsScript.PlayerCurrentMAXHP + GlobalsScript.PlayerHPBonus;
		playerUnit.PsyPointsMax += GlobalsScript.PlayerPsyPointBonus;
		playerUnit.Damage += GlobalsScript.PlayerDamageBonus;  
	}
    
    
	void SetLevel()//This is loaded during the setup phase to ensure that the bonuses match the level and that 
	//the appropriate Spells are enabled for that Player level...
	{
		Debug.Log("Set Level Function Triggered");
		Debug.Log("XP Reqd for level 0:" + Levels[GlobalsScript.PlayerLevel]);
		Debug.Log("Player's Level:" + GlobalsScript.PlayerLevel);
		if(GlobalsScript.PlayerLevel == 0)
		{
			Debug.Log("Player is Level 0");
			HealBTN.SetActive(true);
		}
		if(GlobalsScript.PlayerLevel == 1)
		{
			
			Debug.Log("Player is Level 1");
			GlobalsScript.PlayerHPBonus = 2;
			GlobalsScript.PlayerPsyPointBonus = 2;
			//GlobalsScript.PlayerHealsBonus += 1;
			//GlobalsScript.PlayerDamageBonus += 1;
		
				HealBTN.SetActive(true);
			FireBallBTN.SetActive(true);
		}
		if(GlobalsScript.PlayerLevel == 2)
		{
			
			Debug.Log("Player is Level 2");
			GlobalsScript.PlayerHPBonus = 5;
			GlobalsScript.PlayerPsyPointBonus = 5;
			//GlobalsScript.PlayerHealsBonus += 1;
			GlobalsScript.PlayerDamageBonus += 1;
			
			HealBTN.SetActive(true);
			FireBallBTN.SetActive(true);
			SpitAcidBTN.SetActive(true);
		}
		if(GlobalsScript.PlayerLevel == 3)
		{
			
			Debug.Log("Player is Level 3");
			GlobalsScript.PlayerHPBonus = 10;
			GlobalsScript.PlayerPsyPointBonus = 10;
			//GlobalsScript.PlayerHealsBonus += 1;
			GlobalsScript.PlayerDamageBonus = 2;
			
			HealBTN.SetActive(true);
			FireBallBTN.SetActive(true);
			SpitAcidBTN.SetActive(true);
			FreezeBTN.SetActive(true);
		}
		if(GlobalsScript.PlayerLevel == 4)
		{
			
			Debug.Log("Player is Level 4");
			GlobalsScript.PlayerHPBonus = 15;
			GlobalsScript.PlayerPsyPointBonus = 15;
			//GlobalsScript.PlayerHealsBonus += 1;
			GlobalsScript.PlayerDamageBonus = 2;
			
			HealBTN.SetActive(true);
			FireBallBTN.SetActive(true);
			SpitAcidBTN.SetActive(true);			
			FreezeBTN.SetActive(true);
			ElectrifyBTN.SetActive(true);

		}
		if(GlobalsScript.PlayerLevel == 5)
		{
			
			Debug.Log("Player is Level 5");
			GlobalsScript.PlayerHPBonus = 20;
			GlobalsScript.PlayerPsyPointBonus = 20;
			//GlobalsScript.PlayerHealsBonus += 1;
			GlobalsScript.PlayerDamageBonus = 3;
			
			HealBTN.SetActive(true);
			FireBallBTN.SetActive(true);
			SpitAcidBTN.SetActive(true);			
			FreezeBTN.SetActive(true);
			ElectrifyBTN.SetActive(true);
			LifeStealBTN.SetActive(true);

		}
		if(GlobalsScript.PlayerLevel == 6)
		{
			
			Debug.Log("Player is Level 6");
			GlobalsScript.PlayerHPBonus = 30;
			GlobalsScript.PlayerPsyPointBonus = 30;
			//GlobalsScript.PlayerHealsBonus += 1;
			GlobalsScript.PlayerDamageBonus = 3;
			
			HealBTN.SetActive(true);
			FireBallBTN.SetActive(true);
			SpitAcidBTN.SetActive(true);			
			FreezeBTN.SetActive(true);
			ElectrifyBTN.SetActive(true);
			LifeStealBTN.SetActive(true);
			MistBTN.SetActive(true);

		}
		ConvertBonustoNormal(); 
		
		
		
	}
    #endregion
	#endregion
    
    #region CollectCash()
	void CollectCash()//Triggered during EndBattle(), assigns the player the money the enemy was holding. 
	{
		GlobalsScript.PlayerMoneyTotal += enemyUnit.MoneyHeld; 
		
	}
    #endregion
    #region CollectXP()
	void CollectXP()//Triggered during EndBattle(), assigns the player the experience the enemy was holding.
	{
		dialogueText.text = playerUnit.UnitName + GlobalStringText.BattleStrings[7] + enemyUnit.EnemyEXP + GlobalStringText.BattleStrings[8]; 
		GlobalsScript.PlayerEXP += enemyUnit.EnemyEXP;
	}
    #endregion
	#region GameOverReturnToTitleScreen()
	IEnumerator GameOverReturnToTitleScreen()//Will give option to return to last save point. Returns to Intro screen (0). 
	{
		AudioHandlerScript.BattleSoundEffectArray[5].Play();
		dialogueText.text = playerUnit.UnitName + GlobalStringText.BattleStrings[9];
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(0);
			}
	//Adds player EXP to the total at the end of a battle. 
	#endregion
    #region EndBattle()
    void EndBattle()
	{ 
		PlayerActionTaken = false; //reset
		if(state == BattleState.WON)
		{
            Debug.Log("ENDING THE BATTLE CAUSE PLAYER HAS WON");
			dialogueText.text = playerUnit.UnitName + GlobalStringText.BattleStrings[10];
			//yield return new WaitForSeconds(1f);
			CollectXP();//Add XP
			CollectCash(); //Add money
			CheckForLevelUp(); //Check if Player leveled up
			//Update for the Overworld map in case the player went up a level
			GlobalsScript.PlayerCurrentHP = playerUnit.CurrentHP;//Change HP for overworld  
            GlobalsScript.PlayerCurrentMAXHP = playerUnit.MaxHP;
			Debug.Log("PlayerCurrent HP" + GlobalsScript.PlayerCurrentHP + " Matches the PlayerUnit.CurrentHP of" + playerUnit.CurrentHP);
            Debug.Log("PlayerCurrent MAXHP:"  + GlobalsScript.PlayerCurrentMAXHP + " Matches the player unit MAXHP of " + playerUnit.MaxHP);
           
            //            ComboScript.ResetCombos();//The Combos aren't being reset cause they're not being SAVED. 
			SaveAndReturnToScene(); 
    
		}
		else if(state == BattleState.LOST)
		{
            Debug.Log("Return to title screen");
			GameOverReturnToTitleScreen();//Allow player to reload from last save point
			
		}
	}
	#endregion
	//Returns the player to the area specified from the previous scene.
    #region SaveAndReturnToScene() = Save & Load Area
	void SaveAndReturnToScene()
	{
        
		//PlayerMAPTransform.position = GlobalsScript.lastposition;//saves the last position at regular intervals
	    //Need a custom SAVER, so that the battle experience is also applied when returning to the game.. 
        
        //BUILD NOTES: Need to save XP gained, Cash gained, Current Level, CurrentHP and Current PSY. 
        GameSaverScript.SaveBattleStats(); 
        Debug.Log("XP after battle:" + GlobalsScript.PlayerEXP);
        Debug.Log("Player Money after battle:" + GlobalsScript.PlayerMoneyTotal);
        GameSaverScript.LoadFromBattle(); //NEed to reload the map scene... but then you need to reload the game at the start()
        GlobalsScript.EncounterStopper = false;
        
		SceneManager.LoadScene(GlobalsScript.SceneBuildIndex); //Please ensure that the MAP SCENE 
        //is not being changed to the battle scene at anytime or it will not reload to the overworld.
 
		Debug.Log("BATTLE _ ENDS _ Return to scene #:" + GlobalsScript.SceneBuildIndex);
	}
	#endregion
  
    
    #region Buttons - BTN -
	//Used when ATTACK is pressed during a battle. 
	public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
		{ 
			Debug.Log("Not Your Turn!");
			return;
		}
		else if(PlayerActionTaken == false)
		{
			StartCoroutine(PlayerAttack());
			PlayerActionTaken = true; 
		}
		else
		{
			Debug.Log("Nope, don't cheat!");
		}
	}
	
	public void ItemsBTN()
	{
		Debug.Log("Items menu activated");
		MainMenu.SetActive(false);
		ItemsMenu.SetActive(true);
	}
	
	public void ItemsBackBTN()
	{
		
		Debug.Log("Items Menu Deactivated");
		MainMenu.SetActive(true);
		ItemsMenu.SetActive(false);
		PlayerPrompt();
	}
	 #region Items Menu - PSY POTION BUTTON
    public void PsyPotionButton()
    {
        GlobalsScript.PsyPotionsHeld -= 1;
        GlobalsScript.PlayerCurrentPsyPoints += 30; 
        ChangeItemsMenuToMainMenuWindow(); 
    }
    #endregion
	IEnumerator Charge()//Charge does 2 things. It allows the player to recover PsyPoints for spells and also 
	//lifts the charge level.
	{
		if (state != BattleState.PLAYERTURN)
		{ 
			Debug.Log("Not Your Turn!");
		
		}
		else if(PlayerActionTaken == false)
		{
            PLEF_ON();
			PLEFScript.Player_Wave_Anim();
			//	TempDefense = true; 
			GlobalsScript.ChargeUp = 1; 
			
			int AmountRecovered = Roll(5, 20);
		    
			GlobalsScript.PlayerCurrentPsyPoints += AmountRecovered;
			
            //Ensure the player doesn't get MORE than the current Psypoints 
			if (GlobalsScript.PlayerCurrentPsyPoints > GlobalsScript.PlayerCurrentMAXPsyPoints)
			{
				GlobalsScript.PlayerCurrentPsyPoints = GlobalsScript.PlayerCurrentMAXPsyPoints;
				dialogueText.text = GlobalStringText.BattleStrings[11] + playerUnit.UnitName + GlobalStringText.BattleStrings[12];
			}
			else
			{
				dialogueText.text = GlobalStringText.BattleStrings[11] + playerUnit.UnitName + GlobalStringText.BattleStrings[13]  + AmountRecovered + GlobalStringText.BattleStrings[14];
	
			}
		
			yield return new WaitForSeconds(4f);
			
		}
        playerUnit.PsyPoints = GlobalsScript.PlayerCurrentPsyPoints;
		UpdateHUD(); 
		StartCoroutine(SwitchTurns());
	}
    
	public void ChangeMutationsToMainWindow()
	{
		MutationsMenu.SetActive(false);
		MainMenu.SetActive(true);
	}
	void ChangeItemsMenuToMainMenuWindow()
	{
		ItemsMenu.SetActive(false);
		MainMenu.SetActive(true);
	}
	public void ChargeBTN()
	{
		StartCoroutine(Charge());
	}
	public void SpikeBombBTN()
	{
		StartCoroutine(SpikeBomb());
		
	}
	
	void HUD_Update_Life_Totals()//Update Life Totals
	{   
		enemyHUD.SetHP(enemyUnit.CurrentHP);//HUD Updates
		playerHUD.SetHP(playerUnit.CurrentHP);
	}
	
	#region SpikeBomb()
	IEnumerator SpikeBomb()
	{
		if (state != BattleState.PLAYERTURN)
		{ 
			Debug.Log("Not Your Turn!");
		}
		else if(PlayerActionTaken == false && GlobalsScript.SpikeBombsHeld > 0)
		{
			
			ItemsMenu.SetActive(false);
			MainMenu.SetActive(true);
		    Debug.Log("Spike Bomb Used");	
			GlobalsScript.SpikeBombsHeld -= 1;
			enemyUnit.TakeDamage(40);//enemyUnit.CurrentHP -= 40;  
			UpdateHUD();//HUD_Update_Life_Totals();
			dialogueText.text =  GlobalStringText.BattleStrings[16] + enemyUnit.UnitName + GlobalStringText.BattleStrings[17] ;
			//PlayerActionTaken = true;
			yield return new WaitForSeconds(2f);
			ChangeItemsMenuToMainMenuWindow();
			StartCoroutine(SwitchTurns());//state = BattleState.ENEMYTURN;  //StartCoroutine(EnemyTurn());
   		    
		}
		else
		{
			Debug.Log("No bombs left");
			ChangeItemsMenuToMainMenuWindow(); 
			dialogueText.text = GlobalStringText.BattleStrings[18];
			
		}
		
	}
    #endregion
	//Open Mutations Menu and disable other buttons for a second, if player picks a Mutation to use then advance to enemy turn. 
	public void MutationsBTN()
	{		
		Debug.Log("Mutations Menu Active");
			MainMenu.SetActive(false);
			MutationsMenu.SetActive(true);
	}
	//Return to the Main Battle Menu options
	public void MutationsBackBTN()
	{
		
		Debug.Log("Mutations Menu Deactivated");
		ChangeMutationsToMainWindow();
		PlayerPrompt();
	}
	#region HEAL POTION
	public void HealPotionBTN()//Spend a heal potion to recover hit points. 
	{
		if(GlobalsScript.Heals > 0) //If the player has a potion
		{
            PLEF_ON();
            PLEFScript.Player_Heal_Anim(); 
			ChangeItemsMenuToMainMenuWindow(); 
			GlobalsScript.Heals -= 1;//Subtract a heal from the heal potions held
			int add = GlobalsScript.Roll(7, 20); //Randomly add this much healing
			playerUnit.Heal(add);//Heals between 7 and 20 points
			if(GlobalsScript.PlayerCurrentHP > GlobalsScript.PlayerCurrentMAXHP)
			{ //Don't exceed max HP
				     GlobalsScript.PlayerCurrentHP = GlobalsScript.PlayerCurrentMAXHP;
			} 
			dialogueText.text = playerUnit.UnitName + GlobalStringText.BattleStrings[13]  + add + GlobalStringText.BattleStrings[19] + GlobalStringText.BattleStrings[20] + playerUnit.UnitName + GlobalStringText.BattleStrings[21] + GlobalsScript.Heals + GlobalStringText.BattleStrings[22];
			UpdateHUD();//HUD_Update_Life_Totals();//Update Life on the HUD
			StartCoroutine(SwitchTurns());  //Switch turns
		}
		else //Player has no more potions to use
		{
			ChangeItemsMenuToMainMenuWindow();
			dialogueText.text = GlobalStringText.BattleStrings[23];
		}
	 
	}
    #region PSY POTION
	IEnumerator PsyPotionBTN()//Psy Potions are RARE
	{
		
		if(GlobalsScript.PsyPotionsHeld > 0)
		{
			GlobalsScript.PsyPotionsHeld -= 1;
			
			GlobalsScript.PlayerCurrentPsyPoints = GlobalsScript.PlayerCurrentMAXPsyPoints;
			dialogueText.text = playerUnit.UnitName + GlobalStringText.BattleStrings[24];
			yield return new WaitForSeconds(3f);
			ChangeItemsMenuToMainMenuWindow();
			StartCoroutine(SwitchTurns());
		}
		else
		{
			
			ChangeItemsMenuToMainMenuWindow();
			dialogueText.text = GlobalStringText.BattleStrings[25];
		}
	 
	}

    #endregion
    
	//These are the spells [Mutations] that the player can use. 
	#region Mutation Mechanics
	#region DOUBLE DAMAGE
    void DoubleDamage(string element)
	{
		int totalDamage =  GlobalsScript.Roll(5,20);//The Damage applied from a fire spell	
		totalDamage *= 2;
		enemyUnit.TakeDamage(totalDamage);
        BigBattleTextRED.text = "DOUBLE DAMAGE!";
		dialogueText.text = enemyUnit.UnitName + GlobalStringText.BattleStrings[26] + element + GlobalStringText.BattleStrings[27];
	}
    #endregion
    #region HALF DAMAGE
	void HalfDamage(string element)
	{
		int totalDamage =  GlobalsScript.Roll(5,20);//The Damage applied from a fire spell	
		totalDamage /= 2;
        BigBattleTextBLUE.text = "1/2 DAMAGE";
		enemyUnit.TakeDamage(totalDamage);
		//Placeholder for Graphic
		dialogueText.text = enemyUnit.UnitName +GlobalStringText.BattleStrings[28] + element + GlobalStringText.BattleStrings[29];
	}
	#endregion
	#region Mutations - FireBallSpell()
	public void FireBallSpell()
	{
		if(playerUnit.PsyPoints > 3)
		{
			ChangeMutationsToMainWindow();//Changes window back to main so that the player can read the status updates
			
            playerUnit.PsyPoints -= 3; 
			if(enemyUnit.weak2fire)
			{
				ComboScript.AddToCombo('F');//Added here to combo 
			 	ComboScript.CheckComboDamage();
			   DoubleDamage("Fire");
				
			} 
			if(enemyUnit.strong2fire)
			{ 
			 	HalfDamage("Fire");
			}
			else
			{
			 	Debug.Log("Neither weak nor strong and no effect to damage");
			}
            MUT_ON();
            MUTScript.Fire_Mutaion_Anim();
           
			ComboScript.AddToCombo('F');
			UpdateHUD();//HUD_Update_Life_Totals();
			 //Does between 5 and 20 damage. 
			PlayerActionTaken = true; // disables player from taking another action.
			StartCoroutine(SwitchTurns()); //Changes to enemies turn.  
	
		}
		else
		{   ChangeMutationsToMainWindow();
			dialogueText.text = GlobalStringText.BattleStrings[30];
		}
		
	}    
    #endregion
	#region Mutations - AcidSpell()
	public void AcidSpell()
	{
		if(playerUnit.PsyPoints > 3)
		{
			ChangeMutationsToMainWindow();//Changes window back to main so that the player can read the status updates
            MUT_ON();
            MUTScript.Acid_Mutaion_Anim();
			playerUnit.PsyPoints -= 3; 
			if(enemyUnit.weak2acid)
			{
			 	DoubleDamage("Acid");
		     	ComboScript.CheckComboDamage();
			} 
			if(enemyUnit.strong2acid)
			{
			 	HalfDamage("Acid");
			}
			else
			{
		     	Debug.Log("Neither weak nor strong and no effect to damage");
			}
			//Does between 5 and 20 damage. 
			ComboScript.AddToCombo('A');
          
			UpdateHUD();//HUD_Update_Life_Totals();
			PlayerActionTaken = true; // disables player from taking another action.
			StartCoroutine(SwitchTurns()); //Changes to enemies turn.  
	
		}
		else
		{
			dialogueText.text = GlobalStringText.BattleStrings[30];
		}
		
	
		
	}
        #endregion
	#region Mutations - Electricity Spell()
	public void ElectricitySpell()
	{
		
		ChangeMutationsToMainWindow();//Changes window back to main so that the player can read the status updates
        MUT_ON();
        MUTScript.Shock_Mutaion_Anim();
		if(playerUnit.PsyPoints > 3)
		{
			playerUnit.PsyPoints -= 3; 
			if(enemyUnit.weak2energy)
			{
			 	DoubleDamage("Electricity");
				ComboScript.CheckComboDamage();
			} 
			if(enemyUnit.strong2energy)
			{
			 	HalfDamage("Electricity");
			}
			else
			{
				 Debug.Log("Neither weak nor strong and no effect to damage");
			}
			ComboScript.AddToCombo('E');
			//Does between 5 and 20 damage. 
			UpdateHUD();//HUD_Update_Life_Totals();
			PlayerActionTaken = true; // disables player from taking another action.
			StartCoroutine(SwitchTurns()); //Changes to enemies turn.  
	
		}
		else
		{
			dialogueText.text = GlobalStringText.BattleStrings[30];
		}
		
	}
        #endregion
	#region Mutations - IceSpell()
	public void IceSpell()
	{
		if(playerUnit.PsyPoints > 3)
		{
            MUT_ON();
            MUTScript.Ice_Mutaion_Anim();
			ComboScript.AddToCombo('I'); //Ice Activated; 
			ComboScript.CheckIceAndFireCombos();//Just check once. 
			playerUnit.PsyPoints -= 3; 
			if(enemyUnit.weak2ice)
			{
			  	DoubleDamage("Ice") ;
					    ComboScript.CheckComboDamage();
			}
			
			if(enemyUnit.strong2ice)
			{
			
			 	HalfDamage("Ice");
			}
			else
			{
			 	Debug.Log("Neither weak nor strong and no effect to damage");
			}
			//Does between 5 and 20 damage. 
			PlayerActionTaken = true; // disables player from taking another action.
			UpdateHUD();//HUD_Update_Life_Totals();
			StartCoroutine(SwitchTurns()); //Changes to enemies turn.  
	
		}
		else
		{
			dialogueText.text = GlobalStringText.BattleStrings[30];
		}
		
	}
        #endregion
    #region Mutations - LifeSteal()
	public void LifeSteal()
	{
		int totalLifeStolen = (Roll(5,20) * GlobalsScript.ChargeUp); 
		if(playerUnit.PsyPoints > 15)
		{
            MUT_ON();
            MUTScript.LifeSteal_Mutaion_Anim();
			enemyUnit.TakeDamage(totalLifeStolen);
			playerUnit.CurrentHP += totalLifeStolen; 

		     if(playerUnit.CurrentHP > playerUnit.MaxHP)
		     {
			   playerUnit.CurrentHP = playerUnit.MaxHP;
			   dialogueText.text = playerUnit.UnitName + GlobalStringText.BattleStrings[31];
		     }
		     else
		     {
		     	dialogueText.text = playerUnit.UnitName + GlobalStringText.BattleStrings[13] + totalLifeStolen + GlobalStringText.BattleStrings[19];
		     }
	    }
	    else
		{
		  dialogueText.text = GlobalStringText.BattleStrings[30];
		}
		UpdateHUD();//HUD_Update_Life_Totals();
		StartCoroutine(SwitchTurns());
			
	}
        #endregion
    #region Mutations - MistSpell()
	public void MistSpell()//Seperate from the double/half system.
	{
		if((enemyUnit.weak2mist) && (GlobalsScript.ChargeUp == 7) && (ComboScript.ComboChainOn == true) )
		{
			//int totalDamage = Roll(10,20) * GlobalsScript.ChargeUp;
            MUT_ON();
            MUTScript.Mist_Mutaion_Anim();
			playerUnit.PsyPoints -= 10; 
			int SuccessRoll = Roll(1,100);
			if(SuccessRoll < 11)
			{
				     dialogueText.text = GlobalStringText.BattleStrings[32] + enemyUnit.UnitName + GlobalStringText.BattleStrings[33];  
			     enemyUnit.CurrentHP -= 1;
			}
			else
			{
			  	dialogueText.text = GlobalStringText.BattleStrings[34];
			}
			ComboScript.ComboChainOn = false;//Reset the chain 
			UpdateHUD();//HUD_Update_Life_Totals();
			PlayerActionTaken = true; // disables player from taking another action.
			StartCoroutine(SwitchTurns()); //Changes to enemies turn. 
			//MISTY TEXT appears on screen with an animation [like DDR] 
			
		}
		else if(playerUnit.PsyPoints < 10)
		{
			dialogueText.text = GlobalStringText.BattleStrings[30];
		}
		else
		{
			dialogueText.text = GlobalStringText.BattleStrings[34];
			ComboScript.ComboChainOn = false;//Reset the chain 
			UpdateHUD();//HUD_Update_Life_Totals();
			PlayerActionTaken = true; // disables player from taking another action.
			StartCoroutine(SwitchTurns()); //Changes to enemies turn. 
		}
	}
        #endregion
	//This functions takes care of the player heals when they are 
	//triggered during the Battle Scene.
    #region Mutations - HEAL SPELL
	public void HealSpell()
	{
    if(playerUnit.PsyPoints >= 8)
    {
		TempDefense = true; //Adds a defense booster [frustrating when attack hits right after a Heal spell]
		//Heal Spell - Charge Level + HealSpell
		if(GlobalsScript.ChargeUp != 0)
		{
			int TotalHeal = GlobalsScript.ChargeUp * (GlobalsScript.Roll(5, 20)); 
			playerUnit.Heal(TotalHeal);//Heals between 7 and 20 points
			ChangeMutationsToMainWindow();
			dialogueText.text = GlobalStringText.BattleStrings[35] + playerUnit.UnitName + GlobalStringText.BattleStrings[13] + TotalHeal + GlobalStringText.BattleStrings[19];
		}
		else
		{
			int TotalHeal = GlobalsScript.Roll(10,30);
			playerUnit.Heal(TotalHeal);//Heals between 7 and 20 points
			ChangeMutationsToMainWindow();
			dialogueText.text = GlobalStringText.BattleStrings[13] + TotalHeal + GlobalStringText.BattleStrings[19];
		}
		
		playerUnit.PsyPoints -= 8; 
		GlobalsScript.ChargeUp = 0; //Charge Level Resets
		UpdateHUD();//HUD_Update_Life_Totals();
        StartCoroutine(SwitchTurns());//Change to enemy turn
   }
   else
        {
        dialogueText.text = "Not enough PSY Points!";
        ChangeMutationsToMainWindow();
        }
	}
    #endregion
        #endregion
        #endregion
        #endregion
       
   
}

    
    
    	
	


