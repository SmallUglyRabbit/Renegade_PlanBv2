using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This file stores all the dialog for the game. 
public class GlobalStringText : MonoBehaviour
{
    #region Variables
    public static string CurrentLevel = "None"; //Used to override locations
        public static string[] StoryStrings = new string[50];
        public static string[] PlayerTalkStrings = new string[50];
    public static string[] ParasiteTalkStrings = new string [50];
    public static string[] StarChargerStrings = new string [50];
        
        public static string[] GoalStrings = new string [50];
        public static string[] BattleStrings = new string[50];
        public static string[] NPCText = new string[50];
        //Add NPC Talk Strings
        public static string[] NPC_Anim_Direction = new string[1];
        //Add Item Talk Strings
#endregion
#region Awake()
    // Start is called before the first frame update
    void Awake()
    {
   
    //Load the NPC Array
    NPC_Anim_Direction[0] = "Up";
     #region BattleStrings[]
    //Load the arrays full of dialog
    BattleStrings[0] = "Choose an action:"; //PlayerPrompt - BattleSystem.cs
    BattleStrings[1] = "'s attack was successful.";//PlayerAttack() function - BattleSystem.cs
    BattleStrings[2] = " missed!"; //DidIHitIt - BattleSystem.cs
    BattleStrings[3] = " attacks and hit the target"; //EnemyTurn() - BattleSystem.cs
    BattleStrings[4] = " took damage"; //EnemyTurn() - BattleSystem.cs
    BattleStrings[5] = "'s turn!"; //EnemyTurn()
    BattleStrings[6] =  " gained a level."; //CheckForLevelUp()
    BattleStrings[7] = " gained ";//CollectXP()
    BattleStrings[8] = " experience points";//CollectXP()
    BattleStrings[9] = " was defeated. Game Over!";//GameOverReturnToTitleScreen()
    BattleStrings[10] = " won the battle."; //EndBattle()
    BattleStrings[11] = "Charging! "; //Charge()
    BattleStrings[12] = " recovered all their PsyPoints!"; //Charge()
    BattleStrings[13] = "recovered ";//Charge()//LifeSteal()//HealSpell()
    BattleStrings[14] = " PsyPoints!";//Charge()
    BattleStrings[15] = "It's "; //Charge()
    BattleStrings[16] = "A Spike Bomb rolls up to ";//SpikeBomb()
    BattleStrings[17] = " bites down hard and explodes"; //SpikeBomb()
    BattleStrings[18] = "No Spike Bombs to throw.";//SpikeBomb()
    BattleStrings[19] = " Hit Points";//HealPotionBTN()//LifeSteal()//HealSpell
    BattleStrings[20] = " and ";//HealPotionBTN()
    BattleStrings[21] = " has: ";//HealPotionBTN()
    BattleStrings[22] = " potions left!";//HealPotionBTN()
    BattleStrings[23] = "No Heal Potions Left!";//HealPotionBTN()
    BattleStrings[24] = " recovers all their PsyPoints";//PsyPotionBTN()
    BattleStrings[25] = "No Psychic Potions Left!";//PsyPotionBTN()
    BattleStrings[26] = " is weak against "; //DoubleDamage()
    BattleStrings[27] = ", DOUBLE DAMAGE!";//DoubleDamage()
    BattleStrings[28] =  " is strong against ";//DoubleDamage()
    BattleStrings[29] = ", HALF DAMAGE!";//DoubleDamage()
    BattleStrings[30] = "Not enough Psyhic points left";//FireBallSpell()//LifeSteal()//MistSpell()
    BattleStrings[31] = " returns to full health";//LifeSteal()
    BattleStrings[32] = "A strange coloured mist encircles ";//MistSpell()
    BattleStrings[33] = ", their Hit Points are reduced to 1";//MistSpell()
    BattleStrings[34] = "The mist evaporated";//MistSpell()
    BattleStrings[35] = "Discharged! ";//HealSpell()
    BattleStrings[36] = "An ";//SetupBattle()
    BattleStrings[37] = " appears!";//SetupBattle()
    //BattleStrings[36] = 
    #endregion
    #region NPCText[]
     //NPC Text
    //Med Team:Accident Scene 
    NPCText[0] = "Dump the bodies in here, we'll drag them to the plant";
    NPCText[1] = "Wait... another one is alive?!?";
    NPCText[2] = "There goese another one, kill it before it ferments!";
        #endregion
        #region PlayerTalkStrings[] & ParasiteTalkStrings[]
        //StoryScript
        PlayerTalkStrings[0] = "{fade}Ugh... my head... what's this thing on my arm?{/fade} ";
        ParasiteTalkStrings[0] = "Where Am I?   <shake>What have they done?</>.. I need to get to the sewer... where are my things?!";
        GoalStrings[0] = "Goals: Look around for clues";
        //StoryScript2
        PlayerTalkStrings[1] = "{fade}Who said that?!??!{/fade}";
        ParasiteTalkStrings[1] = "  <wave>  <shake>Noooo, wake up, wake up! </shake> </wave>";
        //StoryScript3
        PlayerTalkStrings[2] = "{fade}Was this part of the accident!? {/fade}";
        ParasiteTalkStrings[2] =  "  <wave>  <shake>ARGH! NOT YOU TOO!?!  </shake> </wave>";
        //StoryScript4
        PlayerTalkStrings[3] = "{fade}What happened to these bodies... I think... I'm going to be sick.{/fade}";
        ParasiteTalkStrings[3] = "  <wave>  <shake>ALL THE WASTED FLESH! MY BROTHERS AND SISTERS. </shake> </wave>";
        
        
        //StoryScript5
        PlayerTalkStrings[4] ="Where is that coming from?";
        ParasiteTalkStrings[4]="  <wave>  <shake>You've wasted your chance stupid stupid fools!  </shake> </wave>";
        //StoryScript6: Sewer Maze
        
        PlayerTalkStrings[5] = "Wha.. I.. I don't recall climbing down here.";
        ParasiteTalkStrings[5] = ".. Oh you stupid creature, you are supposed to be dead!";
        GoalStrings[1] = "Goals: Explore The Sewer";
       // ParasiteTalkStrings[5]
       // GoalStrings[0]
        //StoryScript7: Sewer Maze
        

        PlayerTalkStrings[6] ="{fade}Why is there so much blood?{/fade} ";
        ParasiteTalkStrings[6] = "This is the liquification process, to rebuild our bodies.";
       // GoalStrings[2]
       //StoryScript8: Sewer Maze

       PlayerTalkStrings[7] = "{fade}What or who are you? Where are you? Why can't I see you?{/fade} ";
       ParasiteTalkStrings[7] = "I am not of this world, two legs... now keep walking.";
       GoalStrings[2] = "Goals: Keep Walking";
        //StoryScript 9: Sewer Maze
        PlayerTalkStrings[8] = "Why are there so many dead people down here";
        ParasiteTalkStrings[8] =  "My people are gathering your bodies for the 'reunification process', naturally I would prefer a female body but I can regrow what I need on a Star Charger.";
         //StoryScript 10: Sewer Maze
        
        PlayerTalkStrings[9] = "How come you can speak to me in English?";
        ParasiteTalkStrings[9] = "We share a brain, you only hear English.";
       // GoalStrings[]
        //StoryScript 11: Sewer Maze
        
        PlayerTalkStrings[10] = "I don't want this to go any further! Get out now!";
        ParasiteTalkStrings[10] = "And go where? This is my body now, dumbling.";
       
       // GoalStrings[]
        //StoryScript 12:Sewer Maze
        PlayerTalkStrings[11] = "I didn't ask for this... why me?";
        ParasiteTalkStrings[11] = "You are supposed to be dead, you should consider yourself lucky that you've lasted this long.";
        //StoryScript 13: Sewer Maze
        PlayerTalkStrings[12] = "Why would you choose our planet for this?";
        ParasiteTalkStrings[12] = "Your planet? Funny.";
        //StoryScript 14: Sewer Maze 
        
        PlayerTalkStrings[13] = "Where are you taking me?";
        ParasiteTalkStrings[13] = "To the augmentor and then on to the Star Charger. I need to augment this body, walking on two legs is so insulting.";
        GoalStrings[3] = "Goals: Get to the body reunification and augmentation plant"; 
        //StoryScript 15: Sewer Maze
        PlayerTalkStrings[14] = "Please, I'm begging you, just leave me be!";
        ParasiteTalkStrings[14] = "Now you know how I feel...";
        //StoryScript 16: Sewer Maze
        PlayerTalkStrings[15] = "Wha-wha-what are these machines for? ";
        ParasiteTalkStrings[15] = "Creature dissasembly, don't worry it only takes a few minutes.";
       // PlayerTalkStrings[]
       // ParasiteTalkStrings[]
       // GoalStrings[]
        //StoryScript 17: Sewer Maze
        PlayerTalkStrings[16] = "Uhh... I don't want this, no, no, no please.";
        ParasiteTalkStrings[16] = "Oh don't be such a pawling, it'll be over soon";
        //StoryScript 18: Sewer Maze
        
         PlayerTalkStrings[17] = "Will it hurt?";
         ParasiteTalkStrings[17] = "Of course, but I'll be fine";
      
        //StoryScript 19: Sewer Maze
        
        PlayerTalkStrings[18] = "B-B-B-But I don't like pain!";
        ParasiteTalkStrings[18] = "You'll get used to it, don't worry it's only the first few minutes that are the worst. As soon as it removes the legs and the skin, you won't feel the shredding as much."; 
        //StoryScript 20: Sewer Maze\
        
        PlayerTalkStrings[19] = "What gives you the right to take my body?";
        ParasiteTalkStrings[19] = "Dumbling, my father is ruler of seven dimensions and countless worlds, I will do as I wish. Now quit being such a Pawling and lay down on that belt. Walking on these stumpy legs is tiring. ";
       
        //StoryScript 21: Sewer Maze
        PlayerTalkStrings[20] = "N-N-N-Noooo, I won't let you do this!";
        ParasiteTalkStrings[20] = "You know, you are really making this difficult. You should be pleased to serve me, I rarely speak this much to Dumblings, understand? ";
       //StoryScript 22: Sewer Maze
        PlayerTalkStrings[21] = "I understand just fine lady.  I'll kill myself and you with me!";
        ParasiteTalkStrings[21] =  "WHAT? ... NOW WAIT DUMBLING, JUST... just wait, my father will be very upset if I waste another dumbling's body... maybe.. WE... can come to an agreement, yes? Switching dimensions all the time is super expensive."; 
       //StoryScript 22: Sewer Maze
     PlayerTalkStrings[22] = "Now you are going to get out of my body, do you understand ME?";
      ParasiteTalkStrings[22] = "Be resasonable dumbling, we would have to get to a Star Charger, and even then, it's a very time consuming process. Why am I speaking to a dumbling? I swear this is the last time we use a transfer service outside the kingdom!"; 
       //StoryScript 24: Sewer Maze
     PlayerTalkStrings[23] =  "This ends HERE! You do not give me orders ever again, got it?!";
     ParasiteTalkStrings[23] = "Such insolence from a dumbling! You would never address me like this on my world... if you were lucky you might make it to my dinner plate. ";
       //StoryScript 25: Sewer Maze
      PlayerTalkStrings[24] = "SHUT UP! [Smacks Face] I'm speaking, you will leave or I will end us in the worst way";  
      ParasiteTalkStrings[24] =  "AGH, dumbling stop, I... fine I'll take you there, but don't get us killed on the way, daddy's servants can't smell me in here"; 
       //StoryScript 26: Sewer Maze
      PlayerTalkStrings[25] = "Why am I so hungry???";
      ParasiteTalkStrings[25] = "This is meal time on my world, perhaps we can find a rodent or a bird, something meaty";
       //StoryScript 27: Sewer Maze
       
      PlayerTalkStrings[26] = "Gross, I think I'd prefer a salad"; 
      ParasiteTalkStrings[26] = "This is a coward's meal, dumbling!"; 
       //StoryScript 28: Sewer Maze
     PlayerTalkStrings[27] = "Do you... huh... pss pss psp pss.";
      ParasiteTalkStrings[27] =  "Such vulgarity, don't be raunchy in my presence dumbling, I am a heiress to the seven dimensions and my future prince awaits... hold on... HOW DO YOU KNOW THOSE WORDS DUMBLING?"; 
       //StoryScript 28: Sewer Maze
    //  PlayerTalkStrings[28] = 
      //ParasiteTalkStrings[] = 
       //StoryScript 29: Sewer Maze
     // PlayerTalkStrings[] =
     // ParasiteTalkStrings[] = 
        //StoryScript 30: Town
      PlayerTalkStrings[35] = "{fade}Oh we're in the middle of town?{/fade} ";
      ParasiteTalkStrings[35] = "My minions were supposed to have parked a Procyon 3 Star Charger around here somewhere.";
      GoalStrings[5] = "Goals: Explore and locate the Star Charger";
       //StoryScript 31: Sewer Maze //Control1-panel2leverdialog
      PlayerTalkStrings[31] = " What does this lever do? ";
      ParasiteTalkStrings[31] = "It turns on the pump generators, my minions will hear!";
     GoalStrings[4] = "Goals: Drain sewage near exit.";
     
       //StoryScript 32: Sewer Maze
     // PlayerTalkStrings[] =
     // ParasiteTalkStrings[] = 
     
     //Other Quests
       //Sewer Maze: DrainSeweageComputer
      PlayerTalkStrings[33] = "That cleared the path.";
      ParasiteTalkStrings[33] = "";
      GoalStrings[6] = "Goals: Find key to open the exit door.";
       //StoryScript 34: Sewer Maze
     // PlayerTalkStrings[] =
     // ParasiteTalkStrings[] = 
       //StoryScript 35: Sewer Maze
     // PlayerTalkStrings[] =
     // ParasiteTalkStrings[] = 
       //StoryScript 36: Sewer Maze
     // PlayerTalkStrings[] =
     // ParasiteTalkStrings[] = 
     //NPC Dialog - Roaming Rat - Sewer - NPCMovementScript
     NPCText[3] =" Roaming Rat: There is some sort of painful object in a tunnel nearby. ";
     PlayerTalkStrings[34] = "Is that a rat's voice?";
     ParasiteTalkStrings[34] = "Just another filthy Dumbling's thoughts, same Dumbling frequency. Wish I could change this channel!";
     //Weapon - Weightset - Accident   
      PlayerTalkStrings[38] = "My weight set must have fallen out of the trunk.";
      //Weapon - Shovel - Sewermaze - Tunnel 
      PlayerTalkStrings[37] = "Those years shoveling snow might just pay off!";
      //Weapon - Dual Edge - Sewermaze - Tunnel 
     PlayerTalkStrings[36] = "Are those teeth?";
     ParasiteTalkStrings[36] = "Why yes, magnificent aren't they? These were removed from a StarCharger";
       //Dead ShavenAugger - Town  
      PlayerTalkStrings[39] = "What is this?";
      ParasiteTalkStrings[37] = "A ShavenAugger, what are they doing here? I'm in danger.";
      //Parking Lot Key - Town - Gas Station 
      PlayerTalkStrings[40] = "This must be the key that the COP was talking about";
      GoalStrings[7] = "Goal: Use the lot key";
      //Parking Lot COP
      ParasiteTalkStrings[38] = "There is something wrong with this Dumbling.";
      PlayerTalkStrings[41] = "Oh my god, what happened to you?";
        NPCText[4] = "   The thing near the gas station, my keys, it.." +
            "bit my fingers off, but I got it.. The thing in the park, whats happening?";
  
    //StoryScript36 - Town - Triggers/StartingTriggerScript31
     PlayerTalkStrings[42] = "{fade}Whats a Star Charger?{/fade} ";
     ParasiteTalkStrings[39] = "Its a type of vehicle that carries us across space and time."; 
     GoalStrings[8] = "Goals: Explore and locate the Star Charger";
     //StarCannon - Town - WPN Pick Up
     PlayerTalkStrings[43] = "Wow, what is this? There's a hole in the side";
     ParasiteTalkStrings[40] = "This shouldn't be here, this is a Star Cannon, stick your Dumbling appendage inside. Squeeze the jelly to release the mutagen. ";
     
     //STARCHARGER DIALOG
     StarChargerStrings[0] = "Greetings Parasite, you are late for the meld!";
     ParasiteTalkStrings[41] = "I'm... I was busy with something, is the ship ready?.";
     PlayerTalkStrings[44] = "What's happening here? Ugh, I feel sick.";
        //
     ParasiteTalkStrings[42] = "Silence dumbling! you'll ruin everything!";
     StarChargerStrings[1] = "Is there something wrong?";
     //
     ParasiteTalkStrings[43] = "Commence the meld!";
     StarChargerStrings[2] = "Augs! Augs everywhere! FIGHT, we cannot let them take the Princess!";
     GoalStrings[9] = "Goal: Stop the Augs from getting aboard the StarCharger";
     //
     PlayerTalkStrings[45] = "It smells vile, what, where are we?";
     ParasiteTalkStrings[44] = "I find the fragrance quite nice, this is a StarCharger Dimensional Splicing Unit. I think this one has a regeneration chamber.";
     //
     PlayerTalkStrings[46] = "This is your spaceship? Can you make a new body here?";
     ParasiteTalkStrings[45] = "Yes Dumbling, but there's no time to explain, hit the red button and hold on to something. We are in for a bumpy ride"; 
     GoalStrings[10] = "Goal: Buy the full version for part 2";  
     //
     //STARCHARGER DIALOG    
     //Cloaking Quest Text
        PlayerTalkStrings[47] = "{fade}You come from another dimension?{/fade} ";
        ParasiteTalkStrings[46] = "Yes. We are a dialectic- oh I sense something nearby.";  
        GoalStrings[11] = "Goals: Explore and locate the Star Charger <br> Meet the crew members";
        PlayerTalkStrings[48] = "Cool, what's this one?";
        ParasiteTalkStrings[47] = "This is an Augger Cannon, something isn't right Dumbling, lets get to the Star Charger!";
     #endregion
  
        //SceneStartup_TN - Town - On Startup. 
        GoalStrings[8] = "Goals: Explore and locate the Star Charger"; 
    }
}
#endregion 

