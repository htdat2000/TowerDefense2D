using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireB : Bullet
{
    private float explosionRadius = 1f;

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
        Explode(target);   
        Destroy(gameObject);
    }

    void Explode(Transform target)
    {
        Vector2 explodeArea = new Vector2(transform.position.x, transform.position.y);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explodeArea, explosionRadius);

        foreach (Collider2D collider in colliders)
        {
            if(collider.CompareTag("Enemy") && target == collider.transform)
            {
                if(collider.transform.GetComponent<Enemy>().health > 0)
                    Damage(collider.transform);
            }
        }
    }
}
