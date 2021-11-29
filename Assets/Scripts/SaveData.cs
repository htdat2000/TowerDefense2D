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

    public SaveData ()
    {
        PlayerStats instance = PlayerStats.playerStats;

        int numberOfTower = instance.towerArray.Length;
        
        towerStar = new int[numberOfTower];
        towerStatus = new bool[numberOfTower];

        for(int i = 0; i < numberOfTower; i++)
        {
            towerStar[i] = instance.towerStar[i];
            towerStatus[i] =instance. towerStatus[i];        
        }
        
        gem = PlayerStats.playerStats.gem;
        diamond = PlayerStats.playerStats.diamond;    
    }
}
