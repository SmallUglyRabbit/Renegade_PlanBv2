
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboScript : MonoBehaviour
{

	[SerializeField]
	public BattleSystem BattleSystemScript; 
	/*
	[SerializeField]
	internal UnitScript UnitScript;
	[SerializeField]
	internal BattleHUD BattleHUDScript;
	*/
	//Combo Spells
	[Header("Combo Spells")]
	public bool ComboFire;
	public bool ComboAcid; 
	public bool ComboElec; 
	public bool ComboIce; 
	public bool ComboChainOn;
    
    [Header("Battle Text")]
    public TextMeshProUGUI BigBattleTextGREEN; 
    public TextMeshProUGUI BigBattleTextRED;
    public TextMeshProUGUI BigBattleTextBLUE; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	//COMBO CODE
	 
	public void CheckIceAndFireCombos()//Turns the combo chain on and checks to see if Fire and Ice are on and turns those off
	{
		ComboChainOn = true; 
		//These two cancel each other out. 
		if(ComboFire == true && ComboIce == true)
		{
            BigBattleTextGREEN.text = "Combo Breaker!";
			BattleSystemScript.dialogueText.text = "Fire and Ice cancel each other out and break the combo chain";
			ComboIce = false; 
			ComboFire = false;
			ComboChainOn = false;
		}
	}
	
	public void CheckComboDamage()//Checks the Combos to see if they score extra damage or do some other effect
	{	
		int ChargerBonus = GlobalsScript.ChargeUp; 
		CheckIceAndFireCombos();//Turns off fire and ice if they are both active.
		if(ComboIce == true && ComboAcid == true)
		{
        BigBattleTextGREEN.text = "ICE SHIELD!";
			BattleSystemScript.dialogueText.text = "An ice shield forms around " +  BattleSystemScript.playerUnit.UnitName + ", DEFENSE UP!";
			BattleSystemScript.TempDefense = true;
	
			//Combo Codes AcidIce
		}
		if(ComboFire == true && ComboAcid == true)
		{
        BigBattleTextBLUE.text = "ACID FIRE!";
			BattleSystemScript.dialogueText.text = "Acid and molten metal explode hitting " + BattleSystemScript.enemyUnit.UnitName + ", CRITICAL DAMAGE!";
			int totalDamage = ChargerBonus * BattleSystemScript.Roll(10,20);
			BattleSystemScript.enemyUnit.CurrentHP -= totalDamage;
			ResetCombos();
			//Combo Codes AcidFire
		}
		if(ComboElec == true && ComboFire == true)
		{
        BigBattleTextRED.text = "ELECTRICAL FIRE!";
			BattleSystemScript.dialogueText.text = "An arc of electric fire hits " + BattleSystemScript.enemyUnit.UnitName + ", CRITICAL DAMAGE!";
			int totalDamage = ChargerBonus * BattleSystemScript.Roll(10,20);
			BattleSystemScript.enemyUnit.CurrentHP -= totalDamage;
			ResetCombos();
			//Combo Codes ElectricFire
		}
		if(ComboElec == true && ComboAcid == true && ComboIce == true)
		{ 
        BigBattleTextBLUE.text = "ACIDIC ICE!";
			BattleSystemScript.dialogueText.text = "Acid bubbles bounce off the ground hitting " + BattleSystemScript.enemyUnit.UnitName + ", CRITICAL DAMAGE!";
			int totalDamage = ChargerBonus * BattleSystemScript.Roll(10,30);
			BattleSystemScript.enemyUnit.CurrentHP -= totalDamage;
			ResetCombos();
			//Combo Codes ElectricAcidIce
		}
		else
		{
			Debug.Log("No Combos");
		}
		
	}
	
	public void ResetCombos() //Resets all combos. 
	{
		ComboAcid = false; 
		ComboElec = false;
		ComboIce = false; 
		ComboFire = false; 
		ComboChainOn = false;
	}
	
	
	public void AddToCombo(char element)//Turns the selected Combos on or off
	{
		switch (element)
		{
		case 'F': //FIRE
			Debug.Log("Fire");
			ComboFire = true; 
			break;
		case 'A': //ACID
			Debug.Log("Acid");
			ComboAcid = true; 
			break;
		case 'E': //ELECTRICITY
			Debug.Log("Electrify");
			ComboElec = true; 
			break;
		case 'I': //ICE
			Debug.Log("Ice");
			ComboIce = true; 
			break;
		}
	    
	}




	}


