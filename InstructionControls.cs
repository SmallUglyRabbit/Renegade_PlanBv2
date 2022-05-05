using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script controls buttons on the main menu and for the instructions.  
public class InstructionControls : MonoBehaviour
{
     
    public void MainMenuBTN()
    {
        SceneManager.LoadScene(0);//Back to Game Main Menu
    }
    
    public void InstructionsMenu()
    {
        SceneManager.LoadScene(5); //Back to Instructions Menu 
    }
    
    public void OverworldWASD()
    {
        SceneManager.LoadScene(7);//WASD Control Instruction Panel
    } 
    public void OverworldHUD()
    {
        SceneManager.LoadScene(6);//Overworld HUD.
    }
    public void OverworldCLR()
    {
        SceneManager.LoadScene(8);//Overworld Clearscreen
    }
    public void CombatHUD()
    {
        SceneManager.LoadScene(9);//Combat HUD explanation 
    }
    public void CombatMutations()
    {
        SceneManager.LoadScene(11);//Combat Mutations explanation
    }
    public void CheatCodes()
    {
        SceneManager.LoadScene(10);//Cheat codes
    }
    public void Credits()
    {
        SceneManager.LoadScene(12);//Dedications
    }
    public void Credits2()
    {
        SceneManager.LoadScene(13); //Programmed by / Assets used. 
    }
    public void Credits3()
    {
        SceneManager.LoadScene(14); //Assets 2 
    }
    public void Credits4()
    {
        SceneManager.LoadScene(15); //Assets 3 & Fonts
    }
   
}

//Overworld -> OverworldCLR -> OverworldWASD -> OverworldHUD
//Combat -> CombatHUD -> Combat Mutations
//CheatCodes -> CheatCodes 'M' 
//Credits -> RollCredits