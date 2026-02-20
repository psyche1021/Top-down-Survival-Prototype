using UnityEngine;

[CreateAssetMenu(menuName = "Character/MovementConfig")]
public class MovementConfig : ScriptableObject
{
    public float angularSpeed;
    public float acceleration;
    public float rotationSpeed;
    public float stoppingDistance;
    public bool autoBraking = false;
}   