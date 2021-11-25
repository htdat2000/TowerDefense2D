using UnityEngine;
using UnityEngine.UI;

public class TowerStatusUI : MonoBehaviour
{
    public Text towerName;
    public Text damageTxt;
    public Text rangeTxt;
    public Text fRateTxt;

    public Button upgradeTowerLevelBtn;
    public Button sellTowerBtn;

    private GameObject selectedTower;
    private Tower selectedTowerPrefab;

    public void UpdateStatusUI(float[] stats)
    {
        towerName.text = stats[0].ToString();
        damageTxt.text = stats[1].ToString();
        rangeTxt.text = stats[2].ToString();
        fRateTxt.text = stats[3].ToString();
    }

    public void UpdateSelectedTower(GameObject tower, Tower towerPrefab)
    {
        selectedTower = tower;
        selectedTowerPrefab = towerPrefab;

        UpgradeTowerLevelFunction();
        SellTowerFunction();
    }

    void UpgradeTowerLevelFunction()
    {
        Debug.Log("Check");
        if(selectedTowerPrefab.level < 5)
        {
            Debug.Log("Addlistener");
            upgradeTowerLevelBtn.onClick.AddListener(selectedTowerPrefab.UpgradeTowerLevel);
        }
    }

    void SellTowerFunction()
    {
        sellTowerBtn.onClick.AddListener(selectedTowerPrefab.SellTower);
    }
}
