using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAi : MonoBehaviour
{
    //for test
    public GameObject nextKnot;
    public GameObject firstKnot;
    
    //KnotArray
    //Ý tưởng:
    /*
    Lúc được sinh ra AI sẽ tạo 1 mãng KnotPath lưu các Knot cần đi qua.
    KnotPath được cập nhật mỗi khi có thay đổi trên bản đồ (đặt trụ).
    */
    // Start is called before the first frame update
    void Awake()
    {
        UpdateKnotPath();
    }
    void Start()
    {
        Walk();
    }

    //Chạy mỗi khi map update
    public void UpdateMap(){
        Debug.Log("I known it");
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }
    void UpdateKnotPath()
    {

    }
    void Walk()
    {

    }
}
