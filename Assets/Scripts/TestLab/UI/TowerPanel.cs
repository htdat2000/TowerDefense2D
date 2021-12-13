using UnityEngine;
using System.Collections.Generic;

public class TowerPanel : MonoBehaviour
{
    public List<TowerButton> towerButtons;
    private int listLength = 0;

    void Start()
    {
        CheckTowerCanBuild();
    }

    public void AddTowerButton(TowerButton button)
    {
        if(towerButtons == null)
        {
            towerButtons = new List<TowerButton>();
        }
        towerButtons.Add(button);
        listLength++;
    }

    void CheckTowerCanBuild()
    {
        for(int i = 0; i < listLength; i ++)
        {
            towerButtons[i].gameObject.SetActive(PlayerStats.playerStats.towerStatus[i]);
            string status = PlayerStats.playerStats.towerStatus[i].ToString();
            Debug.Log(i + status );
        }
    }
}
