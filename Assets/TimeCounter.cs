using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject waveSystem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(WaveSystem.thisWaveEnemiesCount > 0)
            GetComponent<Text>().text = "Raiding";
        else
            GetComponent<Text>().text = waveSystem.GetComponent<WaveSystem>().countdown.ToString();
    }
}
