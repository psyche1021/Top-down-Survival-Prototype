using UnityEngine;

[CreateAssetMenu(menuName = "Item/Chest Data")]
public class ChestData : ScriptableObject
{
    public Item[] possibleItems;
    public int minItems = 1;
    public int maxItems = 8;
}
