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

    //chổ này đem lên chưa biết để header là gì
    private int towerStar;
    private int towerUpgradeCost;

    private string towerStarString;
    private string tabName;
    private string towerStatusString;
    void Start()
    {
        instance = PlayerStats.playerStats;
    }
    public void OpenTowerUpgradeTab(int towerType)
    {
        towerDamage.text = instance.towerDamage[towerType].ToString();
        towerRange.text = instance.towerRange[towerType].ToString();
        towerFireRate.text = instance.towerRate[towerType].ToString();
        specialEffect.text = null;

        towerStar = instance.towerStar[towerType];
        towerUpgradeCost = instance.towerUpgradeCost[towerType];

        towerStarString = "archerTowerStar"; //còn là hardcode
        tabName = "ArcherTower"; //còn là hardcode

        if(btn.gameObject.activeSelf != true)
        {
            btn.gameObject.SetActive(true);
        }

        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(UpgradeButton);

        Debug.Log(towerType);
    }
    void CheckTowerStatus(string _towerStatusString) //chưa hiểu lắm
    {
        if(PlayerPrefs.GetString(_towerStatusString) == "false")
        {
            towerStarString = _towerStatusString;
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(UnlockButton);
        }
        else
        {
            btn.onClick.RemoveAllListeners();
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
        
            instance.GetStatsRebuild();
            ResetUpgradeTab();
        }
    }

    void ResetUpgradeTab()
    {
        switch (tabName)
        {
            case "PoisonTower":
                OpenTowerUpgradeTab(4);
                break;

            case "LightningTower":
                OpenTowerUpgradeTab(3);
                break;

            case "IceTower":
                OpenTowerUpgradeTab(2);
                break;

            case "ArcherTower":
                OpenTowerUpgradeTab(0);
                break;

            case "FireTower":
                OpenTowerUpgradeTab(1);
                break;
            case "TestTower":
                OpenTowerUpgradeTab(5);
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
        
            instance.GetStatsRebuild();
            ResetUpgradeTab();
        }
    }
}
