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
    void OnMouseDown()
    {
        if(status == "Normal")
        {
            status = "Has Tower";
            GetComponent<SpriteRenderer>().color = Color.black;
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
        Instantiate(BuildSystem.instance.selectingBluePrint.prefab, transform.position, transform.rotation);
    }
    void SelectTower()
    {

    }
}
