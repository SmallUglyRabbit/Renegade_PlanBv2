
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UnitScript : MonoBehaviour
{
 [SerializeField]
	internal BattleSystem BattleSystemScript; 
	
	[SerializeField]
	internal BattleHUD BattleHUDScript;
 //BattleSystem BattleSystemScript; 
 //This script deals with the prefab stats and also handles taking 
 //damage and healing. 
 [Header("Unit Attributes")]
 public string UnitName;
 public int UnitLevel; 
 public int Damage;
 public int MaxHP;
 public int CurrentHP; 
 public int EnemyEXP; 
 public int PlayerEXP;
 public int PsyPoints; 
 public int PsyPointsMax; 
 //Combo System. 
 [Header("Combo System")]
 public bool weak2fire; 
 public bool strong2fire; 
 public bool weak2heal;
 public bool strong2heal; 
 public bool weak2ice; 
 public bool strong2ice; 
 public bool weak2mist; 
 public bool strong2mist;
 public bool weak2energy; 
 public bool strong2energy; 
 public bool weak2acid;
 public bool strong2acid;

	//Spell System 
 [Header("Spell System")]
 public int ToHitSpells;
 public int FireSpells;
 public int EnergySpells;
 public int SleepSpells; 
 public int IceSpells; 
	//New
 public int MoneyHeld; 
 public Image UnitPicture; // The Image used for the stationary character
 public Animation BattleAnimation;//The Animation that plays during their turn
 public string[] SpecialAttacks  = new string[10]; //Any special attacks they can use, ENUM in globals
 public AudioClip ThemeMusic; //The Custom music to play [if any]
 public string [] ItemsHeld = new string[10]; //Any items held
 

	
 public bool TakeDamage(int dmg)
 {
 	CurrentHP -= dmg;
 	if(CurrentHP <= 0)
 	{
	 	return true; 		
 	}
 	else
 	{
 		return false;
 	}
 }
 public void Heal(int amount)
 {
 	CurrentHP += amount;
 	if(CurrentHP > MaxHP)
	 	CurrentHP = MaxHP;
 }
}
