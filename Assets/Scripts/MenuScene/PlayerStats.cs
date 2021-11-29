using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PlayerStats : MonoBehaviour
{       //O: archer; 1: fire; 2: ice; 3:lightning; 4: poison
    public static PlayerStats playerStats;
    [Header("TowerStat")]
    public int[] towerStar = {0,0,0,0,0};
    public float[] towerDamage;
    public float[] towerRange;
    public float[] towerRate;
    public int[] towerUpgradeCost;

    public bool[] towerStatus = {true, true, true, true, true};

    [Header("DefaultValue")]
    private float[] towerDefaultDmg = {12,20,10,10,10};
    private float[] towerDefaultRange = {1.5f, 2, 1.5f, 1.5f, 1.5f};
    private float[] towerDefaultRate = {1.2f, 0.4f, 0, 0, 0};

    [Header("Map")]
    public int map; //this var is used to keep the header

     [Header("Currencies")]
    public int gem = 1000000;
    public int diamond = 0;

    [Header("Unity Scripts Set Up")]
    public string[] towerArray = {
        "archerTowerStar", 
        "fireTowerStar", 
        "iceTowerStar", 
        "lightningTowerStar",
        "poisonTowerStar"};

    public string[] towerStatusArray = {
        "archerTowerStatus", 
        "fireTowerStatus", 
        "iceTowerStatus", 
        "lightningTowerStatus",
        "poisonTowerStatus"};

    void Awake()
    {
        if (playerStats != null)
        {
            Debug.LogError("More than one PlayerStats in scene");
            return;
        }
        playerStats = this;

        string path = Application.persistentDataPath + "/player.data";
        if(!File.Exists(path))
        {
            SaveSystem.saveSystem.Save();
        }

        GetStatsRebuild();
    }

    void SetMapDefaultCondition()
    {
        PlayerPrefs.GetString("2", "false");
    }

    public void GetStatsRebuild()
    {
        int numberOfTower = towerArray.Length;

        towerDamage = new float[numberOfTower];
        towerRange = new float[numberOfTower];
        towerRate = new float[numberOfTower];
        towerUpgradeCost = new int[numberOfTower];

        for (int i = 0; i < numberOfTower; i++)
        {        
            towerDamage[i] = towerDefaultDmg[i] + towerStar[i] ;
            towerRange[i] = towerDefaultRange[i];
            towerRate[i] = towerDefaultRate[i] + towerStar[i] * 0.1f;
            towerUpgradeCost[i] = 500 + towerStar[i] * 1000 + towerStar[i] * 500;
        }
    
    }
}
