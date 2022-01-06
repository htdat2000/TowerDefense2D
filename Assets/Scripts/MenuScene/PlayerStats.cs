using UnityEngine;
using System.IO;

public class PlayerStats : MonoBehaviour
{       //O: archer; 1: fire; 2: ice; 3:miner; 4: poison
    public static PlayerStats playerStats;
    [Header("Tower")]
    public bool[] towerStatus = {true, true, true, true, true};

    [Header("Map")]
    public int map;
    public bool[] mapStatus = {true, false};
    public GameObject[] mapSet;

     [Header("Currencies")]
    public int gem = 100000;
    public int diamond = 0;

    private string savePath;

    [Header("Unity Scripts Set Up")]
    public string[] towerArray = {
        "archerTowerStar", 
        "fireTowerStar", 
        "iceTowerStar", 
        "lightningTowerStar", //change to miner
        "poisonTowerStar"};
    private bool isLoaded = false;
    void Awake()
    {
        if (playerStats != null)
        {
            Debug.LogError("More than one PlayerStats in scene");
            return;
        }
        playerStats = this;
   
        savePath = Application.persistentDataPath + "/player.data";
        if(!File.Exists(savePath))
        {
            Save();        
        }
        else if(!isLoaded)
        {
            LoadData();
            isLoaded = true;
        }    

        GetMapSet();
    }

    public void GetMapSet()
    {
        mapSet = Resources.LoadAll<GameObject>("MapSet"); 
    }

    public void Save()
    {
        SaveSystem.Save(this);
    }

    void LoadData()
    {
      SaveData data = SaveSystem.LoadSaveData();

      if(data == null)
      return;

      LoadTowerData(data);
      LoadCurrenciesData(data); 
      LoadMapData(data);        
    }

    void LoadTowerData(SaveData data)
    {
        int playerTowerNumber = towerStatus.Length;
        int dataTowerNumber = data.towerStatus.Length;
        int numberOfTower = 0;
        
        if(playerTowerNumber < dataTowerNumber)
        {
            numberOfTower = playerTowerNumber;
        }
        else numberOfTower = dataTowerNumber;
        
        //Debug.Log(numberOfTower);
        for(int i = 0; i < numberOfTower; i++)
      {
          //if(data.towerStatus[i] != null)
        towerStatus[i] = data.towerStatus[i]; 
                  
      }   
    }

    void LoadCurrenciesData(SaveData data)
    {
        gem = data.gem;
        diamond = data.diamond;
    }

    void LoadMapData(SaveData data)
    {
        int playerMapNumber = mapStatus.Length;
        int dataMapNumber = data.mapStatus.Length;
        int numberOfMap = 0;
        
        if(playerMapNumber < dataMapNumber)
        {
            numberOfMap = playerMapNumber;
        }
        else numberOfMap = dataMapNumber;

        for(int i = 0; i < numberOfMap; i++)
        {
            mapStatus[i] = data.mapStatus[i];
        }
    }
}
