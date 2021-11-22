using UnityEngine;
using UnityEngine.UI;

public class UpgradePageController : MonoBehaviour
{
    public Text towerDamage;
    public Text towerRange;
    public Text towerFireRate;
    public Text specialEffect;

    public Button btn;

    PlayerStats instance;

    void Start()
    {
        instance = PlayerStats.playerStats;
    }

    #region TowerTabs
    public void ArcherTowerUpgradeTab()
    {
        towerDamage.text = instance.archerTowerDamage.ToString();
        towerRange.text = instance.archerTowerRange.ToString();
        towerFireRate.text = instance.archerTowerRate.ToString();
        specialEffect.text = null;

        towerStar = instance.archerTowerStar;
        towerUpgradeCost = instance.archerTowerUpgradeCost;

        towerStarString = "archerTowerStar";
        tabName = "ArcherTower";

        if(btn.gameObject.activeSelf != true)
        {
            btn.gameObject.SetActive(true);
        }

        btn.onClick.AddListener(UpgradeButton);
    }

    public void FireTowerUpgradeTab()
    {
        towerDamage.text = instance.fireTowerDamage.ToString();
        towerRange.text = instance.fireTowerRange.ToString();
        towerFireRate.text = instance.fireTowerRate.ToString();
        specialEffect.text = null;

        towerStar = instance.fireTowerStar;
        towerUpgradeCost = instance.fireTowerUpgradeCost;

        towerStarString = "fireTowerStar";
        tabName = "FireTower";

        if (btn.gameObject.activeSelf != true)
        {
            btn.gameObject.SetActive(true);
        }

        btn.onClick.AddListener(UpgradeButton);
    }

    public void IceTowerUpgradeTab()
    {
        towerDamage.text = instance.iceTowerDamage.ToString();
        towerRange.text = instance.iceTowerRange.ToString();
        towerFireRate.text = instance.iceTowerRate.ToString();
        specialEffect.text = "- " + (instance.slowValue * 100).ToString() + " %speed for 3s";

        towerStar = instance.iceTowerStar;
        towerUpgradeCost = instance.iceTowerUpgradeCost;

        towerStarString = "iceTowerStar";
        tabName = "IceTower";

        if (btn.gameObject.activeSelf != true)
        {
            btn.gameObject.SetActive(true);
        }

        btn.onClick.AddListener(UpgradeButton);
    }

    public void LightningTowerUpgradeTab()
    {
        towerDamage.text = instance.lightningTowerDamage.ToString();
        towerRange.text = instance.lightningTowerRange.ToString();
        towerFireRate.text = instance.lightningTowerRate.ToString();
        specialEffect.text = null;

        towerStar = instance.lightningTowerStar;
        towerUpgradeCost = instance.lightningTowerUpgradeCost;

        towerStarString = "lightningTowerStar";
        tabName = "LightningTower";

        if (btn.gameObject.activeSelf != true)
        {
            btn.gameObject.SetActive(true);
        }

        btn.onClick.AddListener(UpgradeButton);
    }

    public void PoisonTowerUpgradeTab()
    {
        towerDamage.text = instance.poisonTowerDamage.ToString();
        towerRange.text = instance.poisonTowerRange.ToString();
        towerFireRate.text = instance.poisonTowerRate.ToString();
        specialEffect.text = "- " + (instance.poisonValue * 100).ToString() + " %HP/hit";

        towerStar = instance.poisonTowerStar;
        towerUpgradeCost = instance.poisonTowerUpgradeCost;

        towerStarString = "poisonTowerStar";
        tabName = "PoisonTower";

        if (btn.gameObject.activeSelf != true)
        {
            btn.gameObject.SetActive(true);
        }

        btn.onClick.AddListener(UpgradeButton);
    }

    public void TestTowerUpgradeTab()  
    {
        towerDamage.text = instance.testTowerDamage.ToString();
        towerRange.text = instance.testTowerRange.ToString();
        towerFireRate.text = instance.testTowerRate.ToString();
        specialEffect.text = null;

        towerStar = instance.testTowerStar;
        towerUpgradeCost = instance.testTowerUpgradeCost;

        towerStarString = "testTowerStar";
        tabName = "TestTower";

        if (btn.gameObject.activeSelf != true)
        {
            btn.gameObject.SetActive(true);
        }
        
        CheckTowerStatus("testTowerStatus");
        
    }
    #endregion

    private int towerStar;
    private int towerUpgradeCost;

    private string towerStarString;
    private string tabName;
    private string towerStatusString;

    void CheckTowerStatus(string _towerStatusString)
    {
        if(PlayerPrefs.GetString(_towerStatusString) == "false")
        {
            towerStarString = _towerStatusString;
            btn.onClick.AddListener(UnlockButton);
        }
        else
        {
            btn.onClick.AddListener(UpgradeButton);
        }
    }

    public void UpgradeButton()
    {
        if (towerStar < 5 && (instance.gem - towerUpgradeCost) >= 0)
        {            
            towerStar++;
            PlayerPrefs.SetInt(towerStarString, towerStar);

            instance.gem -= towerUpgradeCost;
            PlayerPrefs.SetInt("gem", instance.gem);
        
            instance.GetAllTowersStats();
            ResetUpgradeTab();
        }
    }

    void ResetUpgradeTab()
    {
        switch (tabName)
        {
            case "PoisonTower":
                PoisonTowerUpgradeTab();
                break;

            case "LightningTower":
                LightningTowerUpgradeTab();
                break;

            case "IceTower":
                IceTowerUpgradeTab();
                break;

            case "ArcherTower":
                ArcherTowerUpgradeTab();
                break;

            case "FireTower":
                FireTowerUpgradeTab();
                break;
            case "TestTower":
                TestTowerUpgradeTab();
                break;
        }
    }

    public void UnlockButton()
    {
        if ((instance.gem - towerUpgradeCost) >= 0)
        {            
            PlayerPrefs.SetString(towerStatusString, "true");

            instance.gem -= 4000; //unlock cost
            PlayerPrefs.SetInt("gem", instance.gem);
        
            instance.GetAllTowersStats();
            ResetUpgradeTab();
        }
    }
}
