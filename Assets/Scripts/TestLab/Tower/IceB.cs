using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceB : Bullet
{
    int parentLevel;
    public float slowPercentage;
    public float slowTime;

    void Start()
    {
        parentLevel = parent.GetComponent<Tower>().level;
        slowPercentage = 0.1f + 0.05f * parentLevel; 
    }

    protected override void HitTarget()
    {
        base.HitTarget();
        Slow();
        Damage(target);    
    }
    void Slow()
    {
        target.GetComponent<Enemy>().SetSlowValue(slowPercentage, slowTime);
    }
}
