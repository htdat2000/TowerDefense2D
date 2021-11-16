using UnityEngine;

public class FireTower : MonoBehaviour
{
    [Header("Attributes")]
    public int damage;
    public float range;
    public float fireRate;
    

    [Header("Unity Setup")]
    private Transform target;
    public string enemyTag = "Enemy";

    public GameObject bulletPrefab;
    public Transform firePoint;
    private float fireCountdown = 0f;

    PlayerStats instance;
    BuildManager buildManager;

    void Awake()
    {
        instance = PlayerStats.playerStats;
        GetStats();
        buildManager = BuildManager.instance;
    }

    void Start()
    {
        
        InvokeRepeating("TargetLock", 0.2f, 0.5f);
    }

    void Update()
    {
        if(target == null)
        {
            return;
        }
        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void TargetLock()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        FireBullet bullet = bulletGO.GetComponent<FireBullet>();
        if(bullet != null)
        {
            bullet.seekTarget(target);
            bullet.GetDamageValue(damage);
        }
    }

    void GetStats()
    {
        damage = instance.fireTowerDamage;
        fireRate = instance.fireTowerRate;
        range = instance.fireTowerRange;
    }

    void OnMouseDown()
    {
        buildManager.SelectNode(this.gameObject.GetComponentInParent<Node>());
    }
}
