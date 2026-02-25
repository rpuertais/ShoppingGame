/*using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory Inventory;
    public ItemSlotUI SlotPrefab;

    [Header("Grid")]
    public int Capacity = 20;

    [Header("Owner")]
    public InventoryOwner Owner = InventoryOwner.Player;

    [Header("Selection")]
    public SelectionManager selectionManager;

    private List<ItemSlotUI> slotList = new List<ItemSlotUI>();
    private ItemSlotUI selectedSlot;

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

    public void SelectSlot(ItemSlotUI slotUI, ItemData item)
    {
        ClearSelectionVisual();

        selectedSlot = slotUI;
        selectedSlot.SetSelected(true);

        if (selectionManager != null)
            selectionManager.Select(item, Owner);
    }

    private void ClearSelectionVisual()
    {
        for (int i = 0; i < slotList.Count; i++)
            slotList[i].SetSelected(false);
    }

    private void UpdateInventoryUI()
    {
        if (Inventory == null || SlotPrefab == null) return;

        ClearUI();

        for (int i = 0; i < Capacity; i++)
        {
            var slotUI = Instantiate(SlotPrefab, Vector3.zero, Quaternion.identity, transform);
            slotList.Add(slotUI);

            if (i < Inventory.Length)
                slotUI.Initialize(Inventory.GetSlot(i), this);
            else
                slotUI.InitializeEmpty(this);
        }
    }

    private void ClearUI()
    {
        for (int i = 0; i < slotList.Count; i++)
        {
            if (slotList[i] != null)
                Destroy(slotList[i].gameObject);
        }
        slotList.Clear();
        selectedSlot = null;
    }
}*/

using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory Inventory;
    public ItemSlotUI SlotPrefab;

    public int Capacity = 20;

    public InventoryOwner Owner = InventoryOwner.Player;
    public SelectionManager selectionManager;

    private List<ItemSlotUI> slotList = new List<ItemSlotUI>();
    private ItemSlotUI selectedSlot;

    private void OnEnable()
    {
        if (Inventory != null)
        {
            Inventory.OnInventoryChange += UpdateInventoryUI;
        }
    }

    private void OnDisable()
    {
        if (Inventory != null)
        {
            Inventory.OnInventoryChange -= UpdateInventoryUI;
        }
    }

    private void Start()
    {
        UpdateInventoryUI();
    }

    public void SelectSlot(ItemSlotUI slotUI, ItemData item)
    {
        ClearSelectionVisual();

        selectedSlot = slotUI;
        if (selectedSlot != null) selectedSlot.SetSelected(true);

        if (selectionManager != null)
        {
            selectionManager.Select(item, Owner, this, true);
        }
    }

    public void ClearSelectionVisual()
    {
        for (int i = 0; i < slotList.Count; i++)
        {
            slotList[i].SetSelected(false);
        }
        selectedSlot = null;
    }

    private void UpdateInventoryUI()
    {
        if (Inventory == null) return;
        if (SlotPrefab == null) return;

        ClearUI();

        for (int i = 0; i < Capacity; i++)
        {
            ItemSlotUI slotUI = Instantiate(SlotPrefab, Vector3.zero, Quaternion.identity, transform);
            slotList.Add(slotUI);

            if (i < Inventory.Length)
            {
                slotUI.Initialize(Inventory.GetSlot(i), this);
            }
            else
            {
                slotUI.InitializeEmpty(this);
            }
        }

        
        ReapplySelectionIfNeeded();
    }

    private void ReapplySelectionIfNeeded()
    {
        if (selectionManager == null) return;
        if (!selectionManager.HasSelection()) return;
        if (selectionManager.SelectedFrom != Owner) return;

        ItemData sel = selectionManager.SelectedItem;
        if (sel == null) return;

        for (int i = 0; i < slotList.Count; i++)
        {
            ItemData slotItem = slotList[i].GetItem();
            if (slotItem == sel)
            {
                selectedSlot = slotList[i];
                selectedSlot.SetSelected(true);
                break;
            }
        }
    }

    private void ClearUI()
    {
        for (int i = 0; i < slotList.Count; i++)
        {
            if (slotList[i] != null)
            {
                Destroy(slotList[i].gameObject);
            }
        }
        slotList.Clear();
        selectedSlot = null;
    }
}