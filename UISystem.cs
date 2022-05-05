using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

//This script manages the HUD system directly. 
public class UISystem : MonoBehaviour
{
	public TextMeshProUGUI CurrencyCounterText; 
	public Slider LifeBAR;
	public Slider ExperienceBAR;
	public int PlayerMoney; 
	// Start is called before the first frame update
	
    //This code updates the UI as the stats for the globals increase or decrease.
	void Update()
	{
		CurrencyCounterText.text = GlobalsScript.PlayerMoneyTotal.ToString();//Not Implemented yet. 
		LifeBAR.maxValue = GlobalsScript.PlayerCurrentMAXHP;
		LifeBAR.value = GlobalsScript.PlayerCurrentHP;
		ExperienceBAR.maxValue = 100; 
		ExperienceBAR.value = GlobalsScript.PlayerEXP;
		PlayerMoney = GlobalsScript.PlayerMoneyTotal;
	}
	
	
	 
	
  
}
