using UnityEngine;

public class PlayerStats : MonoBehaviour
{       //O: archer; 1: fire; 2: ice; 3:lightning; 4: poison
    public static PlayerStats playerStats;
    [Header("TowerStat")]
    public int[] towerStar;
    public float[] towerDamage;
    public float[] towerRange;
    public float[] towerRate;
    public int[] towerUpgradeCost;

    public string[] towerStatus;

    [Header("DefaultValue")]
    private float[] towerDefaultDmg = {12,20,10,10,10};
    private float[] towerDefaultRange = {1.5f, 2, 1.5f, 1.5f, 1.5f};
    private float[] towerDefaultRate = {1.2f, 0.4f, 0, 0, 0};

    [Header("Map")]
    public int map; //this var is used to keep the header

     [Header("Currencies")]
    public int gem;
    public int diamond;

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


        GetStatsRebuild();

        Currencies();
    }
   
    void Currencies()
    {
        gem = PlayerPrefs.GetInt("gem", 100000);
        diamond = PlayerPrefs.GetInt("diamond", 0);
    }

    void SetMapDefaultCondition()
    {
        PlayerPrefs.GetString("2", "false");
    }

    public void GetStatsRebuild()
    {
        int numberOfTower = towerArray.Length;

        towerStar = new int[numberOfTower];
        towerDamage = new float[numberOfTower];
        towerRange = new float[numberOfTower];
        towerRate = new float[numberOfTower];
        towerUpgradeCost = new int[numberOfTower];
        towerStatus = new string[numberOfTower];

        for (int i = 0; i < numberOfTower; i++)
        {
            towerStar[i] = PlayerPrefs.GetInt(towerArray[i], 0);
            towerDamage[i] = towerDefaultDmg[i] + towerStar[i] ;
            towerRange[i] = towerDefaultRange[i];
            towerRate[i] = towerDefaultRate[i] + towerStar[i] * 0.1f;
            towerUpgradeCost[i] = 500 + towerStar[i] * 1000 + towerStar[i] * 500;

            if(i < 5)
            {
                towerStatus[i] = PlayerPrefs.GetString(towerStatusArray[i], "true");
            }
            else 
            {
                towerStatus[i] = PlayerPrefs.GetString(towerStatusArray[i], "false");
            }
        }
    
    }
}
