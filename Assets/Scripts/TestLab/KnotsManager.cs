using System;
using System.Collections.Generic;
using UnityEngine;

public class KnotsManager : MonoBehaviour
{
    public static GameObject[,] KnotArray; //Mảng 2 chiều để mô phỏng lại map
    private int noOfChild;
    private int noOfRow;
    void Awake()
    {
        noOfChild = transform.childCount;
        noOfRow = (int)Math.Sqrt(noOfChild);
        KnotArray = new GameObject[noOfRow,noOfRow] ;
        int childCounter = 0;
        for(int i = 0; i < noOfRow; i++)
        {
            for(int j = 0; j < noOfRow; j++)
            {
                KnotArray[i,j] = transform.GetChild(childCounter).gameObject; //Push Knot to array for management
                SetKnotIndex(KnotArray[i,j], i, j);
                // Debug.Log("Knot(" +i + "," + j + ") is " + KnotArray[i,j]);
                childCounter ++;
            }        
        }
        CalculateMapRoute();
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
        //Knot has: (x, y), nextKnot, distanceValue, knotValue, isAccept
        //Ở đây tui dùng Knot [0,0] để làm endpoint
        //Ý tưởng là tìm đường đi ngắn nhất từ endpoint tới các điểm khác trên map
        //Sau đó dựa vào đó để dẫn đường cho Ai
        //Do có nhiều đoạn giá trị độ dài như nhau nên sẽ dùng random để quyết định đâu là 
            //con đường thích hợp
        for(int i = 0; i < noOfRow; i++)
        {
            for(int j = 0; j < noOfRow; j++)
            {
                InitKnot(KnotArray[i,j]);
                // Debug.Log("Knot [ " + i + j + " ], Accept: " + KnotArray[i,j].GetComponent<Knot>().isAccept + ", Distance: " + KnotArray[i,j].GetComponent<Knot>().distanceValue);
            }        
        }
        
        //Tạo nút gốc, do đặt nút gốc là [0,0]
        KnotArray[0,0].GetComponent<Knot>().distanceValue = KnotArray[0,0].GetComponent<Knot>().knotValue;
        // Debug.Log("First Knot distanceV is: " + KnotArray[0,0].GetComponent<Knot>().distanceValue);
        KnotArray[0,0].GetComponent<Knot>().isAccept = true;

        GameObject currentKnot = KnotArray[0,0];

        for(int i = 0; i < noOfChild - 1; i++)
        {
            currentKnot = WhoIsNext(); //chọn ra knot có distanceValue thấp nhất nhưng chưa có isAccept
            // Debug.Log(currentKnot);
            LookAround(currentKnot);
        }
        //in ra để xem kết quả
        for(int i = 0; i < noOfRow; i++)
        {
            for(int j = 0; j < noOfRow; j++)
            {
                // Debug.Log("Knot (" + i + "," + j + ") is " + KnotArray[i,j] + ", Distance: " + KnotArray[i,j].GetComponent<Knot>().distanceValue);
            }        
        }
        //Xét 4 nút xung quanh
            //Lưu distanceValue mới nếu nhỏ hơn distanceV cũ
            //Lưu Nút trước đó (nextX/Yindex) nếu nhỏ hơn distanceV cũ
        //Chọn nút có giá trị quảng đường nhỏ nhất làm nút tiếp theo xét duyệt -> Cập nhật lại currentKnot
            //NútĐó.isAccept = true
        
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
                if(checkingKnot.isAccept == false && checkingKnot.distanceValue < minDistance)
                {
                    result = KnotArray[i,j];
                    minDistance = checkingKnot.distanceValue;
                }
            }        
        }
        if (result != null)
        {
            result.GetComponent<Knot>().isAccept = true;
        }
        Debug.Log("Choose Knot: " + result);
        return result;
    }
    void LookAround(GameObject KnotGO)
    {
        Knot thisKnot = KnotGO.GetComponent<Knot>();
        int x = thisKnot.xindex;
        int y = thisKnot.yindex;
        if(x != noOfRow-1) //Tồn tại 1 nút bên phải nó
        {
            //xét nút bên phải nó
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
            if(checkedKnot.distanceValue > thisKnot.knotValue + checkedKnot.knotValue)
            {
                checkedKnot.distanceValue = thisKnot.knotValue + checkedKnot.knotValue;
                checkedKnot.nextXindex = thisKnot.xindex;
                checkedKnot.nextYindex = thisKnot.yindex;
            }
        }
    }
}
