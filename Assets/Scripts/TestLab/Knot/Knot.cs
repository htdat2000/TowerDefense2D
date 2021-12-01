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
    private TowerStatusUI sUI;

    private AudioManager audio;

    void Start()
    {
        float rand = Random.Range(0.0f, obstaclePercent);
        if (rand < 1 && (xindex != 0 && yindex != 0 && yindex != KnotsManager.noOfRow-1 && xindex != KnotsManager.noOfRow-1))
        {
            status = "Obstacle";
            GetComponent<NodeImage>().SetObstacle();
            knotValue = 90;
        }

        audio = FindObjectOfType<AudioManager>();
    }
    void OnMouseDown()
    {
        selectMe();
        audio.Play("Click");
    }

    public void selectMe()
    {
        KnotTouch();
        if(status == "Normal" && BuildSystem.instance.hasBluePrint == true && checkMoneyIHad())
        {
            status = "Has Tower";
            BuildTower();
            knotValue = 10;
            // SelectTower();
        }    
        else if (status == "Has Tower")
        {
            SelectTower();
        }
        else
        {
            SetToNonOutlineSelectedTower();
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
            myTower.GetComponent<Tower>().myStand = this;
            
            SceneStats.Money -= BuildSystem.instance.selectingBluePrint.cost;
            BuildSystem.instance.selectingBluePrint = null;
            BuildSystem.instance.hasBluePrint = false;
        }
    }
    public void SelectTower()
    {
        GetStatusUIComponent();

        Tower myTowerPrefab = myTower.GetComponent<Tower>();

        float myType = (float)myTowerPrefab.towerType;
        float myDmg = (float)myTowerPrefab.damage;
        float myRange = myTowerPrefab.range;
        float myFRate = myTowerPrefab.fireRate;
        float myUCost = (float)myTowerPrefab.costUpgrade;
        float mySValue = (float)myTowerPrefab.sellValue;

        float[] statsArray = { myType, myDmg, myRange, myFRate, myUCost, mySValue}; 

        sUI.UpdateStatusUI(statsArray);
        sUI.UpdateSelectedTower(myTower, myTowerPrefab);
    }
    bool checkMoneyIHad()
    {
        return SceneStats.Money >= BuildSystem.instance.selectingBluePrint.cost;
    }

    public void UpdateStatus()
    {
        status = "Normal";
        knotValue = 1;
    }

    public void KnotTouch()
    {
        GetStatusUIComponent();     

        float[] statsArray = { -1f, -1f, -1f, -1f}; 
        sUI.UpdateStatusUI(statsArray);
    }
    public void SetToNonOutlineSelectedTower()
    {
        GetStatusUIComponent();

        sUI.SetToNonOutlineSelected();
    }

    void GetStatusUIComponent()
    {
        if(sUI == null)
        {
            GameObject sUIGO =  GameObject.FindGameObjectWithTag("StatusUI");
            sUI = sUIGO.GetComponent<TowerStatusUI>();
        }
    }
}
