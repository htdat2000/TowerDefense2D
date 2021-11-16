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

    private int towerStar;
    private int towerUpgradeCost;

    private string towerStarString;
    private string tabName;

    public void UpgradeButton()
    {
        if (towerStar < 5 && (instance.gem - towerUpgradeCost) >= 0)
        {            
            towerStar++;
            PlayerPrefs.SetInt(towerStarString, towerStar);

            instance.gem -= towerUpgradeCost;
            PlayerPrefs.SetInt("Gem", instance.gem);
        
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
        }
    }

    /*public void VisibleTower() Idea code use to unlock tower
    {
    Display tower attributes...

        if(PlayPref.Getstring("VisibleTowerStatus") == false)
        {
        btn.onclick.Addlistener(UnlockTower);
        }
        else
        {
        btn.onclick.Addlistener(UpgradeButton);
        }
    }*/
}
