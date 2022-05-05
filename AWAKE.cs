using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AWAKE : MonoBehaviour
{
    public GameSaver GS;
    void Awake()
    {
      
        //  PlayerPrefs.DeleteAll();
        Debug.Log("Money Held:" + GlobalsScript.MoneyHeld);
        Debug.Log("Player Money Total:" + GlobalsScript.PlayerMoneyTotal);
        Debug.Log("XP:" + GlobalsScript.PlayerEXP);
        Debug.Log("LifePoints" + GlobalsScript.PlayerCurrentHP);
        Debug.Log("Life Points MAX" + GlobalsScript.PlayerCurrentMAXHP);
        
        //  GlobalsScript.PlayerCurrentMAXHP = 20;
        //  GlobalsScript.MaxHP = 20; 

    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Money Held:" + GlobalsScript.MoneyHeld);
        Debug.Log("Player Money Total:" + GlobalsScript.PlayerMoneyTotal);
        Debug.Log("XP:" + GlobalsScript.PlayerEXP);
        Debug.Log("LifePoints" + GlobalsScript.PlayerCurrentHP);
        Debug.Log("Life Points MAX" + GlobalsScript.PlayerCurrentMAXHP);
        
        if(GlobalsScript.PlayerCurrentHP == 0)
        {
            GlobalsScript.PlayerCurrentHP = 20;
        }
        if(GlobalsScript.PlayerCurrentMAXHP == 0)
        {
            GlobalsScript.PlayerCurrentMAXHP = 20;
        }
        
        GlobalsScript.SceneBuildIndex =  SceneManager.GetActiveScene().buildIndex;
        GlobalsScript.CurrentMapScene = SceneManager.GetActiveScene().buildIndex; 
        Debug.Log("LifePoints RETRY" + GlobalsScript.PlayerCurrentHP);
        Debug.Log("Life Points MAX RETRY" + GlobalsScript.PlayerCurrentMAXHP);
        GS.Save();
       
        GS.SaveLocation(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
