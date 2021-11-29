using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    [Header("TowerData")]
    public int[] towerStar;
    public bool[] towerStatus;

    [Header("CurrenciesData")]
    public int gem;
    public int diamond;

    public SaveData (PlayerStats _playerStats)
    {

        int numberOfTower = _playerStats.towerArray.Length;
        
        towerStar = new int[numberOfTower];
        towerStatus = new bool[numberOfTower];

        for(int i = 0; i < numberOfTower; i++)
        {
            towerStar[i] = _playerStats.towerStar[i];
            towerStatus[i] = _playerStats.towerStatus[i];        
        }
        
        gem = _playerStats.gem;
        diamond = _playerStats.diamond;    
    }
}
