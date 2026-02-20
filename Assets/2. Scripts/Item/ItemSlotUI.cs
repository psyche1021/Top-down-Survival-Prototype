using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlotUI : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image icon;
    [SerializeField] Text countText;

    Item currentItem;

    public void SetData(ItemStack stack)
    {
        currentItem = stack.item;
        icon.sprite = stack.item.icon;

        if (stack.count > 1)
        {
            countText.text = stack.count.ToString();
            countText.gameObject.SetActive(true);
        }
        else
        {
            countText.gameObject.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (currentItem != null)
        {
            ItemTooltipUI.Instance.Show(currentItem);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ItemTooltipUI.Instance.Hide();
    }
}
