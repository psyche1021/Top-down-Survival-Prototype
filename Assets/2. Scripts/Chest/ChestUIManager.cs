using UnityEngine;
using UnityEngine.UI;

public class ChestUIManager : MonoBehaviour
{
    public static ChestUIManager Instance;

    [SerializeField] GameObject chestUI;
    [SerializeField] Transform itemSlotParent; // UI 슬롯 부모
    [SerializeField] GameObject itemSlotPrefab; // UI 슬롯 프리팹

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && chestUI.activeSelf)
        {
            CloseChestUI();
        }
    }

    public void OpenChestUI(Chest chest)
    {
        chestUI.SetActive(true);

        // 기존 슬롯 초기화
        foreach (Transform child in itemSlotParent)
        {
            Destroy(child.gameObject);
        }

        // ChestData의 아이템 표시
        foreach (var stack in chest.currentItems)
        {
            var slot = Instantiate(itemSlotPrefab, itemSlotParent);
            slot.GetComponentInChildren<Image>().sprite = stack.item.icon;

            // 클릭하면 인벤토리로 추가
            slot.GetComponent<Button>().onClick.AddListener(() =>
            {
                PlayerInventory.Instance.AddItem(stack.item);
                chest.currentItems.Remove(stack);
                Destroy(slot);
            });
        }
    }

    public void CloseChestUI()
    {
        chestUI.SetActive(false);
    }
}
