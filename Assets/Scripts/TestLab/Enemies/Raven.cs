using UnityEngine;

public class Raven : MonoBehaviour
{
    public float skillRange;
    public float skillValue;
    Enemy thisRaven;
    
    void Start()
    {
        thisRaven = GetComponent<Enemy>();
    }
    void FixedUpdate()
    {
        
        CheckEnemyDie();
        
    }

    void CheckEnemyDie()
    {
        Vector2 skillArea = new Vector2(transform.position.x, transform.position.y);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(skillArea, skillRange);
        foreach (Collider2D c in colliders)
        {
            if(c.CompareTag("Enemy"))
            {
                Enemy e = c.GetComponent<Enemy>();
                if(e.WasDead)
                {
                    thisRaven.Heal(skillValue);
                    Destroy(e.gameObject);
                }
            }
        }
    }
}
