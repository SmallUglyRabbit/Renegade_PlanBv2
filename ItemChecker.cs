using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The Item Checker goes through a level ensuring that all picked
//up items are deleted upon LOAD. You slot in the 10 items 
//per level and it checks if they've been picked up each load and
//then destroys them accordingly. 
public class ItemChecker : MonoBehaviour
{
    #region VARS
    public GameObject Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8, Item9, Item10; 
    public string i1,i2,i3,i4,i5,i6,i7,i8,i9,i10; 
    #endregion
    // Start is called before the first frame update
    void Start()
    {
     }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region LoadActiveItems()
    public void LoadActiveItems()//Reloads the items status' 
    {
        i1 = PlayerPrefs.GetString("Item1");    
        i2 = PlayerPrefs.GetString("Item2");
        i3 = PlayerPrefs.GetString("Item3");
        i4 = PlayerPrefs.GetString("Item4");
        i5 = PlayerPrefs.GetString("Item5");
        i6 = PlayerPrefs.GetString("Item6");
        i7 = PlayerPrefs.GetString("Item7");
        i8 = PlayerPrefs.GetString("Item8");
        i9 = PlayerPrefs.GetString("Item9");
        i10 = PlayerPrefs.GetString("Item10");
    
    }
    #endregion 
    #region CheckLoadedItems()
    public void CheckLoadedItems()//Checks the reloaded items for on/off status and removes them as necessary. 
    {
        Debug.Log("CheckLoadedItems()");
        if(i1 == "off")
        {
            Item1.SetActive(false);
        }
        if(i2 == "off")
        {
            Item2.SetActive(false);
        }
        if(i3 == "off")
        {
            Item3.SetActive(false);
        }
        if(i4 == "off")
        {
            Item4.SetActive(false);
        }
        if(i5 == "off")
        {
            Item5.SetActive(false);
        }
        if(i6 == "off")
        {
            Item6.SetActive(false);
        }
        if(i7 == "off")
        {
            Item7.SetActive(false);
        }
        if(i8 == "off")
        {
            Item8.SetActive(false);
        }
        if(i9 == "off")
        {
            Item9.SetActive(false);
        }
        if(i10 == "off")
        {
            Item10.SetActive(false);
        }
    }
    #endregion
    #region Checker()
    public void Checker()//Checks all items for active status, if not, stores the 'off' string in a save with the corresponding Item. Used before game is saved. 
    {
        Debug.Log("ItemChecker - Checker()");
     if(Item1.activeSelf == false)
     {
         PlayerPrefs.SetString("Item1","off");
         
     }
     if(Item2.activeSelf == false)
     {
         PlayerPrefs.SetString("Item2","off");
         
     }
     if(Item3.activeSelf == false)
     {
         PlayerPrefs.SetString("Item3","off");
         
     }
     if(Item4.activeSelf == false)
     {
         PlayerPrefs.SetString("Item4","off");
         
     }
     if(Item5.activeSelf == false)
     {
         PlayerPrefs.SetString("Item5","off");
         
     }
     if(Item6.activeSelf == false)
     {
         PlayerPrefs.SetString("Item6","off");
         
     }
     if(Item7.activeSelf == false)
     {
         PlayerPrefs.SetString("Item7","off");
         
     }
     if(Item8.activeSelf == false)
     {
         PlayerPrefs.SetString("Item8","off");
         
     }
     if(Item9.activeSelf == false)
     {
         PlayerPrefs.SetString("Item9","off");
         
     }
     if(Item10.activeSelf == false)
     {
         PlayerPrefs.SetString("Item10","off");
     }
     
    }
    #endregion
    }
