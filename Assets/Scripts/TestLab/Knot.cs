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
            status = "Can't walk throught";
            GetComponent<SpriteRenderer>().color = Color.black;
            knotValue = 10;
        }    
        else
        {
            status = "Normal";
            GetComponent<SpriteRenderer>().color = Color.white;
            knotValue = 1;
        }    
        SendSignalToAi("UpdateMap");
    }
    void SendSignalToAi(string signal)
    {
        GameObject[] allEnemy = GameObject.FindGameObjectsWithTag(aiTag);
        GameObject knotsManager = GameObject.FindGameObjectWithTag("KnotsManager");
        knotsManager.SendMessage(signal);
        for(int i = 0; i < allEnemy.Length; i++)
        {
            allEnemy[i].SendMessage(signal);
        }
    }
}
