﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpScript : MonoBehaviour
{

//Load all necessary saved items. 
    [SerializeField]
    internal GameSaver GameSaverScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Awake()
    {   //Load all settings. 
         GameSaverScript.Load();
    }
}