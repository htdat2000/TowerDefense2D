using System;
using System.Collections.Generic;
using UnityEngine;

public class KnotsManager : MonoBehaviour
{
    public static GameObject[,] KnotArray; //Mảng 2 chiều để mô phỏng lại map
    void Awake()
    {
        int noOfChild = transform.childCount;
        int noOfRow = (int)Math.Sqrt(noOfChild);
        KnotArray = new GameObject[noOfRow,noOfRow] ;
        for(int i = 0; i < noOfRow; i++)
        {
            for(int j = 0; j < noOfRow; j++)
            {
                KnotArray[i,j] = transform.GetChild(i).gameObject; //Push Knot to array for management
                SetKnotIndex(KnotArray[i,j], i, j);
            }        
        }
    }
    void SetKnotIndex(GameObject Knot, int x, int y)
    {
        Knot.GetComponent<Knot>().xindex = x;
        Knot.GetComponent<Knot>().yindex = y;
    }
}
