using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    public static BuildSystem instance;

    public TowerBlueprint selectingBluePrint;
    public bool hasBluePrint = false;
    void Awake()
    {
        selectingBluePrint = null;
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
