using System;
using System.Collections.Generic;
using UnityEngine;

public class KnotsManager : MonoBehaviour
{
    public static GameObject[,] KnotArray; //Mảng 2 chiều để mô phỏng lại map
    private int noOfChild;
    public static int noOfRow;
    void Awake()
    {
        noOfChild = transform.childCount;
        noOfRow = (int)Math.Sqrt(noOfChild);
        KnotArray = new GameObject[noOfRow,noOfRow];
        int childCounter = 0;
        for(int i = 0; i < noOfRow; i++)
        {
            for(int j = 0; j < noOfRow; j++)
            {
                KnotArray[i,j] = transform.GetChild(childCounter).gameObject; //Push Knot to array for management
                SetKnotIndex(KnotArray[i,j], i, j);
                childCounter ++;
            }        
        }
        CalculateMapRoute();
        
    }
    void Start()
    {
        {
            InvokeRepeating("UpdateMap", 0.2f, 3f);
        }
    }
    void SetKnotIndex(GameObject Knot, int x, int y)
    {
        Knot.GetComponent<Knot>().xindex = x;
        Knot.GetComponent<Knot>().yindex = y;
    }
    void InitKnot(GameObject Knot)
    {
        Knot.GetComponent<Knot>().distanceValue = 999;
        Knot.GetComponent<Knot>().nextXindex = -1;
        Knot.GetComponent<Knot>().nextYindex = -1;
        Knot.GetComponent<Knot>().isAccept = false;
    }
    void CalculateMapRoute()
    {
        for(int i = 0; i < noOfRow; i++)
        {
            for(int j = 0; j < noOfRow; j++)
            {
                InitKnot(KnotArray[i,j]);
            }        
        }
        
        //Tạo nút gốc, do đặt nút gốc là [0,0]
        KnotArray[0,0].GetComponent<Knot>().distanceValue = KnotArray[0,0].GetComponent<Knot>().knotValue;

        GameObject currentKnot = KnotArray[0,0];
        for(int i = 0; i < noOfChild - 1; i++)
            {
                currentKnot = WhoIsNext(); //chọn ra knot có distanceValue thấp nhất nhưng chưa có isAccept
                LookAround(currentKnot);
            }
    }
    GameObject WhoIsNext()
    {
        GameObject result = null;
        int minDistance = 9999;
        for(int i = 0; i < noOfRow; i++)
        {
            for(int j = 0; j < noOfRow; j++)
            {
                Knot checkingKnot = KnotArray[i,j].GetComponent<Knot>();
                if(checkingKnot.isAccept == false && checkingKnot.distanceValue <= minDistance)
                {
                    float deci = UnityEngine.Random.Range(-1.0f, 1.2f);
                    if(deci < 0 || result == null)
                    {
                        result = KnotArray[i,j];
                        minDistance = checkingKnot.distanceValue;
                    }
                }
            }    
        }
        if (result != null)
        {
            result.GetComponent<Knot>().isAccept = true;
        }
        return result;
    }
    void LookAround(GameObject KnotGO)
    {
        Knot thisKnot = KnotGO.GetComponent<Knot>();
        int x = thisKnot.xindex;
        int y = thisKnot.yindex;
        if(x != noOfRow-1) //Tồn tại 1 nút bên phải nó
        {
            Knot rightKnot = KnotArray[x+1, y].GetComponent<Knot>();
            KnotCheck(thisKnot,rightKnot);
        }
        if(x != 0) //Tồn tại 1 nút bên trái nó
        {
            Knot leftKnot = KnotArray[x-1, y].GetComponent<Knot>();
            KnotCheck(thisKnot,leftKnot);
        }
        if(y != noOfRow-1) //Tồn tại 1 nút bên dưới nó
        {
            Knot bottomKnot = KnotArray[x, y+1].GetComponent<Knot>();
            KnotCheck(thisKnot,bottomKnot);
        }
        if(y != 0) //Tồn tại 1 nút bên trên nó
        {
            Knot topKnot = KnotArray[x, y-1].GetComponent<Knot>();
            KnotCheck(thisKnot,topKnot);
        }
    }
    void KnotCheck(Knot thisKnot, Knot checkedKnot)
    {
        if(checkedKnot.isAccept != true)
        {
            if(checkedKnot.distanceValue > thisKnot.distanceValue + checkedKnot.knotValue)
            {
                checkedKnot.distanceValue = thisKnot.distanceValue + checkedKnot.knotValue;
                checkedKnot.nextXindex = thisKnot.xindex;
                checkedKnot.nextYindex = thisKnot.yindex;
            }
        }
    }
    public void UpdateMap(){
        CalculateMapRoute();
    }

}
