using UnityEngine;
using UnityEngine.UI;

public class ItemTooltipUI : MonoBehaviour
{
    public static ItemTooltipUI Instance;

    [SerializeField] GameObject tooltipPanel;
    [SerializeField] Text nameText;
    [SerializeField] Text descriptionText;
    [SerializeField] Text itemTypeText;

    bool isFollowing = false;
    Vector3 tooltipOffset = new Vector3(150f, -90f, 0f);

    void Awake()
    {
        Instance = this;
        Hide();
    }

    void Update()
    {
        if (isFollowing)
        {
            tooltipPanel.transform.position = Input.mousePosition + tooltipOffset;
        }
    }

    public void Show(Item item)
    {
        tooltipPanel.SetActive(true);
        isFollowing = true;

        nameText.text = item.itemName;
        descriptionText.text = item.description;

        SetNameColor(item.rarity);
        SetItemTypeText(item.itemType);
    }

    public void Hide()
    {
        tooltipPanel.SetActive(false);
        isFollowing = false;
    }

    void SetNameColor(ItemRarity rarity)
    {
        Color rarityColor = Color.white;

        switch (rarity)
        {
            case ItemRarity.Mythic:
                rarityColor = Color.red;
                break;

            case ItemRarity.Legendary:
                rarityColor = Color.yellow;
                break;

            case ItemRarity.Epic:
                rarityColor = new Color(0.6f, 0f, 1f);
                break;

            case ItemRarity.Rare:
                rarityColor = Color.blue;
                break;

            case ItemRarity.Uncommon:
                rarityColor = Color.green;
                break;

            case ItemRarity.Common:
                rarityColor = Color.white;
                break;
        }
        nameText.color = rarityColor;
    }

    void SetItemTypeText(ItemType type)
    {
        switch (type)
        {
            case ItemType.Consumable:
                itemTypeText.text = "소모품";
                break;

            case ItemType.Equipment:
                itemTypeText.text = "장비";
                break;

            case ItemType.Material:
                itemTypeText.text = "재료";
                break;
        }
        itemTypeText.color = new Color(0.7f, 0.7f, 0.75f);
    }
}
