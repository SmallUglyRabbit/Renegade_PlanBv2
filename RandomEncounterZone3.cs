using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Description: 
//This script handles the random encounters in a 'zone' or a collider // or trigger area. It passes numbers between the Globalscript and several functions to create 'Random Battles'. It needs to be adjusted
//because at present there are too many encounters and without 
//a save feature, player death means a full restart. 
public class RandomEncounterZone3 : MonoBehaviour //This is for the sewer maze ZONE 1.
{
    
    [SerializeField]
    internal GameSaver GameSaverScript;
    public static int Randoms=0;
    public Transform PlayerPosition;
    
    int RandomEncounterRoll;
    
    public GameObject Player;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RandomEncounterRoll = GlobalsScript.Roll(1, 100);//Rolls to see which type of encounter if any
            if(RandomEncounterRoll == 32)
            {
                GlobalsScript.SceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
                GlobalsScript.SceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

                GlobalsScript.RandomEncounterCategory = 5;//Evil Doctor
                GlobalsScript.lastposition.x = PlayerPosition.position.x;
                
                GlobalsScript.lastposition.y = PlayerPosition.position.y;
                GameSaverScript.Save(); 
                SceneManager.LoadSceneAsync(GlobalsScript.BattleScene);
            }
            else if(RandomEncounterRoll == 3)
            {
                GlobalsScript.SceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
                GlobalsScript.SceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

                GlobalsScript.RandomEncounterCategory = 6; //Clean Up Crew 1
                GlobalsScript.lastposition.x = PlayerPosition.position.x;
                
                GlobalsScript.lastposition.y = PlayerPosition.position.y;
                GameSaverScript.Save(); 
                SceneManager.LoadSceneAsync(GlobalsScript.BattleScene);
            }
            else if(RandomEncounterRoll == 30)
            {
                GlobalsScript.SceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
                GlobalsScript.SceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

                GlobalsScript.RandomEncounterCategory = 5; //Rat
         
                GlobalsScript.lastposition.x = PlayerPosition.position.x;
                
                GlobalsScript.lastposition.y = PlayerPosition.position.y;
                GameSaverScript.Save(); 
                SceneManager.LoadSceneAsync(GlobalsScript.BattleScene);
            }
            else if(RandomEncounterRoll == 77)
            {
                GlobalsScript.SceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
                GlobalsScript.SceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

                GlobalsScript.RandomEncounterCategory = 6; //Evil Nurse
                GlobalsScript.lastposition.x = PlayerPosition.position.x;
                
                GlobalsScript.lastposition.y = PlayerPosition.position.y;
                GameSaverScript.Save(); 
                SceneManager.LoadSceneAsync(GlobalsScript.BattleScene);
            }
    
            Debug.Log(RandomEncounterRoll);
        }
    }
    
    
    //This function exists to give a timer to this zone. Random numbers are rolled every interval 
    //and weighed against the zone requirements. If the requirements for an encounter are met
    //The Battle Scene is engaged. 
    int timer = 0;
    int interval = 200;
    
    void Update()
    {
        if(timer%interval == 0)
        {
            TestForRandomEncounter();
        }
        timer++;
    }
    
    //This tests for a random encounter at each interval
    void TestForRandomEncounter()
    {
        OnTriggerEnter2D(Player.GetComponent<Collider2D>());
    }
     
}

