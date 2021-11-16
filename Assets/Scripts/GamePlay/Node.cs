using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;

    private Color startColor;

    private SpriteRenderer rend;

    [HideInInspector]
    public GameObject tower;
    [HideInInspector]
    public TowerBlueprint towerBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.color;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;      

        if(tower != null)
            return;
        

        if (!buildManager.CanBuild)
            return;

        BuildTower(buildManager.GetTowerToBuild());
    }

    void OnMouseEnter()
    {
        if(!buildManager.CanBuild)
            return;
        if(buildManager.HasMoney)
        {
            rend.color = hoverColor;
        }
        else
        {
            rend.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit()
    {
        rend.color = startColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position;
    }

    void BuildTower(TowerBlueprint blueprint)
    {
        if (SceneStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build");
            return;
        }

        SceneStats.Money -= blueprint.cost;

        towerBlueprint = blueprint;

        GameObject _tower = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        tower = _tower;

        SetChild();
    }

    public void UpgradeTower()
    {
        if (SceneStats.Money < towerBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to build");
            return;
        }

        SceneStats.Money -= towerBlueprint.upgradeCost;

        Destroy(tower);

        GameObject _tower = (GameObject)Instantiate(towerBlueprint.upgradePrefab, GetBuildPosition(), Quaternion.identity);
        tower = _tower;

        isUpgraded = true;
    }

    public void SellTower()
    {
        SceneStats.Money += towerBlueprint.GetSellAmount();
        Destroy(tower);
        towerBlueprint = null;
    }

    void SetChild()
    {
        tower.transform.SetParent(this.gameObject.transform);

        NavMeshSurface2d surface2D = GameObject.FindGameObjectWithTag("NavSurface").GetComponent<NavMeshSurface2d>();
        surface2D.BuildNavMesh(); 
    }
}
