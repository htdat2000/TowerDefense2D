using UnityEngine.Events;
using UnityEngine;

public class GameEventListener : MonoBehaviour
{
    public GameEvent gameEvent;
    public UnityEvent unityEvent;
    // Start is called before the first frame update
    void Awake()
    {
        gameEvent.Register(this);
    }
    void OnDestroy()
    {
        gameEvent.Deregister(this);
    }
    public void RaiseEvent()
    {
        unityEvent?.Invoke();
    }

    
}
