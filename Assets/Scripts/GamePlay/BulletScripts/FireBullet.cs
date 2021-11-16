using UnityEngine;

public class FireBullet : MonoBehaviour
{
    private Transform target;

    public float speed = 2f;
    //public GameObject impactEffect;

    private float explosionRadius = 1f;

    private int damage;

    void Update()
    {
        if(target == null)
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
        //GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        //Destroy(effectIns, 2f);

        Explode();
        
        /*if(explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }*/
        Destroy(gameObject);
    }

    void Explode()
    {
        Vector2 explodeArea = new Vector2(transform.position.x, transform.position.y);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explodeArea, explosionRadius);

        foreach (Collider2D collider in colliders)
        {
            if(collider.CompareTag("Enemy"))
            {
                Damage(collider.transform);
            }
        }
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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HitTarget();
        }
    }
}
