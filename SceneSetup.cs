using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro; 


//This object is necessary in each OVERWORLD in order to load stats
//and destroy items that have been picked up already. 
public class SceneSetup : MonoBehaviour
{ 
    
    public GameObject GameSaverOBJ; 
    public static int SceneBuildIndex; 
    
    [SerializeField]
    internal ItemChecker ItemCheckerScript;
    
    #region Awake(),Update(),Start()
    public void Awake()
    {
        
        Debug.Log("Starting Up the scene again!");
        GlobalsScript.EncounterStopper = false; 
        GlobalsScript.new_level = false; 
        SceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        //Sets the scene
        GlobalsScript.CurrentMapScene = SceneBuildIndex;
        
        Debug.Log("Set Active Scene through build index and current map scene");
        Debug.Log("Current MAP Scene is: " + GlobalsScript.CurrentMapScene);
        Debug.Log("Scene Build Index is: " + GlobalsScript.SceneBuildIndex); 
        GameSaver.GameSaverScriptControl.LoadStats(); 
        GameSaver.GameSaverScriptControl.LoadBattleStats(); 
        GameSaver.GameSaverScriptControl.LoadStoryFlags(); 
        GameSaver.GameSaverScriptControl.LoadWeaponsFlags(); 
     
        //GameSaver.GameSaverScriptControl.LoadLocation(); 
            Debug.Log("Money Held:" + GlobalsScript.MoneyHeld);
            Debug.Log("Player Money Total:" + GlobalsScript.PlayerMoneyTotal);
            Debug.Log("XP:" + GlobalsScript.PlayerEXP);
        Debug.Log("LifePoints" + GlobalsScript.PlayerCurrentHP);
        Debug.Log("Life Points MAX" + GlobalsScript.PlayerCurrentMAXHP);
        //
        ItemCheckerScript.LoadActiveItems();
            ItemCheckerScript.CheckLoadedItems();
    }
    void Update() 
    {
        //  AccidentTestArray();
    }
    void Start()
    {
      
    
        
    }
    #endregion
}
