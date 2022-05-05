using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MOTHBALLED, migrated to ItemChecker
public class ItemTracker : MonoBehaviour
{
    #region Variables
    int AC_SavedItem0,AC_SavedItem1, AC_SavedItem2, AC_SavedItem3, AC_SavedItem4, AC_SavedItem5, AC_SavedItem6, AC_SavedItem7, AC_SavedItem8, AC_SavedItem9, AC_SavedItem10, AC_SavedItem11;  
    
    public GameObject Dumbell;
    public GameObject[] MAPItems = new GameObject[12]; 
    public int[] MAPItemsStatus = new int[12];
    #endregion
    // Start is called before the first frame update
    void Start()
    {
     //   DontDestroyOnLoad(this);
        //  AC_LoadingMAPItemStatus(); 
    }
    void Update()
    {
        
    }
    
#region SavingItemStatus()
    // Update is called once per frame
    public void SavingItemStatus()
    {
        if(Dumbell.activeSelf == true)//DUMBELL
        {
            PlayerPrefs.SetInt("item0", 1);//Store as TRUE
            Debug.Log("Dumbell is ONE/TRUE");
        }
        else
        {
            PlayerPrefs.SetInt("item0", 0);//Store as FALSE
            Debug.Log("Dumbell is FALSE");
        }
        if(MAPItems[1].activeSelf == true)
        {
            PlayerPrefs.SetInt("item1", 1);//Store as TRUE
        }
        else
        {
            PlayerPrefs.SetInt("item1", 0);//Store as FALSE
        }
        if(MAPItems[2].activeSelf == true)
        {
            PlayerPrefs.SetInt("item2", 1);//Store as TRUE
        }
        else
        {
            PlayerPrefs.SetInt("item2", 0);//Store as FALSE
        }
        if(MAPItems[3].activeSelf == true)
        {
            PlayerPrefs.SetInt("item3", 1);//Store as TRUE
        }
        else
        {
            PlayerPrefs.SetInt("item3", 0);//Store as FALSE
        }
        if(MAPItems[4].activeSelf == true)
        {
            PlayerPrefs.SetInt("item4", 1);//Store as TRUE
        }
        else
        {
            PlayerPrefs.SetInt("item4", 0);//Store as FALSE
        }
        if(MAPItems[5].activeSelf == true)
        {
            PlayerPrefs.SetInt("item5", 1);//Store as TRUE
        }
        else
        {
            PlayerPrefs.SetInt("item5", 0);//Store as FALSE
        }
        if(MAPItems[6].activeSelf == true)
        {
            PlayerPrefs.SetInt("item6", 1);//Store as TRUE
        }
        else
        {
            PlayerPrefs.SetInt("item6", 0);//Store as FALSE
        }
        if(MAPItems[7].activeSelf == true)
        {
            PlayerPrefs.SetInt("item7", 1);//Store as TRUE
        }
        else
        {
            PlayerPrefs.SetInt("item7", 0);//Store as FALSE
        }
        if(MAPItems[8].activeSelf == true)
        {
            PlayerPrefs.SetInt("item8", 1);//Store as TRUE
        }
        else
        {
            PlayerPrefs.SetInt("item8", 0);//Store as FALSE
        }
        if(MAPItems[9].activeSelf == true)
        {
            PlayerPrefs.SetInt("item9", 1);//Store as TRUE
        }
        else
        {
            PlayerPrefs.SetInt("item9", 0);//Store as FALSE
        }
        if(MAPItems[10].activeSelf == true)
        {
            PlayerPrefs.SetInt("item10", 1);//Store as TRUE
        }
        else
        {
            PlayerPrefs.SetInt("item10", 0);//Store as FALSE
        }
    }
#endregion

#region LoadingMAPItemStatus()
    public void AC_LoadingMAPItemStatus()
    {
        MAPItemsStatus[0] = PlayerPrefs.GetInt("Item0");
        Debug.Log(MAPItemsStatus[0]);
        MAPItemsStatus[1] = PlayerPrefs.GetInt("Item1");
        Debug.Log(MAPItemsStatus[1]);
        MAPItemsStatus[2] = PlayerPrefs.GetInt("Item2");
        Debug.Log(MAPItemsStatus[2]);
        MAPItemsStatus[3] = PlayerPrefs.GetInt("Item3");
        Debug.Log(MAPItemsStatus[3]);
        MAPItemsStatus[4] = PlayerPrefs.GetInt("Item4");
        Debug.Log(MAPItemsStatus[4]);
        MAPItemsStatus[5] = PlayerPrefs.GetInt("Item5");
        Debug.Log(MAPItemsStatus[5]);
        MAPItemsStatus[6] = PlayerPrefs.GetInt("Item6");
        Debug.Log(MAPItemsStatus[6]);
        MAPItemsStatus[7] = PlayerPrefs.GetInt("Item7");
        Debug.Log(MAPItemsStatus[7]);
        MAPItemsStatus[8] = PlayerPrefs.GetInt("Item8");
        Debug.Log(MAPItemsStatus[8]);
        MAPItemsStatus[9] = PlayerPrefs.GetInt("Item9");
        Debug.Log(MAPItemsStatus[9]);
        MAPItemsStatus[10] = PlayerPrefs.GetInt("Item10");
        Debug.Log(MAPItemsStatus[10]);
        MAPItemsStatus[11] = PlayerPrefs.GetInt("Item11");
        Debug.Log(MAPItemsStatus[11]);
    
       #endregion
       
       #region DestroyMAPItems()
    //Destroy game objects that were already picked up in this level. 

    
        if(MAPItemsStatus[0] == 0)
        {
            Debug.Log("Set Dumbell to FALSE");
            Dumbell.SetActive(false);
            
        }
        if(MAPItemsStatus[1] == 0)
        {
            MAPItems[1].SetActive(false);
        }
        if(MAPItemsStatus[2] == 0)
        {
            MAPItems[2].SetActive(false);
        }
        if(MAPItemsStatus[3] == 0)
        {
            MAPItems[3].SetActive(false);
        }
        if(MAPItemsStatus[4] == 0)
        {
            MAPItems[4].SetActive(false);
        }
        if(MAPItemsStatus[5] == 0)
        {
            MAPItems[5].SetActive(false);
        }
        if(MAPItemsStatus[6] == 0)
        {
            MAPItems[6].SetActive(false);
        }
        if(MAPItemsStatus[7] == 0)
        {
            MAPItems[7].SetActive(false);
        }
        if(MAPItemsStatus[8] == 0)
        {
            MAPItems[8].SetActive(false);
        }            
        if(MAPItemsStatus[9] == 0)
        {
            MAPItems[9].SetActive(false);
        }            
        if(MAPItemsStatus[10] == 0)
        {
            MAPItems[10].SetActive(false);
        }            
        if(MAPItemsStatus[11] == 0)
        {
            MAPItems[11].SetActive(false);
        }            
    }
#endregion      
    
}
