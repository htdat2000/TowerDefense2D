using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;

    public float speed = 3f;
    //public GameObject impactEffect;
    public GameObject hitEffect;
    public GameObject parent;

    public float damage;

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    public void seekTarget(Transform _target)
    {
        target = _target;
    }

    protected virtual void HitTarget()
    {
        Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject); 
    }

    public void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        // 

        if (e != null)
        {  
            if(e.health > 0)
                e.TakeDamage(damage);
        }
    }

    public void GetDamageValue(float _damage)
    {
        damage = _damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HitTarget();
        }
    }
}
