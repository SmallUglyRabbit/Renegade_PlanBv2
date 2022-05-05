using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro; 

//The GameSaver Object is used to save all data between scenes. 
//Everything is saved using the PlayerPrefs that Unity includes. 
//Unfortunately, PlayerPrefs do not take advantage of arrays 
//and thus it makes saving large amounts of data pretty tendious. 
//I figured i would get to know the save system Unity includes
//before purchasing a more expensive system. 

//The PlayerPrefs also have some bugs in WEBGL which sort of //manifest randomly. In a regular Unity game, scriptable objects
//can be used to save data to a file but with WEBGL, the //playerprefs are saved apparently in the registry as small keys. 
//Instead of using tons of variables, in the future, I'll just 
//be using String Variables with CODES written into them 
//to activate things. 

public class GameSaver : MonoBehaviour
{
    
    #region Variables
    [SerializeField]
    internal ItemChecker ItemCheckerScript;//Checks for items that were picked up 
    [SerializeField]
    GameObject FirstTimers; 
    [SerializeField]
    GameObject ItemChecker;
    public Transform PlayerPosition; //Return to the previous position the player was in before the battle started. 
    public Transform StartingLocation; //Tied to the area where the player starts a new level. 
    public TextMeshProUGUI ParasiteText; 
    public TextMeshProUGUI PlayerText; 
    public TextMeshProUGUI GoalText;   
    //Part of the First System, needed to be convert to 0 and 1 to save bools [work around for Player Prefs] 
    
   
    public static GameSaver GameSaverScriptControl; 
  #endregion
    
    void Awake()//Looks for the first times script. 
    {
        GameSaverScriptControl = this; 
        FirstTimers = GameObject.Find("FirstTimes");
    }
  #region Update() and Start()
   void Update()
    {
        UseSaveKeys(); 
        UseLoadKeys(); 
    }
    
   
    #endregion
 
    
      //Save Current OnScreen Text 
    public void SaveAllActiveStrings()
    {
     if(ParasiteText.text != null)
        {
        PlayerPrefs.SetString("ParasiteTalk",ParasiteText.text);
        }
        if(PlayerText.text != null)
        {
        
        PlayerPrefs.SetString("PlayerTalk",PlayerText.text);
        }
        if(GoalText.text != null)
        {
        
        PlayerPrefs.SetString("GoalText",GoalText.text);
        }
    }
    
    #region SaveLocation() + LoadLocation()
       //Save Player Location on Overworld
      
