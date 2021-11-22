using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Attributes")]
    public int towerType;
    public int damage;
    public float range;
    public float fireRate;
    

    [Header("Unity Setup")]
    private Transform target;
    public string enemyTag = "Enemy";

    public GameObject bulletPrefab;
    public Transform firePoint;
    private float fireCountdown = 1f;

    PlayerStats instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = PlayerStats.playerStats;
        GetStats();
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

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.seekTarget(target);
            bullet.GetDamageValue(damage);
        }
    }
    void GetStats()
    {
        damage = instance.towerDamage[towerType];
        fireRate = instance.towerRate[towerType];
        range = instance.towerRange[towerType];
    }
    void OnMouseDown()
    {
        //Call Knot selectNode();
    }
}
