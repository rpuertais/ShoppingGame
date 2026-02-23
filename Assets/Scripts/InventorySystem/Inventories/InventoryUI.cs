using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory Inventory;
    public ItemSlotUI SlotPrefab;

    [Header("Who owns this inventory UI?")]
    public InventoryOwner Owner = InventoryOwner.Player;

    [Header("Selection")]
    public SelectionManager selectionManager;

    private List<GameObject> itemSlotList = new List<GameObject>();

    private void OnEnable()
    {
        if (Inventory != null)
            Inventory.OnInventoryChange += UpdateInventoryUI;
    }

    private void OnDisable()
    {
        if (Inventory != null)
            Inventory.OnInventoryChange -= UpdateInventoryUI;
    }

    private void Start()
    {
        UpdateInventoryUI();
    }

    public void SelectItem(ItemData item)
    {
        if (selectionManager == null) return;
        selectionManager.Select(item, Owner);
    }

    private void UpdateInventoryUI()
    {
        if (Inventory == null || SlotPrefab == null) return;

        ClearInventoryUI();

        for (int i = 0; i < Inventory.Length; i++)
        {
            itemSlotList.Add(AddSlot(Inventory.GetSlot(i)));
        }
    }

    private void ClearInventoryUI()
    {
        for (int i = 0; i < itemSlotList.Count; i++)
        {
            if (itemSlotList[i] != null) Destroy(itemSlotList[i]);
        }
        itemSlotList.Clear();
    }

    private GameObject AddSlot(ItemSlot itemSlot)
    {
        var element = Instantiate(SlotPrefab, Vector3.zero, Quaternion.identity, transform);
        element.Initialize(itemSlot, this);
        return element.gameObject;
    }
}