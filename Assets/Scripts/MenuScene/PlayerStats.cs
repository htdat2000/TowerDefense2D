using UnityEngine;
using System.IO;

public class PlayerStats : MonoBehaviour
{       //O: archer; 1: fire; 2: ice; 3:miner; 4: poison
    public static PlayerStats playerStats;
    [Header("TowerStat")]
    public float[] towerDamage;
    public float[] towerRange;
    public float[] towerRate;
    public int[] towerUpgradeCost;
    public int[] towerStar = {0,0,0,0,0};

    public bool[] towerStatus = {true, true, true, false, false};

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
        int numberOfTower = towerArray.Length;
        
        for(int i = 0; i < numberOfTower; i++)
      {
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
        int numberOfMap = mapStatus.Length;

        mapStatus = new bool[numberOfMap];

        for(int i = 0; i < numberOfMap; i++)
        {
            mapStatus[i] = data.mapStatus[i];
        }
    }
}
