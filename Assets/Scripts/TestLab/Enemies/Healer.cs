using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{
    // Start is called before the first frame update
    public float healValue ;
    public float healRadius;
    void Start()
    {
        InvokeRepeating("Heal", 1f, 6f);
    }

    void Heal()
    {
        Vector2 healArea = new Vector2(transform.position.x, transform.position.y);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(healArea, healRadius);

        foreach (Collider2D collider in colliders)
        {
            if(collider.CompareTag("Enemy"))
            {
                collider.GetComponent<Enemy>().Heal(healValue);
            }
        }
    }
}
