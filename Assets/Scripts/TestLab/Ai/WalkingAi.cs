using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAi : MonoBehaviour
{
    public float speed = 1f;
    public GameObject nextKnot;
    public GameObject currentKnot;
    void Awake()
    {
        currentKnot = KnotsManager.KnotArray[8,8];
        UpdateNextKnot();
    }
    void Update()
    {
        Walk();
    }
    void Walk()
    {
        Vector2 dir = nextKnot.transform.position - transform.position;        
        transform.Translate(dir.normalized * speed/10 * Time.deltaTime, Space.World);
        if(Vector2.Distance(transform.position, nextKnot.transform.position) <= 0.1f)
        {
            if(Vector2.Distance(transform.position, KnotsManager.KnotArray[0,0].transform.position) <= 0.1f)
            {
                SceneStats.Lives -= 1;
                GetComponent<Enemy>().Die();
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
