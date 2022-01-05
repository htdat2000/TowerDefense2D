using UnityEngine;

public class Sneak : Enemy
{   
    public override void TakeDamage(float amount)
    {
        if(enemyTag == "Invisible")
        return;

        base.TakeDamage(amount);
        ChangeTag();
        Invoke("ChangeTag", 2f);
    }
    
    void ChangeTag()
    {
        if(enemyTag == "Enemy")
        {
            enemyTag = "Invisible";
            this.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,.5f);
        }
        else
        {
            enemyTag = "Enemy";
            this.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
        }
    }
}
