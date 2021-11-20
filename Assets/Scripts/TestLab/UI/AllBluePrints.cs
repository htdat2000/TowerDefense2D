using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBluePrints : MonoBehaviour
{
    public TowerBlueprint myBluePrintValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseThisBluePrint()
    {
        BuildSystem.instance.selectingBluePrint = myBluePrintValue;
    }
}
