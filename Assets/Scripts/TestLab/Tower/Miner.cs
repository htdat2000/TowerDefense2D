using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : Tower
{
    // Start is called before the first frame update
    void Start()
    {
        defaultDmg = damage;
        
        //InvokeRepeating("TargetLock", 0.2f, 0.2f);
        
        GetCostUpgrade();
        GetSellValue();
        
        //anim.Play("Idle", 0, 0f);

        DrawRange();
        ToggleRangeSprite();

        audioGO = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fireCountdown <= 0f)
        {
            Mine();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }
    void Mine()
    {
        //SceneStats.Money += (int)damage;
        SceneStats.Money += (int)Mathf.Pow(2, level - 1); 
        Debug.Log(Mathf.Pow(2, level - 1));
    }
}
