using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public void Interact (Character character)
    {
        Open();
    }

    void Open()
    {
        Debug.Log("상자 열림");
    }
}
