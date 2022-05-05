using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//These are the buttons for the intro screen
public class IntroStuff : MonoBehaviour
{
    [SerializeField]
	internal GameSaver GameSaverScript; 
    public void TheStartBTN()
	{
        PlayerPrefs.DeleteAll();
        GlobalsScript.new_level = true; 
       
		SceneManager.LoadScene(1);
	}
	
    public void InstructionsBTN() 
    {
        SceneManager.LoadScene(5);
    }
    
	public void TheQuitBTN()
	{
        Application.Quit();
		Debug.Log("This is not needed");
	}
	
	public void TheLoadBTN()
	{
        GameSaverScript.Load(); 
		Debug.Log("Loads From Last Save Point in playerprefs");
	}
}
