using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 3f;
    //public GameObject impactEffect;

    private int damage;

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

    void HitTarget()
    {
        Damage(target);    
        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    public void GetDamageValue(int _damage)
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
