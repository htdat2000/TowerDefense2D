using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public bool CanBuild { get {return towerToBuild != null;} }
    public bool HasMoney { get { return SceneStats.Money >= towerToBuild.cost; } }
    private Node selectedNode;
    public NodeUI nodeUI; 
    private TowerBlueprint towerToBuild;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene");
            return;
        }
        instance = this;
    }

    
    public void SelectTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower;
        selectedNode = null;

        nodeUI.Hide();
    }


    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        towerToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        if (selectedNode == null)
            return;

        selectedNode = null;
        nodeUI.Hide();
    }

    public TowerBlueprint GetTowerToBuild()
    {
        return towerToBuild;
    }
}
