using UnityEngine;

[CreateAssetMenu(fileName = "newTowerCard", menuName = "Cards/TowerCard")]
public class TowerCard : Card
{
    public int towerIndex;
    public float damage;
    public float range;
    public float fireRate;
    public int health;
    public string specialEffect; 
   
}
