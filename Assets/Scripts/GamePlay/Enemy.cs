using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    public string enemyTag = "Enemy";
    public string invisibleTag = "Invisible";

    public string special = "";
    public float healthRatio;
    [HideInInspector]
    public float health;
    private float startHealth;
    public int value;
    public float startSpeed;
    public Image healthBar;
    
    private int damage = 100;
    private float attackSpeed = 1;
    private float attackCooldown = 0;
    
    private GameObject targetGO;
    private Tower target;

    public GameObject deadEffect;
    private AudioManager audioGO;

    private float slowTimeCount;
    private bool wasDead = false;

    void Start()
    {
        health = healthRatio * SceneStats.equationValue;
        startHealth = healthRatio * SceneStats.equationValue;
        SetMySpeed();
        audioGO = FindObjectOfType<AudioManager>();
    }
    void Update()
    {
        if(slowTimeCount > 0)
        {
            slowTimeCount -= Time.deltaTime;
            if(slowTimeCount <= 0)
            {
                SetMySpeed();
            }
        }
    }
    public void TakeDamage(float amount)
    {
        Debug.Log("Get hit");
        audioGO.Play("Hit");
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        if(health <= 0)
        {
            if(!wasDead)
            {
                Die();
                audioGO.Play("Die");
                return;
            }
        }
        if(special == "Invisible")
        {
            ChangeTag();
            Invoke("ChangeTag", 2f);
            return;
        }
    }
    public void Heal(float amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, startHealth);
        healthBar.fillAmount = health / startHealth;
    }
    public void Die()
    {
        wasDead = true;
        Instantiate(deadEffect, transform.position, transform.rotation);
        SceneStats.Money += value; 
        CheckRavenAround();
        WaveSystem.thisWaveEnemiesCount--;
        Destroy(gameObject);
    }
    public void SetSlowValue(float percentage, float slowTime)
    {
        //slowdown
        gameObject.GetComponent<WalkingAi>().speed = startSpeed - startSpeed * percentage;
        slowTimeCount = slowTime;
    }
    public void Poisoned(float percentage)
    {
        health -= health * percentage;
    }
    void SetMySpeed()
    {
        gameObject.GetComponent<WalkingAi>().speed = startSpeed;
    }
    void ChangeTag()
    {
        if(transform.gameObject.tag == enemyTag)
        {
            transform.gameObject.tag = invisibleTag;
            this.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,.5f);
        }
        else
        {
            transform.gameObject.tag = enemyTag;
            this.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(collision.GetComponent<Bullet>().damage);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Tower"))
        {
            if(targetGO != collision.gameObject)
            {
                targetGO = collision.gameObject;
                target = collision.GetComponent<Tower>();
            }
            else
            AttackTower();
            Debug.Log(attackCooldown);
        }
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
			return;
        selectMe();
        audioGO.Play("Click");
    }
    void CheckRavenAround()
    {
        GameObject[] ravens = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject raven in ravens)
        {
            if(raven.GetComponent<Raven>() != null)
            {
                float distanceToRaven = Vector3.Distance(transform.position, raven.transform.position);
                if(distanceToRaven < raven.GetComponent<Raven>().skillRange)
                {
                    raven.GetComponent<Enemy>().Heal(raven.GetComponent<Raven>().skillValue);
                }
            }
        }
    }
    void selectMe()
    {
        GameObject sUIGO =  GameObject.FindGameObjectWithTag("StatusUI");
        TowerStatusUI sUI = sUIGO.GetComponent<TowerStatusUI>();

        float myType = 4f;
        float myDmg = startHealth;
        float myRange = value;
        float myFRate = startSpeed;
        float myUCost = 0f;
        float mySValue = 0f;

        float[] statsArray = { myType, myDmg, myRange, myFRate, myUCost, mySValue}; 

        sUI.UpdateStatusUI(statsArray);
        sUI.UpdateSelectedTower(gameObject, null);
    }

    void AttackTower()
    {
        if(target != null)
        {
            if(attackCooldown <= 0)
            {
                target.TowerTakeDamage(damage);
                attackCooldown = 1/attackSpeed;
            }
            else
                attackCooldown -= Time.deltaTime;
        }
    }
}
