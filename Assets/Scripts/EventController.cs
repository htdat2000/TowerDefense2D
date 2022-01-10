using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventController : MonoBehaviour
{
    public static EventController instance;

    public event Action<int> OnEnemyDieEvent;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than 1 EventController in scene");
            return;
        }
        instance = this;
    }

    public void TriggerDieEvent(int value)
    {
        OnEnemyDieEvent?.Invoke(value);
    }
}
