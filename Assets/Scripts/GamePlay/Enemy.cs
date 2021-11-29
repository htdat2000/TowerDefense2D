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
    void Die()
    {
        SceneStats.Money += value; 
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
}
