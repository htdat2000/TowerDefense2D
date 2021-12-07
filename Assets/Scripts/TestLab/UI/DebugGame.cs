using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGame : MonoBehaviour
{
    public GameObject waveSystemGO;
    private WaveSystem waveSystem;
    // Start is called before the first frame update
    void Start()
    {
        waveSystem = waveSystemGO.GetComponent<WaveSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void To30()
    {
        waveSystem.waveCount = 29;
        waveSystem.add40sec();
        SceneStats.Money += 1485;
    }
}
