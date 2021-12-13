using UnityEngine;

[System.Serializable]
public class SaveData
{
    [Header("TowerData")]
    public int[] towerStar;
    public bool[] towerStatus;

    [Header("MapData")]
    public bool[] mapStatus;

    [Header("CurrenciesData")]
    public int gem;
    public int diamond;


    public SaveData (PlayerStats _playerStats)
    {
        GetTowerData(_playerStats);
        GetCurrenciesData(_playerStats);
        GetMapData(_playerStats);          
    }

    void GetTowerData(PlayerStats _playerStats)
    {
        int numberOfTower = _playerStats.towerArray.Length;      
        
        towerStatus = new bool[numberOfTower];

        for(int i = 0; i < numberOfTower; i++)
        {
            
            towerStatus[i] = _playerStats.towerStatus[i];        
        }
    }

    void GetCurrenciesData(PlayerStats _playerStats)
    {
        gem = _playerStats.gem;
        diamond = _playerStats.diamond;
    }

    void GetMapData(PlayerStats _playerStats)
    {
        int numberOfMap = _playerStats.mapStatus.Length;

        mapStatus = new bool[numberOfMap];

        for(int i = 0; i < numberOfMap; i++)
        {
            mapStatus[i] = _playerStats.mapStatus[i];
        }
    }
}
