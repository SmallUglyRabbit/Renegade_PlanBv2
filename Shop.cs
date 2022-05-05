using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

//This script activates the vending machine's 'shop' and allows the player to purchase HEALS. Later it could be used to sell various objects.
public class Shop : MonoBehaviour
{
	[SerializeField]
	public Canvas ShopScreen;
	public TextMeshProUGUI ComputerText;
	public AudioSource BuyingClick; 
	// Start is called before the first frame update
    void Awake()
	{
		ShopScreen.enabled = false;  
	    
	}
    
	public void BuyHeals()
	{
        if(GlobalsScript.PlayerMoneyTotal < 10)
        {
            ComputerText.text = "Not Enough Cash";
        }
        else
        {
               BuyingClick.Play();
            GlobalsScript.Heals += 1; 
            
		GlobalsScript.PlayerMoneyTotal -= 10; 
            ComputerText.text = "Thank You";
        }
	}
	
    public void BuyPsyPotions()
    {
        if(GlobalsScript.PlayerMoneyTotal < 15)
        {
            ComputerText.text = "Not Enough Cash";
        }
        else
        {
        BuyingClick.Play();
        GlobalsScript.PsyPotionsHeld += 1;
            GlobalsScript.PlayerMoneyTotal -= 15;
        }
    }  
	
	
	public void Exit()
	{
		ShopScreen.enabled = false; 
		
	}

    
}
