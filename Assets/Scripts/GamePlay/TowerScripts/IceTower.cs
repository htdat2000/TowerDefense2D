﻿using UnityEngine;

public class IceTower : MonoBehaviour
{
    [Header("Attributes")]
    public int damage;
    public float range;
    public float fireRate;
    public float slowValue;


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
        if (target == null)
        {
            return;
        }
        if (fireCountdown <= 0f)
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

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
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
        IceBullet bullet = bulletGO.GetComponent<IceBullet>();
        if (bullet != null)
        {
            bullet.seekTarget(target);
            bullet.GetDamageValue(damage, slowValue);
        }
    }

    void GetStats()
    {
        damage = instance.iceTowerDamage;
        fireRate = instance.iceTowerRate;
        range = instance.iceTowerRange;
        slowValue = instance.slowValue;
    }

    void OnMouseDown()
    {
        buildManager.SelectNode(this.gameObject.GetComponentInParent<Node>());
    }
}
