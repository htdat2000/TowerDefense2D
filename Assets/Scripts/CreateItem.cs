using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour
{
    public GameEvent gameEvent; //Scriptable object data
    public GameObject gameItem;
    public void CreateItemPre()
    {
        GameObject item = Instantiate(gameItem);
        item.GetComponent<ItemCarrier>().gameEvent = gameEvent;
        item.GetComponent<ItemCarrier>().CallMethod();
    }
}
