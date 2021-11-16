using UnityEngine;
using System.Collections.Generic;


public class ModePageController : MonoBehaviour
{
    public List<MapButton> mapButtons;

    void Start()
    {
        SetUnlockMap();
    }

    public void AddMapButton(MapButton button)
    {
        if(mapButtons == null)
        {
            mapButtons = new List<MapButton>();
        }
        mapButtons.Add(button);
    }

    void SetUnlockMap()
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
}
