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
    private int towerType;

    private AudioManager audioGO;
    
    void Start()
    {
        instance = PlayerStats.playerStats;
        audioGO = FindObjectOfType<AudioManager>();
    }
    public void OpenTowerUpgradeTab(int _towerType)
    {
        audioGO.Play("Click");

        towerDamage.text = instance.towerDamage[_towerType].ToString();
        towerRange.text = instance.towerRange[_towerType].ToString();
        towerFireRate.text = instance.towerRate[_towerType].ToString();
        specialEffect.text = null;
 
        towerType = _towerType;

        if(btn.gameObject.activeSelf != true)
        {
            btn.gameObject.SetActive(true);
        }

        CheckTowerStatus(_towerType);
        Debug.Log(_towerType);
    }

    void CheckTowerStatus(int _towerType) //check tower unlock status, if false => player can unlock 
    {
        if(instance.towerStatus[_towerType] == false)
        {
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(UnlockButton);
        }
        else
        {
            btn.onClick.RemoveAllListeners();
        }
    }

    public void UnlockButton()
    {
        if (instance.gem >= 4000)
        {      
            audioGO.Play("Click");

            instance.towerStatus[towerType] = true;

            instance.gem -= 4000; //unlock cost 
    
            Save();
            ResetUpgradeTab();
        }
        else
        {
            audioGO.Play("Error");
        }
    }

    void ResetUpgradeTab()
    {
        switch (towerType)
        {
            case 4:
                OpenTowerUpgradeTab(4);
                break;

            case 3:
                OpenTowerUpgradeTab(3);
                break;

            case 2:
                OpenTowerUpgradeTab(2);
                break;

            case 0:
                OpenTowerUpgradeTab(0);
                break;

            case 1:
                OpenTowerUpgradeTab(1);
                break;
            case 5:
                OpenTowerUpgradeTab(5);
                break;
        }
    }

    void Save()
    {
        instance.Save();
    }
}
