using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(CharacterMovement))]
public class Character : MonoBehaviour
{
    public PlayerInput PlayerInput { get; private set; }
    public CharacterMovement Movement { get; private set; }

    void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();
        Movement = GetComponent<CharacterMovement>();
    }
}
