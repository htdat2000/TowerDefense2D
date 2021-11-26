using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float healthRatio;
    [HideInInspector]
    public float health;
    
    public int value = 100;

    public float startSpeed = 10f;
 
    public Image healthBar;

    Agent agent;

    void Start()
    {
        agent = GetComponent<Agent>();
        
        health = healthRatio * SceneStats.equationValue;

        Debug.Log(SceneStats.equationValue);
    }
    
    public void TakeDamage(float amount)
    {
        Debug.Log(health);
        health -= amount;
        Debug.Log(amount);
        Debug.Log(health);
        //healthBar.fillAmount = health / startHealth;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SceneStats.Money += value; 
        Destroy(gameObject);
        WaveSpawner.enemyAlives--;
    }

    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Tower"))
    //     {
    //         Destroy(collision.gameObject);
    //     }
    // }

    public void SetSlowValue(float percentage)
    {
        agent.Slow(percentage);
    }

    public void Poisoned(float percentage)
    {
        health -= health * percentage;
    }
}
