using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject ui;

    public Text damageText;
    public Text rangeText;
    public Text rateText;

    public Button upgradeButton;

    void Update()
    {
        /*if (target != null)
        {
            SetTextInfo();
        }*/
    }

    public void SetTarget(Node _target)
    {
        target = _target;
        ui.SetActive(true);

        SetTextInfo();

        /*if(!target.isUpgraded)
        {
            Debug.Log("Display Cost");
            upgradeButton.interactable = true;
        }
        else
        {
            Debug.Log("Display DONE");
            upgradeButton.interactable = false;
        }*/
    }

    public void Hide()
    {    
        target = null;      
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTower();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTower();
        BuildManager.instance.DeselectNode();
    }

    void SetTextInfo()
    {
        damageText.text = target.tower.GetComponent<FireTower>().damage.ToString();
        rangeText.text = target.tower.GetComponent<FireTower>().range.ToString();
        rateText.text = target.tower.GetComponent<FireTower>().fireRate.ToString();
    }
}
