using UnityEngine.AI;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public Transform endPoint;
    private NavMeshAgent agent;

    private Enemy e;

    private bool isSlow = false;
    private float slowCountdown = 0;
    
    void Start()
    {
        e = GetComponent<Enemy>();

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        agent.speed = e.startSpeed;

        agent.SetDestination(endPoint.transform.position);
    }

    void Update()
    {
        if(isSlow)
        {
            if(slowCountdown <= 0)
            {
                isSlow = false;
                agent.speed = e.startSpeed;
            }
            slowCountdown -= Time.deltaTime;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("EndPoint"))
        {
            EndPath();
        }
    }

    void EndPath()
    {
        SceneStats.Lives--;
        Destroy(gameObject);
    }

    public void Slow (float percentage)
    {
        agent.speed = e.startSpeed * (1 - percentage);

        isSlow = true;
        slowCountdown = 3f;
    }
}
