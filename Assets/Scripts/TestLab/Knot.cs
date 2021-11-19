using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Knot : MonoBehaviour
{
    // Start is called before the first frame update
    public string aiTag = "Ai";
    public string status = "Normal";
    public int xindex;
    public int yindex;
    void OnMouseDown()
    {
        if(status == "Normal")
        {
            status = "Can't walk throught";
            GetComponent<SpriteRenderer>().color = Color.black;
        }    
        else
        {
            status = "Normal";
            GetComponent<SpriteRenderer>().color = Color.white;
        }    
        SendSignalToAi("UpdateMap");
    }
    void SendSignalToAi(string signal)
    {
        GameObject[] allEnemy = GameObject.FindGameObjectsWithTag(aiTag);
        for(int i = 0; i < allEnemy.Length; i++)
        {
            allEnemy[i].SendMessage(signal);
        }
    }
}
