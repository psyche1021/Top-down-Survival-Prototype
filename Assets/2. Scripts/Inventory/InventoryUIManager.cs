using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUIManager : MonoBehaviour
{
    public static InventoryUIManager Instance;

    [SerializeField] GameObject inventoryUI; 
    [SerializeField] Transform itemSlotParent; // 그리드 레이아웃이 붙은 오브젝트
    [SerializeField] GameObject itemSlotPrefab;

    void Awake() => Instance = this;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inventoryUI.activeSelf)
                CloseInventory();
            else
                OpenInventory();
        }
    }

    public void OpenInventory()
    {
        inventoryUI.SetActive(true);
        RefreshUI();
    }

    public void CloseInventory()
    {
        inventoryUI.SetActive(false);

        if (ItemTooltipUI.Instance != null)
        {
            ItemTooltipUI.Instance.Hide();
        }
    }

    public void RefreshUI()
    {
        // 기존 슬롯 삭제
        foreach (Transform child in itemSlotParent)
            Destroy(child.gameObject);

        // PlayerInventory 데이터 가져오기
        foreach (var stack in PlayerInventory.Instance.items)
        {
            GameObject slotObj = Instantiate(itemSlotPrefab, itemSlotParent);
            ItemSlotUI slotUI = slotObj.GetComponent<ItemSlotUI>();
            slotUI.SetData(stack);

            // 아이템 클릭시 이벤트
            Button button = slotObj.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(() =>
                {
                    // 클릭로직
                });
            }
        }
    }
}