    public void SaveLocation()
    {
        //error checking
        if(GlobalsScript.SceneBuildIndex == 4)
        {
            Debug.Log("Don't Save location during battle!");
        }
        else
        {
        Debug.Log("SAVING GAME");
        PlayerPrefs.SetInt("SceneBuildIndex",GlobalsScript.SceneBuildIndex);
        Debug.Log("SceneBuildIndex:" + GlobalsScript.SceneBuildIndex);
        PlayerPrefs.SetFloat("lastposition.x",PlayerPosition.transform.localPosition.x);
        Debug.Log("PPX:" + PlayerPosition.transform.localPosition.x);
        PlayerPrefs.SetFloat("lastposition.y",PlayerPosition.transform.localPosition.y);
        Debug.Log("PPY:" + PlayerPosition.transform.localPosition.y);
            
        PlayerPrefs.SetFloat("lastposition.z",PlayerPosition.transform.localPosition.z);
        Debug.Log("PPZ:" + PlayerPosition.transform.localPosition.z);
        }
    }
    //Load player location on the overworld.
    public void LoadLocation()
    {
        float posx = PlayerPrefs.GetFloat("lastposition.x");
        Debug.Log("Last Position X:" + posx);
        float posy = PlayerPrefs.GetFloat("lastposition.y");
        Debug.Log("Last Position Y:" + posy); 
        float posz = PlayerPrefs.GetFloat("lastposition.z");
        Debug.Log("Last Position Z:" + posz);
        int TheSavedScene = PlayerPrefs.GetInt("SceneBuildIndex");
        GlobalsScript.CurrentMapScene = TheSavedScene; 
        GlobalsScript.SceneBuildIndex = TheSavedScene; 
        
        Debug.Log("Scene #:" + TheSavedScene);
        Debug.Log("LOADING: X:" + posx + "  Y:" + posy + "  Z:" + posz);
        GlobalsScript.lastposition = new Vector3 (posx,posy,posz); // 
        SceneManager.LoadSceneAsync(GlobalsScript.CurrentMapScene);
    }
    #endregion
    
 
    //Save Stats 
     #region Save Player Stats()
    public void SavePlayerStats()
    {
     
        PlayerPrefs.SetInt("PlayerHPBonus",GlobalsScript.PlayerHPBonus);
        Debug.Log("Saving: PlayerHPBonus" + GlobalsScript.PlayerHPBonus);
        PlayerPrefs.SetInt("PlayerHealsBonus",GlobalsScript.PlayerHealsBonus); 
        Debug.Log("Saving: PlayerHealsBonus" + GlobalsScript.PlayerHealsBonus);
        PlayerPrefs.SetInt("PlayerPsyPointBonus",GlobalsScript.PlayerPsyPointBonus);
        Debug.Log("Saving: PlayerPsyPointBonus" + GlobalsScript.PlayerPsyPointBonus);
        PlayerPrefs.SetInt("PlayerEXP",GlobalsScript.PlayerEXP); 
        Debug.Log("Saving: PlayerEXP" + GlobalsScript.PlayerEXP);
        PlayerPrefs.SetInt("PlayerDEF",GlobalsScript.PlayerDEF);
        Debug.Log("Saving: PlayerDEF" + GlobalsScript.PlayerDEF);
        PlayerPrefs.SetInt("PlayerATK",GlobalsScript.PlayerATK); 
        Debug.Log("Saving: PlayerATK" + GlobalsScript.PlayerATK);
        PlayerPrefs.SetInt("PlayerCurrentPsyPoints",GlobalsScript.PlayerCurrentPsyPoints);
        
        PlayerPrefs.SetInt("PlayerCurrentMAXPsyPoints",GlobalsScript.PlayerCurrentMAXPsyPoints); 
        
        PlayerPrefs.SetInt("PsyPotionsHeld",GlobalsScript.PsyPotionsHeld);
        
        PlayerPrefs.SetInt("ChargeUp",GlobalsScript.ChargeUp); 
        
        PlayerPrefs.SetInt("PlayerCurrentHP",GlobalsScript.PlayerCurrentHP);
        Debug.Log("GameSaver Script - SavePlayerStats() - Save the Player Current MAXHP of" + GlobalsScript.PlayerCurrentMAXHP);
        PlayerPrefs.SetInt("PlayerCurrentMaxHP",GlobalsScript.PlayerCurrentMAXHP); 
        
        PlayerPrefs.SetInt("PlayerMoneyTotal",GlobalsScript.PlayerMoneyTotal);
        
        PlayerPrefs.SetInt("SpikeBombsHeld",GlobalsScript.SpikeBombsHeld);
    }
     //This saves the current scene
        //Save Flags
        //This loop will iterate through all the story flags, coming up with the last 
        //number in the array where the story flag was activated to be true. 
        //Then when loaded it will activate all story flags beneath it. 
    #endregion
    #region SaveSceneFlags
    
    public void SaveSceneAndFlags()
    {
        if(GlobalsScript.SceneBuildIndex == 4)
        {
            Debug.Log("This is a  battle scene so no saving the current map scene here! SaveSceneAndFlags()");
        }
        else
        {
            PlayerPrefs.SetInt("CurrentMapScene",GlobalsScript.CurrentMapScene);
        }
     
        Debug.Log("Current MAP" + GlobalsScript.CurrentMapScene);
       
        if(GlobalsScript.CurrentMapScene == 1)//Save Textops flags 0 to 5
        {
            for(int i = 0; i< 6; i++)
            {
                if(GlobalsScript.StoryFlagsArray[i] == true)
                {
                 
                    PlayerPrefs.SetInt("LastStoredFlag", i);   
                }
                else
                {
                    break;
                }
            }
        }
        if(GlobalsScript.CurrentMapScene == 2)//Save Sewermaze flags 
         {
            for(int i = 6; i< 35; i++)
            {
                if(GlobalsScript.StoryFlagsArray[i] == true)
                {
                 
                    PlayerPrefs.SetInt("StoryFlagsArray", i);   
                }
                 else
                {
                    break;
                }
            }
        }
        if(GlobalsScript.CurrentMapScene == 3)//Save Town flags 
         {
            for(int i = 36; i< 42; i++)
            {
                if(GlobalsScript.StoryFlagsArray[i] == true)
                {
                 
                    PlayerPrefs.SetInt("StoryFlagsArray", i);   
                }
                else
                {
                    break;
                }
            }
         }
        if(GlobalsScript.CurrentMapScene == 4)
        {
            Debug.Log("its a battle scene savesceneandflag()");
        }
      
        
    }
    #endregion
    
