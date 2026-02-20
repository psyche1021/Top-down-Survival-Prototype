using UnityEngine;

public enum ItemType
{
    Consumable,
    Equipment,
    Material
}

public enum ItemRarity
{
    Mythic,     // 빨간템, 초월
    Legendary,  // 노란템, 전설
    Epic,       // 보라템, 영웅
    Rare,       // 파란템, 희귀
    Uncommon,   // 초록템, 고급
    Common      // 흰템, 일반
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
