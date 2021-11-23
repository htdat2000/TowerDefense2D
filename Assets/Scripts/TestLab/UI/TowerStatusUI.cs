using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerStatusUI : MonoBehaviour
{
    public Text towerName;
    public Text damageTxt;
    public Text rangeTxt;
    public Text fRateTxt;

    private GameObject selectedTower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
    }
}
