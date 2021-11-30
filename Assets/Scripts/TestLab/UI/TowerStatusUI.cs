using UnityEngine;
using UnityEngine.UI;

public class TowerStatusUI : MonoBehaviour
{
    public Text upgradeTxt;
    public Text sellTxt;
    public Text towerName;
    public Text damageTxt;
    public Text rangeTxt;
    public Text fRateTxt;
    public Text rangeLbl;

    public Button upgradeTowerLevelBtn;
    public Button sellTowerBtn;

    public GameObject selectedTower;
    public Tower selectedTowerPrefab;
    
    public Material outline;
    public Material nonOutline;

    private string[] towerNameArray = {"Archer", "Fire", "Ice", "Poision", "Enemy"};

    public void UpdateStatusUI(float[] stats)
    {
        if(stats[0] != -1)
        {
            towerName.text = towerNameArray[(int)stats[0]];
            damageTxt.text = stats[1].ToString();
            rangeTxt.text = stats[2].ToString();
            fRateTxt.text = stats[3].ToString();
            upgradeTxt.text = stats[4].ToString();
            sellTxt.text = stats[5].ToString();
            return;
        }
        towerName.text = "";
        damageTxt.text = "";
        rangeTxt.text = "";
        fRateTxt.text = "";
        upgradeTxt.text = "";
        sellTxt.text = "";
    }

    public void UpdateSelectedTower(GameObject tower, Tower towerPrefab)
    {
        if(tower == null)
            selectedTowerPrefab = null;
        if(selectedTower != null)
        {
            if(tower.GetComponent<Tower>() && selectedTowerPrefab)
            {
                if(towerPrefab.myStand == selectedTowerPrefab.myStand)
                {
                    selectedTowerPrefab.myStand.KnotTouch();
                    Deselect();
                    return;
                }
            }
            else
            {
                if(tower.GetComponent<Tower>())
                {
                    SetToNonOutline(selectedTower);
                    if(selectedTowerPrefab)
                        selectedTowerPrefab.ToggleRangeSprite();
                }
            }     
        }
        if(tower != null)
        {
            if(selectedTower)
                SetToNonOutline(selectedTower);
            if(selectedTowerPrefab)
                selectedTowerPrefab.ToggleRangeSprite();
            selectedTower = tower;
            selectedTowerPrefab = towerPrefab;
            
            SetToOutline(selectedTower);

            if(tower.GetComponent<Tower>())
            {
                selectedTowerPrefab.ToggleRangeSprite();
                UpgradeAndSellTowerFunction();
                SetTowerStatus();
            }
            if(tower.GetComponent<Enemy>())
            {
                SetEnemyStatus();
            }
        }
    }

    void UpgradeAndSellTowerFunction()
    {   
        upgradeTowerLevelBtn.onClick.RemoveAllListeners();
        upgradeTowerLevelBtn.onClick.AddListener(selectedTowerPrefab.UpgradeTowerLevel);

        sellTowerBtn.onClick.RemoveAllListeners();
        sellTowerBtn.onClick.AddListener(selectedTowerPrefab.SellTower);
    }

    void SetToNonOutline(GameObject goj)
    {
        goj.GetComponent<SpriteRenderer>().material = nonOutline;
    }
    void SetToOutline(GameObject goj)
    {
        goj.GetComponent<SpriteRenderer>().material = outline;
    }
    public void SetToNonOutlineSelected()
    {
        if(selectedTower != null)
        {
            Deselect();
        }
    }

    void Deselect()
    {
        upgradeTowerLevelBtn.onClick.RemoveAllListeners();
        sellTowerBtn.onClick.RemoveAllListeners();
        selectedTower.GetComponent<SpriteRenderer>().material = nonOutline;
        
        if(selectedTowerPrefab)
            selectedTowerPrefab.ToggleRangeSprite();

        selectedTowerPrefab = null;
        selectedTower = null;
    }

    void SetTowerStatus()
    {
        rangeLbl.text = "Range: ";
    }
    void SetEnemyStatus()
    {
        rangeLbl.text = "Value: ";
    }
}
