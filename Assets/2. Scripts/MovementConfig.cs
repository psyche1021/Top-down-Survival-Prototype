using UnityEngine;

[CreateAssetMenu(menuName = "Character/MovementConfig")]
public class MovementConfig : ScriptableObject
{
    public float angularSpeed = 1200f;
    public float acceleration = 40f;
    public float rotationSpeed = 15f;
    public float stoppingDistance = 0.05f;
    public bool autoBraking = false;
}