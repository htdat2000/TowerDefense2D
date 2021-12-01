using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public float liveTime = 1f;
    void Start()
    {
        Invoke("Leave", liveTime);
    }

    void Leave()
    {
        Destroy(gameObject);
    }
}
