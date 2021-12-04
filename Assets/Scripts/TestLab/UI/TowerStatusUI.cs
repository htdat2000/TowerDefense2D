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

    private string[] towerNameArray = {"Archer", "Fire", "Ice", "Miner", "Enemy"};

    private AudioManager audioGO;

    void Start()
    {
        audioGO = FindObjectOfType<AudioManager>();
        AddButtonErrorSound();
    }

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
        //Hủy cái cũ
        bool selectThisAgain = false; //kiểm tra có deselect hông
        if(selectedTower != null) //nếu trước đó có 1 đối tượng được chọn
        {
            SetToNonOutline(selectedTower);
            if(isTower(selectedTower))
                selectedTowerPrefab.ToggleRangeSprite();

            if(isTower(tower) && isTower(selectedTower)) //nếu con vừa chọn là trụ, và trc đó cũng là trụ
            {
                if(towerPrefab.myStand == selectedTowerPrefab.myStand) //nếu con vừa chọn là con chọn lúc trước
                {
                    selectThisAgain = true;
                    if(isTower(selectedTower))
                        selectedTowerPrefab.ToggleRangeSprite();
                    selectedTowerPrefab.myStand.KnotTouch();
                    Deselect();
                    return;
                }
            }    
        }
        //Chọn cái mới
        if(tower)
        {
            selectedTower = tower;
            selectedTowerPrefab = towerPrefab;
            
            SetToOutline(selectedTower);

            if(isTower(tower))
            {
                if(!selectThisAgain)
                    selectedTowerPrefab.ToggleRangeSprite();
                UpgradeAndSellTowerFunction();
                SetTowerStatus();
            }
            else
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

        AddButtonErrorSound();

        selectedTower.GetComponent<SpriteRenderer>().material = nonOutline;

        if(selectedTowerPrefab)
            selectedTowerPrefab.ToggleRangeSprite();

        selectedTowerPrefab = null;
        selectedTower = null;
    }
    void SetTowerStatus()
    {
        //rangeLbl.text = "Range: ";
    }
    void SetEnemyStatus()
    {
        //rangeLbl.text = "Value: ";
    }
    bool isTower(GameObject goj)
    {
        return goj.GetComponent<Tower>();
    }
    bool isEnemy(GameObject goj)
    {
        return goj.GetComponent<Enemy>();
    }

    void AddButtonErrorSound()
    {
        upgradeTowerLevelBtn.onClick.AddListener(PlayErrorSound);
        sellTowerBtn.onClick.AddListener(PlayErrorSound);
    }

    void PlayErrorSound()
    {
        audioGO.Play("Error");
    }
}
