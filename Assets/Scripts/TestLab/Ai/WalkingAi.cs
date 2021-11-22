using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAi : MonoBehaviour
{
    //for test
    public float speed = 1f;
    public GameObject nextKnot;
    public GameObject currentKnot;
    
    //KnotArray
    //Ý tưởng:
    /*
    Lúc được sinh ra AI sẽ tạo 1 mãng KnotPath lưu các Knot cần đi qua.
    KnotPath được cập nhật mỗi khi có thay đổi trên bản đồ (đặt trụ).
    */
    // Start is called before the first frame update
    void Awake()
    {
        speed = GetComponent<Enemy>().startSpeed;
        currentKnot = KnotsManager.KnotArray[8,8];
        UpdateNextKnot();
    }
    void Update()
    {
        Walk();
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }
    void Walk()
    {
        Vector2 dir = nextKnot.transform.position - transform.position;        
        transform.Translate(dir.normalized * speed/10 * Time.deltaTime, Space.World);
        if(Vector2.Distance(transform.position, nextKnot.transform.position) <= 0.1f)
        {
            if(Vector2.Distance(transform.position, KnotsManager.KnotArray[0,0].transform.position) <= 0.1f)
            {
                Destroy(gameObject);
                return;
            }
            currentKnot = nextKnot;
            UpdateNextKnot();
        }
    }
    void UpdateNextKnot()
    {
        int xOfNextKnot = currentKnot.GetComponent<Knot>().nextXindex;
        int yOfNextKnot = currentKnot.GetComponent<Knot>().nextYindex;
        nextKnot = KnotsManager.KnotArray[xOfNextKnot,yOfNextKnot];
    }
    public void SetCurrentKnot(GameObject setKnot)
    {
        nextKnot = setKnot;
    }
}
