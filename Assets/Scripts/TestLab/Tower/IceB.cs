using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceB : Bullet
{
    public float slowPercentage;
    public float slowTime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HitTarget();
        }
    }
    void HitTarget()
    {
        Debug.Log("Hit");
        Instantiate(hitEffect, transform.position, Quaternion.identity); 
        Slow();
        Damage(target);    
        Destroy(gameObject);
    }
    void Slow()
    {
        Debug.Log("Yah");
        target.GetComponent<Enemy>().SetSlowValue(slowPercentage, slowTime);
    }
}
