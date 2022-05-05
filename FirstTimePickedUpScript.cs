using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script executes after an item is picked up. Instead of 
//seeing the same message fire over and over, this script 
//ensures that the message is only played once per level. 
//I realize that it repeats each level but I figured since 
//this is a short game that it would be better if the 
//player is reminded what each item does. 


//If a first is ever FALSE then the text when you pick it up will no longer be displayed. This object persists through scenes to ensure that objects do not 
//constantly trigger their beginning texts. 

//This script is currently working

public class FirstTimePickedUpScript : MonoBehaviour
{
     #region First Pickups
     
    //For using with FIRSTS GameObject
    int Saved_FirstPsy, Saved_FirstCoin, Saved_FirstXPGem, Saved_FirstLifeGem, Saved_FirstSpikeBallATKGem, Saved_FirstSpikeBomb, Saved_FirstSpikeBallDEFGem;
    
    int Loaded_FirstPsy, Loaded_FirstCoin, Loaded_FirstXPGem, Loaded_FirstLifeGem, Loaded_FirstSpikeBallATKGem, Loaded_FirstSpikeBomb, Loaded_FirstSpikeBallDEFGem;
    
    [Header("Story Trigger Pickups for Items")]
    public static bool FirstPsy = true; 
    public static bool FirstCoin = true; 
    public static bool FirstXPGem = true; 
    public static bool FirstLifeGem = true; 
    public static bool FirstSpikeBallATKGem = true; 
    public static bool FirstSpikeBomb = true; 
    public static bool FirstSpikeBallDEFGem = true;
    #endregion First Pickups 
    void Awake()
    {
        //DontDestroyOnLoad(this);
    }
    
    //This ensures player does not see flags of items over and over again
    #region SavedFirsts() and LoadedFirsts()
    public void SavedFirsts() 
    {
        if(FirstTimePickedUpScript.FirstPsy == true)
        {
            Saved_FirstPsy = 1; 
        }
        else
        {
            Saved_FirstPsy = 0; 
        }
        
        if(FirstTimePickedUpScript.FirstCoin == true)
        {
            Saved_FirstCoin = 1; 
        }
        else
        {
            Saved_FirstCoin = 0;
        }
        
        if(FirstTimePickedUpScript.FirstXPGem == true)
        {
            Saved_FirstXPGem = 1; 
        }
        else
        {
            Saved_FirstXPGem = 0;
        }
        
        if(FirstTimePickedUpScript.FirstLifeGem == true)
        {
            Saved_FirstLifeGem = 1; 
        }
        else
        {
            Saved_FirstLifeGem = 0;
        }
        
        if(FirstTimePickedUpScript.FirstSpikeBallATKGem == true)
        {
            Saved_FirstSpikeBallATKGem = 1; 
        }
        else
        {
            Saved_FirstSpikeBallATKGem = 0;
        }
        
        if(FirstTimePickedUpScript.FirstSpikeBallDEFGem == true)
        {
            Saved_FirstSpikeBallDEFGem = 1;
        }
        else
        {
            Saved_FirstSpikeBallATKGem = 0;
        }
        
        if(FirstTimePickedUpScript.FirstSpikeBomb == true)
        {
            Saved_FirstSpikeBomb = 1;
        }
        else
        {
            Saved_FirstSpikeBomb = 0;
        
        }
        PlayerPrefs.SetInt("FirstPsy", Saved_FirstPsy);
        PlayerPrefs.SetInt("FirstCoin", Saved_FirstCoin);
        PlayerPrefs.SetInt("FirstXPGem", Saved_FirstXPGem);
        PlayerPrefs.SetInt("FirstLifeGem",Saved_FirstLifeGem);
        PlayerPrefs.SetInt("FirstSpikeBallATKGem",Saved_FirstSpikeBallATKGem);
        PlayerPrefs.SetInt("FirstSpikeBallDEFGem",Saved_FirstSpikeBallDEFGem); 
        PlayerPrefs.SetInt("FirstSpikeBomb", Saved_FirstSpikeBomb);
     //FirstCoin, FirstXPGem, FirstLifeGem, FirstSpikeBallATKGem, FirstSpikeBomb, FirstSpikeBallDEFGem
    }
    
    public void LoadedFirsts() 
    {
        Loaded_FirstPsy = PlayerPrefs.GetInt("FirstPsy");
        Loaded_FirstCoin = PlayerPrefs.GetInt("FirstCoin");
        Loaded_FirstXPGem = PlayerPrefs.GetInt("FirstXPGem");
        Loaded_FirstLifeGem = PlayerPrefs.GetInt("FirstLifeGem");
        Loaded_FirstSpikeBallATKGem = PlayerPrefs.GetInt("FirstSpikeBallATKGem");
        Loaded_FirstSpikeBallDEFGem = PlayerPrefs.GetInt("FirstSpikeBallDEFGem");
        Loaded_FirstSpikeBomb = PlayerPrefs.GetInt("FirstSpikeBomb");
        
        
        if(Loaded_FirstPsy == 1)
        {
            FirstTimePickedUpScript.FirstPsy = true; 
        }
        else
        {
            FirstTimePickedUpScript.FirstPsy = false; 
            
        }
        
        if(Loaded_FirstCoin == 1)
        {
            FirstTimePickedUpScript.FirstCoin = true;
        }
        else
        {
            FirstTimePickedUpScript.FirstCoin = false;
        }
        
        if(Loaded_FirstXPGem == 1)
        {
            FirstTimePickedUpScript.FirstXPGem = true;
        }
        else
        {
            FirstTimePickedUpScript.FirstXPGem = false; 
        }
        
        if(Loaded_FirstLifeGem == 1)
        {
            FirstTimePickedUpScript.FirstLifeGem = true; 
        }
        else
        {
            FirstTimePickedUpScript.FirstLifeGem = false; 
        }
        
        if(Loaded_FirstSpikeBallATKGem == 1)
        {
            FirstTimePickedUpScript.FirstSpikeBallATKGem = true;
        }
        else
        {
            FirstTimePickedUpScript.FirstSpikeBallATKGem = false; 
        }
        
        if(Loaded_FirstSpikeBallDEFGem == 1)
        {
            FirstTimePickedUpScript.FirstSpikeBallDEFGem = true; 
        }
        else
        {
            FirstTimePickedUpScript.FirstSpikeBallDEFGem = false; 
        }
        
        if(Loaded_FirstSpikeBomb == 1)
        {
            FirstTimePickedUpScript.FirstSpikeBomb = true;
        }
        else
        {
            FirstTimePickedUpScript.FirstSpikeBomb = false; 
        }
    }
    #endregion
}
