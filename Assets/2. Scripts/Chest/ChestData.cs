using UnityEngine;

[CreateAssetMenu(menuName = "Item/Chest Data")]
public class ChestData : ScriptableObject
{
    public Item[] possibleItems;
    public int minChestItemSlot = 1;
    public int maxChestItemSlot = 8;
}
