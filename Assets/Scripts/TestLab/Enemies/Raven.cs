using UnityEngine;

public class Raven : Enemy
{
    public float skillRange;
    public float skillValue;
    
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
                    Heal(skillValue);
                    Destroy(e.gameObject);
                }
            }
        }
    }
}
