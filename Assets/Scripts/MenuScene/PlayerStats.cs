using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;
    [Header("TowerStat")]
    public int[] towerStar;
    public int[] towerDamage;
    public float[] towerRange;
    public float[] towerRate;
    public int[] towerUpgradeCost;

    void Awake()
    {
        if (playerStats != null)
        {
            Debug.LogError("More than one PlayerStats in scene");
            return;
        }
        playerStats = this;


        GetStatsRebuild();

        GetAllTowersStats();
        Currencies();
    }

    [Header("Currencies")]
    public int gem;
    public int diamond;

    void Currencies()
    {
        gem = PlayerPrefs.GetInt("gem", 100000);
        diamond = PlayerPrefs.GetInt("diamond", 0);
    }

    #region Towers 
    public void GetAllTowersStats()
    {
        FireTowerStats();
        ArcherTowerStats();
        IceTowerStats();
        LightningTowerStats();
        PoisonTowerStats();
        TestTowerStats();
    }

    [Header("ArcherTower")]
    public int archerTowerStar;

    public int archerTowerDamage;
    public float archerTowerRange;
    public float archerTowerRate;

    public int archerTowerUpgradeCost;

    void ArcherTowerStats()
    {
        archerTowerStar = PlayerPrefs.GetInt("archerTowerStar", 0);

        archerTowerDamage = 12 + archerTowerStar;
        archerTowerRange = 1.2f;
        archerTowerRate = 1.2f + archerTowerStar * 0.1f;

        archerTowerUpgradeCost = 500 + archerTowerStar * 1000 + archerTowerStar * 500;
    }

    [Header("FireTower")]
    public int fireTowerStar;

    public int fireTowerDamage;
    public float fireTowerRange;
    public float fireTowerRate;

    public int fireTowerUpgradeCost;

    void FireTowerStats()
    {
        fireTowerStar = PlayerPrefs.GetInt("fireTowerStar", 0);

        fireTowerDamage = 20 + fireTowerStar;
        fireTowerRange = 1.5f;
        fireTowerRate = 0.5f + fireTowerStar * 0.05f;

        fireTowerUpgradeCost = 750 + fireTowerStar * 1250 + fireTowerStar * 600;
    }

    [Header("IceTower")]
    public int iceTowerStar;

    public int iceTowerDamage;
    public float iceTowerRange;
    public float iceTowerRate;
    public float slowValue;

    public int iceTowerUpgradeCost;

    void IceTowerStats()
    {
        iceTowerStar = PlayerPrefs.GetInt("iceTowerStar", 0);

        iceTowerDamage = 10 + iceTowerStar;
        iceTowerRange = 1.5f + iceTowerStar * 0.1f;
        iceTowerRate = 0.6f + iceTowerStar * 0.1f;
        slowValue = 0.05f + iceTowerStar * 0.01f;

        iceTowerUpgradeCost = 500 + iceTowerStar * 1000 + iceTowerStar * 500;
    }

    [Header("LightningTower")]
    public int lightningTowerStar;

    public int lightningTowerDamage;
    public float lightningTowerRange;
    public float lightningTowerRate;

    public int lightningTowerUpgradeCost;

    void LightningTowerStats()
    {
        lightningTowerStar = PlayerPrefs.GetInt("lightningTowerStar", 0);

        lightningTowerDamage = 10 + lightningTowerStar;
        lightningTowerRange = 1.5f + lightningTowerStar * 0.1f;
        lightningTowerRate = 0.6f + lightningTowerStar * 0.1f;

        lightningTowerUpgradeCost = 500 + lightningTowerStar * 1000 + lightningTowerStar * 500;
    }

    [Header("PoisonTower")]
    public int poisonTowerStar;

    public int poisonTowerDamage;
    public float poisonTowerRange;
    public float poisonTowerRate;
    public float poisonValue;

    public int poisonTowerUpgradeCost;

    void PoisonTowerStats()
    {
        poisonTowerStar = PlayerPrefs.GetInt("poisonTowerStar", 0);

        poisonTowerDamage = 1 + poisonTowerStar;
        poisonTowerRange = 1.5f + poisonTowerStar * 0.1f;
        poisonTowerRate = 0.6f + poisonTowerStar * 0.1f;
        poisonValue = 0.05f + poisonTowerStar * 0.01f;

        poisonTowerUpgradeCost = 500 + poisonTowerStar * 1000 + poisonTowerStar * 500;
    }

    [Header("TestTower")]           //this tower is used for testing unlock function
    public string testTowerStatus;
    public int testTowerStar;

    public int testTowerDamage;
    public float testTowerRange;
    public float testTowerRate;

    public int testTowerUpgradeCost;

    void TestTowerStats()
    {   
        testTowerStatus = PlayerPrefs.GetString("testTowerStatus","false");
        testTowerStar = PlayerPrefs.GetInt("testTowerStar", 0);

        testTowerDamage = 1 + testTowerStar;
        testTowerRange = 1.5f + testTowerStar * 0.1f;
        testTowerRate = 0.6f + testTowerStar * 0.1f;
        
        testTowerUpgradeCost = 500 + testTowerStar * 1000 + testTowerStar * 500;
    }

    #endregion

    [Header("Map")]
    public int map; //this var is used to keep the header

    void SetMapDefaultCondition()
    {
        PlayerPrefs.GetString("2", "false");
    }

    void GetStatsRebuild()
    {
        string[] towerArray = {
        "archerTowerStar", 
        "fireTowerStar", 
        "iceTowerStar", 
        "lightningTowerStar",
        "poisonTowerStar"};

        int numberOfTower = towerArray.Length;

        towerStar = new int[numberOfTower];
        towerDamage = new int[numberOfTower];
        towerRange = new float[numberOfTower];
        towerRate = new float[numberOfTower];
        towerUpgradeCost = new int[numberOfTower];

        for (int i = 0; i < numberOfTower; i++)
        {
            towerStar[i] = PlayerPrefs.GetInt(towerArray[i], 0);
            towerDamage[i] = 12 + towerStar[i] ;
            towerRange[i] = 1.5f + towerStar[i] * 0.1f;
            towerRate[i] = 1f + towerStar[i] * 0.1f;
            towerUpgradeCost[i] = 500 + towerStar[i] * 1000 + towerStar[i] * 500;
        }
        
    }
}
