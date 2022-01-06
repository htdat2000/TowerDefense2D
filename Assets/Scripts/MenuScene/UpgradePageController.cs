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
    private TowerCard towerCard;

    private AudioManager audioGO;
    
    void Start()
    {
        instance = PlayerStats.playerStats;
        audioGO = FindObjectOfType<AudioManager>();
    }
    public void OpenTowerUpgradeTab(TowerCard _towerCard)
    {
        audioGO.Play("Click");

        towerCard = _towerCard;
        towerDamage.text = _towerCard.defaultDmg.ToString();
        towerRange.text = _towerCard.defaultRange.ToString();
        towerFireRate.text = _towerCard.fireRate.ToString();
        specialEffect.text = _towerCard.specialEffect;
 
        if(btn.gameObject.activeSelf != true)
        {
            btn.gameObject.SetActive(true);
        }

        CheckTowerStatus(_towerCard.towerIndex);
        Debug.Log(_towerCard.towerIndex);
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

            instance.towerStatus[towerCard.towerIndex] = true;

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
        OpenTowerUpgradeTab(towerCard);
    }

    void Save()
    {
        instance.Save();
    }
}
