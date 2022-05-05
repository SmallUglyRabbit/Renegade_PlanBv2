using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomEncounterScript : MonoBehaviour //This is for the sewer maze ZONE 1. It deals with the types of monsters and frequency that they appear in ZONE 1. 
{
    
    
    #region Variables
	public static int Randoms=0;
	public Transform PlayerPosition;
	
	int RandomEncounterRoll;
	[SerializeField]
	public GameObject Player;
   
	//public GameObject GameSaver; 
	  [SerializeField]
    internal GameSaver GameSaverScript; 
	#endregion
    int timer = 0;
    int interval = 100;
#region Update()    
    void Update()
    {
        if(timer%interval == 0)
        {
            TestForRandomEncounter();
        }
        timer++;
    }
    #endregion

#region OnTriggerEnter2D
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			if(GlobalsScript.EncounterStopper == false)//Stops multiple Encounters from happening
			{
                
			RandomEncounterRoll = GlobalsScript.Roll(1, 100);//Rolls to see which type of encounter if any
				if(RandomEncounterRoll == 100)
                {
                    GlobalsScript.SceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
                    GlobalsScript.SceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

				GlobalsScript.RandomEncounterCategory = 2;//EvilDoctor 
                    //	GlobalsScript.lastposition.x = PlayerPosition.position.x;
                    //GlobalsScript.lastposition.y = PlayerPosition.position.y;
                    //  GlobalsScript.lastposition.z = PlayerPosition.position.z;
                GlobalsScript.EncounterStopper = true;
                GameSaverScript.Save(); 
                
                    //
               //I want to save the game STATE contents of Accident Overworld before I enter into the BattleScene and reload them once 
               //the battle has concluded. 
               //
                SceneManager.LoadSceneAsync(GlobalsScript.BattleScene);
			 
			}
				else if(RandomEncounterRoll == 3)
                {
                    GlobalsScript.SceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
                    GlobalsScript.SceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

                GlobalsScript.RandomEncounterCategory = 1; //EvilNurse
                
				    GlobalsScript.EncounterStopper = true;
                    //GameSaver.Save(); 
                  
                GameSaverScript.Save(); //Saves the player position, stats, etc
				    SceneManager.LoadSceneAsync(GlobalsScript.BattleScene);
			}
			
				Debug.Log(RandomEncounterRoll);
			}
		}
	}
	
	#endregion
	//This function exists to give a timer to this zone. Random numbers are rolled every interval 
	//and weighed against the zone requirements. If the requirements for an encounter are met
	//The Battle Scene is engaged. 
	//This tests for a random encounter at each interval
	
    void TestForRandomEncounter()
	{
		OnTriggerEnter2D(Player.GetComponent<Collider2D>());
	}
	 
}
    //   GlobalsScript.lastposition.x = PlayerPosition.position.x;
                    //    Debug.Log("PlayerPosition B4 Battle:",GlobalsScript.lastposition.x.ToString());
                    //      GlobalsScript.lastposition.y = PlayerPosition.position.y;
                    // Debug.Log("PlayerPosition B4 Battle:" + GlobalsScript.lastposition.y.ToString());
                    //   GlobalsScript.lastposition.z = PlayerPosition.position.z;
                    //    Debug.Log("Player Position Z:", GlobalsScript.lastposition.z.ToString);