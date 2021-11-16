using UnityEngine;

public class PoisonBullet : MonoBehaviour
{
    private Transform target;

    public float speed = 3f;
    //public GameObject impactEffect;

    private int damage;
    private float poisonValue;

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
        //GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        //Destroy(effectIns, 2f);

        Damage(target);
        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
            e.Poisoned(poisonValue);
        }
    }

    public void GetDamageValue(int _damage, float _poisonValue)
    {
        damage = _damage;
        poisonValue = _poisonValue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HitTarget();
        }
    }
}
