using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAi : MonoBehaviour
{
    public float speed = 1f;
    public GameObject nextKnot;
    public GameObject currentKnot;
    private AudioManager audioGO;

    private int x_endpoint;
    private int y_endpoint;
    void Awake()
    {
        audioGO = FindObjectOfType<AudioManager>();
        currentKnot = KnotsManager.KnotArray[8,8];
        UpdateNextKnot();

        x_endpoint = KnotsManager.x_endPoint;
        y_endpoint = KnotsManager.y_endPoint;
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
            if(Vector2.Distance(transform.position, KnotsManager.KnotArray[y_endpoint,x_endpoint].transform.position) <= 0.1f)
            {
                audioGO.Play("EndPoint");
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
        Debug.Log("next dir: " + xOfNextKnot + yOfNextKnot);
        nextKnot = KnotsManager.KnotArray[xOfNextKnot,yOfNextKnot];
    }
    public void SetCurrentKnot(GameObject setKnot)
    {
        nextKnot = setKnot;
    }
}
