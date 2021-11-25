using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Knot : MonoBehaviour
{
    // Start is called before the first frame update
    public string aiTag = "Ai";
    public string status = "Normal";
    //Các biến phục vụ cho mục đích tìm đường
    public int xindex;
    public int yindex;
    public int nextXindex = -1;
    public int nextYindex = -1;
    public int knotValue = 1;
    public int distanceValue = 999;
    public bool isAccept = false;

    public float obstaclePercent = 50.0f;

    private GameObject myTower;
    void Start()
    {
        float rand = Random.Range(0.0f, obstaclePercent);
        if (rand < 1 && (xindex != 0 && yindex != 0 && yindex != KnotsManager.noOfRow-1 && xindex != KnotsManager.noOfRow-1))
        {
            status = "Obstacle";
            GetComponent<NodeImage>().SetObstacle();
            knotValue = 90;
        }
    }
    void OnMouseDown()
    {
        if(status == "Normal" && BuildSystem.instance.hasBluePrint == true && checkMoneyIHad())
        {
            status = "Has Tower";
            BuildTower();
            knotValue = 10;
        }    
        else if (status == "Has Tower")
        {
            SelectTower();
        }    
        SendSignalToAi("UpdateMap");
    }
    void SendSignalToAi(string signal)
    {
        GameObject knotsManager = GameObject.FindGameObjectWithTag("KnotsManager");
        knotsManager.SendMessage(signal);
    }
    void BuildTower()
    {
        if(BuildSystem.instance.hasBluePrint == true)
        {
            myTower = Instantiate(BuildSystem.instance.selectingBluePrint.prefab, transform.position, transform.rotation);
            myTower.transform.SetParent(this.gameObject.transform);
            
            SceneStats.Money -= BuildSystem.instance.selectingBluePrint.cost;
            BuildSystem.instance.selectingBluePrint = null;
            BuildSystem.instance.hasBluePrint = false;
        }
    }
    void SelectTower()
    {
        GameObject sUIGO =  GameObject.FindGameObjectWithTag("StatusUI");
        TowerStatusUI sUI = sUIGO.GetComponent<TowerStatusUI>();

        Tower myTowerPrefab = myTower.GetComponent<Tower>();

        float myType = (float)myTowerPrefab.towerType;
        float myDmg = (float)myTowerPrefab.damage;
        float myRange = myTowerPrefab.range;
        float myFRate = myTowerPrefab.fireRate;

        float[] statsArray = { myType, myDmg, myRange, myFRate}; 
        //sUI.SendMessage("UpdateStatusUI", statsArray);
        //sUI.SendMessage("UpdateSelectedTower", myTower);

        sUI.UpdateStatusUI(statsArray);
        sUI.UpdateSelectedTower(myTower, myTowerPrefab);
    }
    bool checkMoneyIHad()
    {
        return SceneStats.Money >= BuildSystem.instance.selectingBluePrint.cost;
    }

    public void UpdateKnotStatus()
    {
        status = "Normal";
        knotValue = 1;
    }
}
