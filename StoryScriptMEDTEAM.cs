using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



	public class StoryScriptMEDTEAM : MonoBehaviour
	{
		[SerializeField] 
		public	TextMeshProUGUI MedTeam1;
		public	TextMeshProUGUI MedTeam2;
		public	TextMeshProUGUI MedTeam3; 
		public	TextMeshProUGUI PlayerTalk; 
		public  TextMeshProUGUI ParasiteTalk;
		public GameObject TheTrigger;//This stores the trigger
		public GameObject TheMedTeamGraphics; 
		public Image EnemyPrefabGraphicSpecificImage;//This changes the prefabs graphics to reflect
		public GameObject SelfDestruct;
        //A med team group.
	


		 
		void Start()//Turns on this trigger
		{
			TheTrigger.SetActive(true);
		}
		 
		void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Player" && GlobalsScript.StoryFlagsArray[1] == false)
			{
				PlayerTalk.text = "What? Hello?";
				ParasiteTalk.text = "<shake>I'm here you FOOLS!</shake> ";
				GlobalsScript.RandomEncounterCategory = 1;
                GlobalsScript.StoryFlagsArray[1] = true;
                GlobalsScript.new_level = false;
				SceneManager.LoadScene(GlobalsScript.BattleScene);
                SelfDestruct.SetActive(true);
            }
         
         }
	 
	}

