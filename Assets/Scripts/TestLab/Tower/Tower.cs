using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Attributes")]
    public int towerType;
    public float damage;
    public float range;
    public float fireRate;
    

    [Header("Unity Setup")]
    private float defaultDmg;
    private Transform target;
    public string enemyTag = "Enemy";

    public GameObject bulletPrefab;
    public Transform firePoint;
    private float fireCountdown = 1f;

    public Animator anim;
    PlayerStats instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = PlayerStats.playerStats;
        GetStats();
    }
    void Start()
    {
        defaultDmg = damage;
        InvokeRepeating("TargetLock", 0.2f, 0.5f);
        GetCostUpgrade();
        GetSellValue();
        anim.Play("Idle", 0, 0f);
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
        anim.Play("Attack", 0, 0f);
        Invoke("SpawnBullet", 0.4f);
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

    public int level = 1;
    public int costUpgrade;
    private int sellValue;

    public void UpgradeTowerLevel()
    {
        if(level < 5)
        {
            if(SceneStats.Money >= costUpgrade)
            {
                SceneStats.Money -=costUpgrade;

                level++;
                //damage = 1000;
                TowerStatsEquation();

                GetCostUpgrade();
                GetSellValue();
            }
        }      
    }

    public void SellTower()
    {
        SceneStats.Money += sellValue;
        
        Knot parentKnot = GetComponentInParent<Knot>();

        parentKnot.UpdateStatus();
        Destroy(this.gameObject);
    }

    void GetCostUpgrade()
    {
        costUpgrade = (int)Mathf.Pow(3, level+1);
    }

    void GetSellValue()
    {
        sellValue = (int)Mathf.Round(Mathf.Pow(3, level)/2);
    }

    void TowerStatsEquation()
    {
        switch (towerType)
        {
            case 0:
                damage = Mathf.Round(Mathf.Pow(2, level - 1) + Mathf.Pow(4, level) + defaultDmg + Mathf.Pow(defaultDmg - 11,level - 1));
                range += 0.5f;
                break; 
            case 1:
                damage = Mathf.Round(Mathf.Pow(4, level - 1) + Mathf.Pow(4, level) + defaultDmg + Mathf.Pow(defaultDmg - 11,level - 1));
                range += 0.5f;
                break;
            default:
                Debug.Log("No Type");
                break;           
        }
    }
    public void BackToIdle()
    {
        anim.Play("Idle", 0, 0f);
    }
    void SpawnBullet()
    {
        float tan = (target.position.x - this.transform.position.x) / (this.transform.position.y - target.position.y);
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0f, 0f, Mathf.Atan(tan) * Mathf.Rad2Deg));
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.seekTarget(target);
            bullet.GetDamageValue(damage);
        }
    }
}
