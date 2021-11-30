﻿using UnityEngine;
using UnityEngine.UI;

public class TowerStatusUI : MonoBehaviour
{
    public Text upgradeTxt;
    public Text sellTxt;
    public Text towerName;
    public Text damageTxt;
    public Text rangeTxt;
    public Text fRateTxt;

    public Button upgradeTowerLevelBtn;
    public Button sellTowerBtn;

    public GameObject selectedTower;
    public Tower selectedTowerPrefab;
    
    public Material outline;
    public Material nonOutline;

    private string[] towerNameArray = {"Archer", "Fire", "Ice", "Poision", "Enemy"};

    private string selectedType = "None";

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
        selectedType = "Tower";
        if(selectedTower != null)
        {
            selectedType = "None";
            SetToNonOutline(selectedTower);
        }

        if(selectedTower != null)
        {
            selectedTower = tower;
            selectedTowerPrefab = towerPrefab;
            SetToOutline(selectedTower);

            UpgradeTowerLevelFunction();
            SellTowerFunction();
        }
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
        if(selectedTower != null)
        {
            upgradeTowerLevelBtn.onClick.RemoveAllListeners();
            sellTowerBtn.onClick.RemoveAllListeners();
            selectedTower.GetComponent<SpriteRenderer>().material = nonOutline;
        }
    }
}
