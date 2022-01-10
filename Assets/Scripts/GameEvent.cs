using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Game Event", fileName = "newGameEvent")]
public class GameEvent : ScriptableObject
{
    List<GameEventListener> listeners = new List<GameEventListener>();

    public void Invoke()
    {
        foreach (var listener in listeners)
        {
            listener.RaiseEvent();
        }
    }

    public void Register(GameEventListener listener)
    {
        if(!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void Deregister(GameEventListener listener)
    {
        if(listeners.Contains(listener))
        {
            listeners.Remove(listener);
        }
    }
}
