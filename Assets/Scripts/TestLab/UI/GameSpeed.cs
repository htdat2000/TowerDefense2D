using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    private int timeScale = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setGameSpeed()
    {
        Debug.Log("click");
        if(timeScale == 0)
            Time.timeScale = 1f;
        else if (timeScale == 1)
            Time.timeScale = 2f;
        else
            Time.timeScale = 3f;

        timeScale = (timeScale + 1) % 3;
    }
}
