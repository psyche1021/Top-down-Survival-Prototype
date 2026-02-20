using UnityEngine;
using System.Collections.Generic;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] ChestData data;
    public List<ItemStack> currentItems = new List<ItemStack>();
    Collider chestCollider;

    bool isOpen = false;
    Transform player;
    Vector3 openPlayerPosition;
    float positionTolerance = 0.1f;

    public ChestData GetData() => data;
    public Collider GetCollider() => chestCollider;
    public float GetInteractRange() => 0.6f;
    public void Interact(Character character)
    {
        Open();
    }

    void Awake()
    {
        chestCollider = GetComponent<Collider>();

        player = GameObject.FindWithTag("Player").transform;
        GenerateRandomItems();
    }

    void Update()
    {
        if (isOpen && player != null)
        {
            if ((player.position - openPlayerPosition).sqrMagnitude > positionTolerance * positionTolerance)
            {
                Close();
            }
        }
    }

    void Open()
    {
        openPlayerPosition = player.position;
        ChestUIManager.Instance.OpenChestUI(this);
        isOpen = true;
    }

    void Close()
    {
        ChestUIManager.Instance.CloseChestUI();
        isOpen = false;
    }

    void GenerateRandomItems()
    {
        currentItems.Clear();
        int count = Random.Range(data.minItems, data.maxItems + 1);
        
        for (int i = 0; i < count;i++)
        {
            Item randomIten = data.possibleItems[Random.Range(0, data.possibleItems.Length)];
            currentItems.Add(new ItemStack(randomIten, 1));
        }
    }
}
