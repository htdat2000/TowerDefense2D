using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireB : Bullet
{
    private float explosionRadius = 1f;

    protected override void HitTarget()
    {
        base.HitTarget();
        Explode(target);   
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
