using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;

    public List<ItemStack> items = new List<ItemStack>();

    void Awake() => Instance = this;

    public void AddItem(Item item, int count = 1)
    {
        if (item == null) return;

        // 동일 아이템 스택 찾기
        var stack = items.Find(s => s.item == item);

        if (stack != null)
        {
            stack.count += count; // maxStack 제한 무시하고 합치기
        }
        else
        {
            items.Add(new ItemStack(item, count));
        }
        
        // 인벤토리를 연 상태에서 아이템 획득할때 반영되도록 UI 갱신
        InventoryUIManager.Instance?.RefreshUI();
    }
}