    #region SaveWeapon
    //Saves the players weapon from scene to scene. This is used on scene startup. 
    public void SaveWeapon()
    {
           for(int i = 0; i< 5; i++)
            {
                if(GlobalsScript.WeaponsFlags[i] == true)
                {
                 
                    PlayerPrefs.SetInt("LastStoredWeaponsFlag", i);   
                }
                else
                {
                    break;
                }
             }
    }
    #region UseSaveKeys() + UseLoadKeys()
    //Debugging Keys that save or load the game 
    public void UseSaveKeys()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
           Save(); 
        }
   
    }
    
    public void UseLoadKeys()
    {
         if (Input.GetKeyDown(KeyCode.L))
        {
        Load();
        }
    }
    #endregion
    #endregion
    
    #region SaveBattleStats()
    //Needs to be saved upon entering battle and once just before the battle ends so that the accumulated experience gets added. 
    
    public void SaveBattleStats()
    {
        PlayerPrefs.SetInt("PlayerMaxHP", GlobalsScript.PlayerCurrentMAXHP);
        PlayerPrefs.SetInt("AccumulatedXP",GlobalsScript.PlayerEXP); 
        PlayerPrefs.SetInt("PlayerCash",GlobalsScript.PlayerMoneyTotal);
        PlayerPrefs.SetInt("PlayerCurrentHP",GlobalsScript.PlayerCurrentHP);
        PlayerPrefs.SetInt("PlayerLevel",GlobalsScript.PlayerLevel);
        Debug.Log("Battle Stats Saved: XP, $, HP, LVL");
    }
    #endregion
    #region LoadBattleStats()
    //Reload all the battle stats into the globals.
    public void LoadBattleStats()
    {
        GlobalsScript.PlayerCurrentMAXHP = PlayerPrefs.GetInt("PlayerMaxHP");
        
        Debug.Log("Load the player stats - GameSaver Script - LoadBattleStats() - PlayercurrentMAXHP: " + GlobalsScript.PlayerCurrentMAXHP);
        GlobalsScript.PlayerEXP = PlayerPrefs.GetInt("AccumulatedXP"); 
        GlobalsScript.PlayerMoneyTotal = PlayerPrefs.GetInt("PlayerCash");
        GlobalsScript.PlayerCurrentHP = PlayerPrefs.GetInt("PlayerCurrentHP");
        GlobalsScript.PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");
        Debug.Log("Battle Stats Loaded: XP, $, HP, LVL");  
    
    }
    #endregion
    #region Save() and Load()
    //Debug Load and Save() 
    public void Save()
    {
     //   AC_SaveItems(); 
     
     //   TheAC_ItemTracker.GetComponent<ItemTracker>().SavingItemStatus(); 
        
        
        SaveBattleStats(); 
        Determine_Level_And_Save(); 
        SaveSceneAndFlags();
        if(GlobalsScript.SceneBuildIndex == 4)
        {
            Debug.Log("Not Checked In Battle!");
        }
        else
        {
        ItemCheckerScript.Checker(); Debug.Log(".Checker() - Located in Save()");
        }
        ///////////////////<-- Insert item checker here
        SaveLocation(); //Must be saved last
        PlayerPrefs.Save(); 
    }
    #region LoadFromBattle()
    //Restore after a battle. 
    public void LoadFromBattle()
    {
        LoadLocation();
        LoadStoryFlags();
        LoadStats(); 
    }
    #endregion
    #region Load()
    public void Load()
    {
        LoadLocation(); //Must be loaded first to change the scene
        //  TheAC_ItemTracker.GetComponent<ItemTracker>().AC_LoadingMAPItemStatus();
        FirstTimers.GetComponent<FirstTimePickedUpScript>().LoadedFirsts(); 
        LoadWeaponsFlags();
        LoadStoryFlags();
        LoadStats(); 
        LoadBattleStats(); 
         
        //TheAC_ItemTracker.GetComponent<ItemTracker>().AC_DestroyMAPItems();   
     
        // AC_LoadItems(); //Load the items from the Accident Map
        //  AC_DestroyItems(); //Set Inactive any items pickedup on the Accident Map. 
          
    }
    #endregion
    #region FinalSave()
    //More in depth load and save functions. 
    public void FinalSave()
    {
        Debug.Log("-----------SAVE GAME-------------");
        
            SaveAllActiveStrings();//Save onscreen dialogs
            SaveLocation();//Saves Overworld position
            SavePlayerStats();//Saves Battle Stats and Overworld stats
            SaveSceneAndFlags();//Saves Scene and Story Flags
            SaveWeapon(); //Saves Weapon held
   FirstTimers.GetComponent<FirstTimePickedUpScript>().SavedFirsts();//Saves First dialog bools for items picked up. 
            Determine_Level_And_Save();
            PlayerPrefs.Save();
    }
    #endregion
    #region FinalLoad()
    public void FinalLoad()
    {
        LoadBattleStats(); //Loads any stats accumulated over the course of a battle. 
        //  LoadLastScene();//Loads last scene and position
        LoadStats();//Loads all player stats
        LoadStrings();//Loads all current dialogs
        LoadStoryFlags();//Loads all story flags tripped. 
        LoadWeaponsFlags(); //Loads current weapon held
     FirstTimers.GetComponent<FirstTimePickedUpScript>().LoadedFirsts(); //Loads all items picked up. 
        //  ItemTracker.
          
        Debug.Log("LOAD GAME");
    
    }
    
    #endregion
    #region Save_Without_Location()
    //Used to save without including a location [primarily used for debugging]
    public void Save_Without_Location()
    {
            Debug.Log("SAVE GAME");
            SaveAllActiveStrings();//Save onscreen dialogs
            SavePlayerStats();//Saves Battle Stats and Overworld stats
            SaveSceneAndFlags();//Saves Scene and Story Flags
            SaveWeapon(); //Saves Weapon held
      FirstTimers.GetComponent<FirstTimePickedUpScript>().SavedFirsts();//Saves First dialog bools for items picked up. 
            PlayerPrefs.Save();
    }
    #endregion
    
    #region Level / Position Saving
    //Determine if this is a new level and save that global. Need to transfer bool into Int 
    public void Determine_Level_And_Save()
    {
    
    int A_New_Level; //1 for True, 0 for False
        
        if(GlobalsScript.new_level == true)
        {
            A_New_Level = 1; //True 
        }
        else 
        {
            A_New_Level = 0; //False
        }
        // Save the Result  
        PlayerPrefs.SetInt("NewLevel?", A_New_Level);//Saves either 1-true or 0-false
    }
   
     
    #region Loading Code
    #region LoadStrings()
    //Loads any dialogs that were there at the time of the save. 
     public void LoadStrings()
     {
        //Last Player Dialog script that was on screen
        ParasiteText.text = PlayerPrefs.GetString("ParasiteText");
        
        PlayerText.text = PlayerPrefs.GetString("PlayerText");
        
        GoalText.text = PlayerPrefs.GetString("GoalText");
     }
     #endregion
     #region LoadStats()
    //Load ALL stats.
     public void LoadStats()
    {
       
         //Load Player Stats
         if(GlobalsScript.PlayerHPBonus != 0)
         {
        GlobalsScript.PlayerHPBonus = PlayerPrefs.GetInt("PlayerHPBonus");
         }
         if(GlobalsScript.PlayerHealsBonus != 0)
         {
        GlobalsScript.PlayerHealsBonus = PlayerPrefs.GetInt("PlayerHealsBonus");
         }
         if(GlobalsScript.PlayerCurrentPsyPoints != 0)
         {
             GlobalsScript.PlayerPsyPointBonus = PlayerPrefs.GetInt("PlayerPsyPointBonus");
         }
         if(GlobalsScript.PlayerEXP != 0)
         {
         GlobalsScript.PlayerEXP = PlayerPrefs.GetInt("PlayerEXP");
         }
        GlobalsScript.PlayerDEF = PlayerPrefs.GetInt("PlayerDEF");
        
        GlobalsScript.PlayerATK = PlayerPrefs.GetInt("PlayerATK");
        
        GlobalsScript.PlayerCurrentPsyPoints = PlayerPrefs.GetInt("PlayerCurrentPsyPoints");
        
        GlobalsScript.PlayerCurrentMAXPsyPoints = PlayerPrefs.GetInt("PlayerCurrentMAXPsyPoints");
        
        GlobalsScript.PsyPotionsHeld = PlayerPrefs.GetInt("PsyPotionsHeld");
        
        GlobalsScript.ChargeUp = PlayerPrefs.GetInt("ChargeUp");
        
        GlobalsScript.PlayerCurrentHP = PlayerPrefs.GetInt("PlayerCurrentHP");
        
        
         GlobalsScript.PlayerCurrentMAXHP = PlayerPrefs.GetInt("PlayerCurrentMaxHP");
        
         Debug.Log("Load the player stats - GameSaver Script - LoadStats() - PlayercurrentMAXHP: " + GlobalsScript.PlayerCurrentMAXHP);
        GlobalsScript.PlayerMoneyTotal = PlayerPrefs.GetInt("PlayerMoneyTotal");
 
         GlobalsScript.CurrentMapScene = PlayerPrefs.GetInt("CurrentMapScene");
        
         GlobalsScript.SceneBuildIndex = PlayerPrefs.GetInt("CurrentMapScene");
         GlobalsScript.LastStoredFlag = PlayerPrefs.GetInt("LastStoredFlag");
        
        GlobalsScript.LastStoredWeaponsFlag = PlayerPrefs.GetInt("LastStoredWeaponsFlag");
       }
       #endregion
       
      //Loads all the story flags until 34 [End of the scene];
     //PlayersPrefs stored the number of flags that have been tripped. 
     //so we need all the flags up until that number to be loaded. 
     //first we need to determine which flag is true... so that should be stored 
     //in playerprefs
     //Goes through the entire length of the stored value in playerprefs
    #region LoadStoryFlags()   
    public void LoadStoryFlags()
       {
            //Restores all the flags that were true to their previous states. 
           for(int i = 0; i < GlobalsScript.LastStoredFlag; i++)
           {
              GlobalsScript.StoryFlagsArray[i] = true;
           }
       }
       #endregion
        #region LoadWeaponsFlags()
    //Load weapons flags to determine which weapons were picked up and what to use in battle. 
   
    public void LoadWeaponsFlags()
       {

            
            //Restores all the flags that were true to their previous states. 
           for(int i = 0; i < GlobalsScript.LastStoredWeaponsFlag; i++)
           {
              GlobalsScript.WeaponsFlags[i] = true;
           }
       }
       #endregion
       //This function is used when transitioning back to this scene from the battle scene. It reloads the proper 
       //triggers, objects, items that have been triggered. 0 means it needs to be removed, 1 means it stays. 
     
}
       
    
      #region Mothballed Code
        //Mothballed code
        /*
        if(GlobalsScript.new_level == false)//set the position to wherever the player is on the level
        {
            
            PlayerPrefs.SetFloat("lastposition.x",PlayerPosition.transform.localPosition.x);
            
            PlayerPrefs.SetFloat("lastposition.y",PlayerPosition.transform.localPosition.y);
            
            PlayerPrefs.SetFloat("lastposition.z",PlayerPosition.transform.localPosition.z);
        }
        else//change to 'not a new level and save for the first time. 
        {
        //Skip that stuff and save for the next time.
           GlobalsScript.new_level = false; 
        }
        PlayerPrefs.SetInt("NewLevel",0);//Indicates its a new level\\\\\\\\\\\\\\\\
        
        
        
         #region LoadLastScene()
    //if its a new level, then we only want to save the stats and set the current position loaded to the STARTING LOCATION.
    
    
    public void LoadLastScene()
    {
    #region Old Code could not get this to work
    
        //This reloads the players previous position on the CURRENT map OR loads whatever scene and position was saved
        /* mothballed this code............. 'ran out of time to debug this'
        if(Is_This_A_New_Level == 1)//True
        {   SceneManager.LoadSceneAsync(GlobalsScript.CurrentMapScene);//Load the next scene
        //The player position will be loaded automatically and there should be 
        //something that checks that there is a new level and initiates the player position on Awake()
        }
        */
        //The problem here is that there is no frame of reference for 'Player Position'. Maybe you should use a global variable instead? 
         
        //This will reload the player position and paste it onto the global variable 
        //before the scene reloads.
        /*
        float posx = PlayerPrefs.GetFloat("lastposition.x");
        Debug.Log("Last Position X:" + posx);
        float posy = PlayerPrefs.GetFloat("lastposition.y");
        Debug.Log("Last Position Y:" + posy); 
        float posz = PlayerPrefs.GetFloat("lastposition.z");
        Debug.Log("Last Position Z:" + posz);
        int TheSavedScene = PlayerPrefs.GetInt("CurrentMapScene");
        //int Is_This_A_New_Level = PlayerPrefs.GetInt("NewLevel?"); //Loads the result if this is either going to be new or not.
         
                 if(TheSavedScene == GlobalsScript.CurrentMapScene) //--Currently saving on the same map, restore that position
                 {   
                     SceneManager.LoadSceneAsync(GlobalsScript.CurrentMapScene);
                     Debug.Log("X:" + posx + "Y:" + posy + "Z:" + posz);
                     GlobalsScript.PlayerPosition = new Vector3 (posx,posy,posz); //SetPosition(posx,posy,posz);
                     
                       
                 }
       
                 else//Load from the introscreen or some other level, load both the Scene and the player position
                 {
                      SceneManager.LoadScene(TheSavedScene);
                      PlayerPosition.transform.position = new Vector3 (posx,posy,posz); //SetPosition(posx,posy,posz);
                 }
              
    }
    
    
 /*
     public GameObject AC_ReloadedItem0,AC_ReloadedItem1,AC_ReloadedItem2,AC_ReloadedItem3,AC_ReloadedItem4,AC_ReloadedItem5,AC_ReloadedItem6,AC_ReloadedItem7,AC_ReloadedItem8,AC_ReloadedItem9,AC_ReloadedItem10,AC_ReloadedItem11;
    
    /*
    public void LoadLocation()//Incomplete Pseudo Code. 
    {
      //  GlobalsScript.new_level = PlayerPrefs.GetInt("NewLevel");
        //GlobalsScript.CurrentMapScene = PlayerPrefs.GetInt("CurrentMapScene"); //<-- whatever currentmap scenec
        
        
            if(GlobalsScript.CurrentMapScene == 1)//Accident 
            {
            PlayerPrefs.GetInt("new")
               if(GlobalsScript.new_level == 0)
               // {
                    //Then start at StartingLocation
              //  }  
             //   else//Start at the saved position in player prefs
             //   {
               // GlobalsScript.PlayerPosition = PlayerPrefsSavedPosition
           //     }   
            //Keep going for 2,3,4,5 
            
        }
            //  GameObject TheAC_ItemTracker;
    //public GameObject AC_ItemTracker; 
//    TheAC_ItemTracker=GameObject.Find("AC_ItemTracker");
        
    /*TEMPLATE
    int SavedItem0,SavedItem1, SavedItem2, SavedItem3, SavedItem4, SavedItem5, SavedItem6, SavedItem7, SavedItem8, SavedItem9, SavedItem10, SavedItem11;  
    
    public GameObject ReloadedItem0,ReloadedItem1,ReloadedItem2,ReloadedItem3,ReloadedItem4,ReloadedItem5,ReloadedItem6,ReloadedItem7,ReloadedItem8,ReloadedItem9,ReloadedItem10,ReloadedItem11;
    }
    
     */
     #endregion
      #endregion
       #endregion
        #endregion
       