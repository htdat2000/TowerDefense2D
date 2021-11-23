using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeImage : MonoBehaviour
{
    
    public SpriteRenderer spriteRenderer = null;
    public Sprite[] newSprite;
    public Sprite[] newObstacle;

    void SetSprite()
    {
        int num = (int)Random.Range(0f, (float)newSprite.Length);
        spriteRenderer.sprite = newSprite[num]; 
    }

    public void SetObstacle()
    {
        int num = (int)Random.Range(0f, (float)newObstacle.Length);
        spriteRenderer.sprite = newObstacle[num]; 
    }

    void Start()
    {
        SetSprite();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }
}
