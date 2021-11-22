using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerStatusUI : MonoBehaviour
{
    public Text damageTxt;
    public Text rangeTxt;
    public Text fRateTxt;

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
        damageTxt.text = stats[0].ToString();
        rangeTxt.text = stats[1].ToString();
        fRateTxt.text = stats[2].ToString();
    }
}
