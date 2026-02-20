using UnityEngine;

public enum ItemType
{
    Consumable, // ¼Ò¸ð
    Equipment, // Àåºñ
    Material // Àç·á
}

public enum ItemRarity
{
    Mythic,     // ÃÊ¿ù (»¡°­)
    Legendary,  // Àü¼³ (³ë¶û)
    Epic,       // ¿µ¿õ (º¸¶ó)
    Rare,       // Èñ±Í (ÆÄ¶û)
    Uncommon,   // °í±Þ (ÃÊ·Ï)
    Common      // ÀÏ¹Ý (Èò»ö)
}

[CreateAssetMenu(menuName = "Item/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite icon;
    public int maxStack = 1;

    public ItemType itemType;
    public ItemRarity rarity;

    /*
    public int attackPower;
    public int defense;
    */
}
