using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;

    void Awake()
    {
        if (playerStats != null)
        {
            Debug.LogError("More than one PlayerStats in scene");
            return;
        }
        playerStats = this;

        GetAllTowersStats();
        Currencies();
    }

    [Header("Currencies")]
    public int gem;
    public int diamond;

    void Currencies()
    {
        gem = PlayerPrefs.GetInt("Gem", 100000);
        diamond = PlayerPrefs.GetInt("Diamond", 0);
    }

    #region Towers 
    public void GetAllTowersStats()
    {
        FireTowerStats();
        ArcherTowerStats();
        IceTowerStats();
        LightningTowerStats();
        PoisonTowerStats();
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

        archerTowerDamage = 10 + archerTowerStar;
        archerTowerRange = 1.5f + archerTowerStar * 0.1f;
        archerTowerRate = 1f + archerTowerStar * 0.1f;

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

        fireTowerDamage = 10 + fireTowerStar;
        fireTowerRange = 1.5f + fireTowerStar * 0.1f;
        fireTowerRate = 0.6f + fireTowerStar * 0.1f;

        fireTowerUpgradeCost = 500 + fireTowerStar * 1000 + fireTowerStar * 500;
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
    #endregion

    [Header("Map")]
    public int map;

    void SetMapDefaultCondition()
    {
        PlayerPrefs.GetString("2", "false");
    }
}
