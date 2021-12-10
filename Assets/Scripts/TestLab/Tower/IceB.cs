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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HitTarget();
        }
    }
    void HitTarget()
    {
        Instantiate(hitEffect, transform.position, Quaternion.identity);
        Slow();
        Damage(target);    
        Destroy(gameObject);
    }
    void Slow()
    {
        target.GetComponent<Enemy>().SetSlowValue(slowPercentage, slowTime);
    }
}
