using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    public TowerBlueprint archerTowerPrefab;
    public TowerBlueprint fireTowerPrefab;
    public TowerBlueprint iceTowerPrefab;
    public TowerBlueprint lightningTowerPrefab;
    public TowerBlueprint poisonTowerPrefab;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectArcherTower()
    {
        buildManager.SelectTowerToBuild(archerTowerPrefab);
    }

    public void SelectFireTower()
    {
        buildManager.SelectTowerToBuild(fireTowerPrefab);
    }

    public void SelectIceTower()
    {
        buildManager.SelectTowerToBuild(fireTowerPrefab);
    }

    public void SelectLightningTower()
    {
        buildManager.SelectTowerToBuild(fireTowerPrefab);
    }

    public void SelectPoisonTower()
    {
        buildManager.SelectTowerToBuild(fireTowerPrefab);
    }

}
