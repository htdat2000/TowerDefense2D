using UnityEngine;

    [System.Serializable]
public class TowerBlueprint : MonoBehaviour
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradePrefab;
    public int upgradeCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }

    public void ChooseThisBluePrint()
    {
        BuildSystem.instance.selectingBluePrint = this;
        BuildSystem.instance.hasBluePrint = true;
    }
}
