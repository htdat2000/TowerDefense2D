using UnityEngine;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour
{
    [Header("Attributes")]
    public int towerType;
    public float damage;
    public float range;
    public float fireRate;
    private float health;
    
    public int level = 1;
    public float costRatio;
    public int costUpgrade;
    public int sellValue;
    public TowerCard towerCard;

    [Header("Unity Setup")]
    private Transform target;
    public string enemyTag = "Enemy";

    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject towerRangePrefab;
    public GameObject towerRangeGO;
    
    public float fireCountdown = 0f;
    public Animator anim;
    
    public Knot myStand;


    private string[] shootSFX = {"ArrowShoot","FireShoot", "IceShoot"}; //change 3 to ice effect
    public AudioManager audioGO;

    void Awake()
    {
        GetStats();
    }
    void Start()
    {
   
        InvokeRepeating("TargetLock", 0.2f, 0.2f);
        
        GetCostUpgrade();
        GetSellValue();
        
        anim.Play("Idle", 0, 0f);

        DrawRange();
        ToggleRangeSprite();

        audioGO = FindObjectOfType<AudioManager>();
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

    #region default tower function
    public void TargetLock()
    {   
        target = null;
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

    public void Shoot()
    {
        anim.Play("Attack", 0, 0f);
        Invoke("SpawnBullet", 0.2f);
        audioGO.Play(shootSFX[towerType]);
    }

    public void SpawnBullet()
    {
        if(target)
        {
            float tan = (target.position.x - this.transform.position.x) / (this.transform.position.y - target.position.y);
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0f, 0f, Mathf.Atan(tan) * Mathf.Rad2Deg));
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            bullet.parent = gameObject;
            if(bullet != null)
            {
                bullet.seekTarget(target);
                bullet.GetDamageValue(damage);
            }
        }
    }

    public void BackToIdle()
    {
        anim.Play("Idle", 0, 0f);
    }

    public void DrawRange()
    {
        if (towerRangeGO == null)
        {
            towerRangeGO = (GameObject)Instantiate(towerRangePrefab, transform.position, Quaternion.identity);
            towerRangeGO.transform.SetParent(gameObject.transform);
        }  
        towerRangeGO.transform.localScale = new Vector3 (range * 2, range * 2, 0); // diameter = radius multiply 2 
    }
    #endregion

    #region Interactable Function (Click event)
    public void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
			return;
        myStand.selectMe();
        audioGO.Play("Click");
    }

    public void UpgradeTowerLevel()
    {
        if(level < 5)
        {
            if(SceneStats.Money >= costUpgrade)
            {   
                audioGO.Play("Click");
                SceneStats.Money -=costUpgrade;

                level++;
                
                TowerStatsEquation();
                DrawRange();

                GetCostUpgrade();
                GetSellValue();

                myStand.SelectTower();            
            }
            else
            {
                audioGO.Play("Error");
            }
        }   
        else
        {
            audioGO.Play("Error");
        }   
    }

    public void SellTower()
    {
        audioGO.Play("Click");
        SceneStats.Money += sellValue;
    
        myStand.SetObstacleStatus();
        Destroy(this.gameObject);
    }

    public void ToggleRangeSprite()
    {
        towerRangeGO.SetActive(!towerRangeGO.activeSelf);
    }

    public void OnDrawGizmosSelected()     //To check the range
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    #endregion

    #region Tower Stats and Equation (Use to get data)
    public void GetStats()
    {
        damage = towerCard.defaultDmg;
        fireRate = towerCard.fireRate;
        range = towerCard.defaultRange;
        health = towerCard.health;
    }

    public void GetCostUpgrade()
    {
        costUpgrade = (int)Mathf.Round(costRatio * Mathf.Pow(3, level+1));
    }

    public void GetSellValue()
    {
        sellValue += (int)Mathf.Round(costRatio * Mathf.Pow(3, level)/2);
    }

    void TowerStatsEquation()
    {
        towerCard.UpdateTowerCardData(level);
        damage = towerCard.damage;
        range = towerCard.range;
    }
    #endregion
    
    #region Tower collision enemy function
    private void DestroyTower()  //destroy tower 
    {
        myStand.SetObstacleStatus();
        Destroy(gameObject);  
    }

    public void TowerTakeDamage(int _damage)
    {
        health -= _damage;
        if(health <= 0)
        {
            DestroyTower();
        }
    }
    #endregion
}
