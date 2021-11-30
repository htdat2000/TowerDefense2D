using UnityEngine;
using UnityEngine.UI;

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
    Agent agent;
    void Start()
    {
        agent = GetComponent<Agent>();
        health = healthRatio * SceneStats.equationValue;
        startHealth = healthRatio * SceneStats.equationValue;
        SetMySpeed();
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        if(health <= 0)
        {
            Die();
        }
        if(special == "Invisible")
        {
            ChangeTag();
            Invoke("ChangeTag", 1f);
        }
    }
    public void Heal(float amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, startHealth);
        healthBar.fillAmount = health / startHealth;
    }
    void Die()
    {
        SceneStats.Money += value; 
        CheckRavenAround();
        Destroy(gameObject);
        WaveSpawner.enemyAlives--;
    }
    public void SetSlowValue(float percentage)
    {
        agent.Slow(percentage);
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
    void OnMouseDown()
    {
        selectMe();
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
}
