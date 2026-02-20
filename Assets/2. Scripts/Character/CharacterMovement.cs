using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] MovementConfig config;
    float rotationSpeed;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
        agent.angularSpeed = config.angularSpeed;
        agent.acceleration = config.acceleration;
        agent.stoppingDistance = config.stoppingDistance;
        agent.autoBraking = config.autoBraking;
        rotationSpeed = config.rotationSpeed;
    }

    void Update()
    {
        Vector3 dir = agent.velocity;
        dir.y = 0;

        if (dir.sqrMagnitude > 0.1f)
        {
            Quaternion targetRot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
        }
    }

    public void MoveTo(Vector3 pos)
    {
        if (agent.isOnNavMesh)
        {
            agent.SetDestination(pos);
        }
    }

    public void Stop()
    {
        agent.ResetPath();
        agent.velocity = Vector3.zero;
    }
}
