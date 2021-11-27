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
    
    public Material outline;
    public Material nonOutline;

    public void UpdateStatusUI(float[] stats)
    {
        if(stats[0] != -1)
        {
            towerName.text = stats[0].ToString();
            damageTxt.text = stats[1].ToString();
            rangeTxt.text = stats[2].ToString();
            fRateTxt.text = stats[3].ToString();
            return;
        }
        towerName.text = "";
        damageTxt.text = "";
        rangeTxt.text = "";
        fRateTxt.text = "";
    }

    public void UpdateSelectedTower(GameObject tower, Tower towerPrefab)
    {
        if(selectedTower != null)
        {
            SetToNonOutline(selectedTower);
        }
        selectedTower = tower;
        selectedTowerPrefab = towerPrefab;

        SetToOutline(selectedTower);

        UpgradeTowerLevelFunction();
        SellTowerFunction();
    }

    void UpgradeTowerLevelFunction()
    {   
        upgradeTowerLevelBtn.onClick.RemoveAllListeners();
        upgradeTowerLevelBtn.onClick.AddListener(selectedTowerPrefab.UpgradeTowerLevel);
    }

    void SellTowerFunction()
    {
        sellTowerBtn.onClick.RemoveAllListeners();
        sellTowerBtn.onClick.AddListener(selectedTowerPrefab.SellTower);
    }

    void SetToNonOutline(GameObject tower)
    {
        tower.GetComponent<SpriteRenderer>().material = nonOutline;
    }
    void SetToOutline(GameObject tower)
    {
        tower.GetComponent<SpriteRenderer>().material = outline;
    }
    public void SetToNonOutlineSelected()
    {
        upgradeTowerLevelBtn.onClick.RemoveAllListeners();
        sellTowerBtn.onClick.RemoveAllListeners();
        selectedTower.GetComponent<SpriteRenderer>().material = nonOutline;
    }
}
