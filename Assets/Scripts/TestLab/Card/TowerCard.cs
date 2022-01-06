using UnityEngine;

[CreateAssetMenu(fileName = "newTowerCard", menuName = "Cards/TowerCard")]
public class TowerCard : Card
{
    public int towerIndex;
    public int defaultDmg;
    public float defaultRange;
    public float fireRate;
    public int health;
    public string specialEffect;
    
    [HideInInspector]
    public float damage;
    [HideInInspector]
    public float range;

    public void UpdateTowerCardData(int level)
    {
        switch (towerIndex)
        {
            case 0:
                damage = Mathf.Round(Mathf.Pow(5, level - 1) + Mathf.Pow(4, level) + defaultDmg + Mathf.Pow(defaultDmg - 11,level - 1));
                range += 0.5f;
                break; 
            case 1:
 
                damage = Mathf.Round(Mathf.Pow(3, level - 1) + Mathf.Pow(4, level) + defaultDmg + Mathf.Pow(defaultDmg - 19,level - 1));
                range += 0.2f;
                break;
            case 2:
                damage = Mathf.Round(Mathf.Pow(1, level - 1) + Mathf.Pow(3, level) + defaultDmg + Mathf.Pow(defaultDmg - 7,level - 1));
                range += 0.1f; 
                break;
            default:
                Debug.Log("No Stats Equation");
                break;           
        }
    }
}
