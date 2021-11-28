using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostShower : MonoBehaviour
{
    public BuildSystem instance;
    private Text myText;
    // Start is called before the first frame update
    void Start()
    {
        instance = BuildSystem.instance;
        myText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (instance.selectingBluePrint != null)
        {
            myText.text = "Cost: " + instance.selectingBluePrint.cost.ToString();
        }
        else
        {
            myText.text = "";
        }
    }
}
