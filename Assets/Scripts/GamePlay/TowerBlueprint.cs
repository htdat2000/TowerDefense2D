using UnityEngine;
   
public class TowerBlueprint : MonoBehaviour
{
    public GameObject prefab;
    public int cost;

    private AudioManager audioGO;

    void Start()
    {
        audioGO = FindObjectOfType<AudioManager>();
    }
 
    public void ChooseThisBluePrint()
    {
        BuildSystem.instance.selectingBluePrint = this;
        BuildSystem.instance.hasBluePrint = true;
        audioGO.Play("Click");
    }
}
