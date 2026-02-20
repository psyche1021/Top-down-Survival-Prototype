using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(CharacterMovement))]
public class Character : MonoBehaviour
{
    public PlayerInput PlayerInput { get; private set; }
    public CharacterMovement Movement { get; private set; }

    IInteractable pendingInteract;
    float interactRange;
    Collider targetCollider;

    void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();
        Movement = GetComponent<CharacterMovement>();
    }

    void Update()
    {
        if (pendingInteract == null || targetCollider == null) return;

        Vector3 closest = targetCollider.ClosestPoint(transform.position);

        float sqrDist = (transform.position - closest).sqrMagnitude;

        if (sqrDist <= interactRange * interactRange)
        {
            pendingInteract.Interact(this);
            pendingInteract = null;
            targetCollider = null;
            Movement.Stop();
        }
    }

    public void MoveAndInteract(IInteractable interactable)
    {
        pendingInteract = interactable;
        interactRange = interactable.GetInteractRange();
        targetCollider = interactable.GetCollider();

        Vector3 closest = targetCollider.ClosestPoint(transform.position);
        Movement.MoveTo(closest);
    }
}
