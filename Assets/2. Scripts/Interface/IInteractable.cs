using UnityEngine;

public interface IInteractable
{
    Collider GetCollider();
    float GetInteractRange();
    void Interact(Character character);
}
