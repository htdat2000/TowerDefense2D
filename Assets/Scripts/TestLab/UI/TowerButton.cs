using UnityEngine;

public class TowerButton : MonoBehaviour
{   
    public TowerPanel towerPanel;

    void Awake()
    {
        towerPanel.AddTowerButton(this);
    }
}
