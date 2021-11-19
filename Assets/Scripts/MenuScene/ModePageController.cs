﻿using UnityEngine;
using System.Collections.Generic;


public class ModePageController : MonoBehaviour
{
    public List<MapButton> mapButtons;

    public GameObject mapPanel;

    void Start()
    {
        easyMode = false;
        normalMode = false;
    }

    public void AddMapButton(MapButton button) //Add map button to list
    {
        if(mapButtons == null)
        {
            mapButtons = new List<MapButton>();
        }
        mapButtons.Add(button);
    }

    public void SetUnlockMap() 
    {     
        for (int i = 0; i < mapButtons.Count; i++) //Button 0 == map index 2 (Build Setting option)
        {
            int mapIndex = i + 2;            
            if (PlayerPrefs.GetString(mapIndex.ToString()) == "true") 
            {
                mapButtons[i].AddMapToGo(mapIndex);
            }
            else 
            {
                mapButtons[i].AddUnlockMapFunction(mapIndex);              
            }
        }
    }

    [Header("Mode Option")]
    public static bool easyMode;
    public static bool normalMode;

    public void ChooseEasyMode()
    {
        easyMode = true;
        mapPanel.SetActive(true);
    }

    public void ChooseNormalMode()
    {
        normalMode = true;
        mapPanel.SetActive(true);
    }
}
