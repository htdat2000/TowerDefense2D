using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnotsManager : MonoBehaviour
{
    public static GameObject[] KnotArray;
    void Awake()
    {
        int noOfChild = transform.childCount;
        KnotArray = new GameObject[noOfChild];
        Debug.Log(noOfChild);
        for(int i = 0; i < noOfChild; i++)
        {
            KnotArray[i] = transform.GetChild(i).gameObject;
        }
        Debug.Log(KnotArray[0].GetComponent<Knot>().status);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
