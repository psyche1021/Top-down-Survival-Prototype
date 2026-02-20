using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;

    public List<ItemStack> items = new List<ItemStack>();

    void Awake() => Instance = this;

    public void AddItem(Item item, int count = 1)
    {
        if (item == null || count <= 0) return;

        int remaining = count;

        // 기존 스택 먼저 채우기
        foreach (var stack in items)
        {
            if (stack.item.itemName != item.itemName) continue;

            int spaceLeft = item.maxStack - stack.count;
            if (spaceLeft<=0) continue;

            int addAmount = Mathf.Min(spaceLeft, remaining);
            stack.count += addAmount;
            remaining -= addAmount;

            if (remaining <= 0) 
                break;
        }

        // 남은 수량으로 새 스택 생성
        while(remaining > 0)
        {
            int addAmount = Mathf.Min(item.maxStack, remaining);
            items.Add(new ItemStack(item, addAmount));
            remaining -= addAmount;
        }

        // 인벤토리를 연 상태에서 아이템 획득할때 반영되도록 UI 갱신
        InventoryUIManager.Instance?.RefreshUI();
    }
}
