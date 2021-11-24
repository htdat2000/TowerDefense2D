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

    void UpdateStatusUI(float[] stats)
    {
        towerName.text = stats[0].ToString();
        damageTxt.text = stats[1].ToString();
        rangeTxt.text = stats[2].ToString();
        fRateTxt.text = stats[3].ToString();
    }

    void UpdateSelectedTower(GameObject tower)
    {
        selectedTower = tower;
        selectedTowerPrefab = selectedTower.GetComponent<Tower>();
    }

    void UpgradeTowerLevel()
    {
        if(selectedTowerPrefab.level < 5)
        {
            upgradeTowerLevelBtn.onClick.AddListener(selectedTowerPrefab.UpgradeTowerLevel);
        }
    }

    void SellTower()
    {
        sellTowerBtn.onClick.AddListener(selectedTowerPrefab.SellTower);
    }
}
