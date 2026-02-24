using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Items/Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField] 
    private List<ItemSlot> Slots = new List<ItemSlot>();

    public int Length => Slots.Count;
    public Action OnInventoryChange;

    public void Clear()
    {
        Slots.Clear();
        OnInventoryChange?.Invoke();
    }

    public void AddItem(ItemData item)
    {
        AddItem(item, 1);
    }

    public void AddItem(ItemData item, int amount)
    {
        if (item == null || amount <= 0) return;

        var slot = GetSlot(item);

        if (slot != null && item.IsStackable)
        {
            for (int i = 0; i < amount; i++) slot.AddOne();
        }
        else
        {
            slot = new ItemSlot(item);
            Slots.Add(slot);

            
            for (int i = 1; i < amount; i++) slot.AddOne();
        }

        OnInventoryChange?.Invoke();
    }

    public void RemoveItem(ItemData item)
    {
        if (item == null) return;

        var slot = GetSlot(item);

        if (slot != null)
        {
            slot.RemoveOne();
            if (slot.IsEmpty()) Slots.Remove(slot);
            OnInventoryChange?.Invoke();
        }
    }

    private ItemSlot GetSlot(ItemData item)
    {
        for (int i = 0; i < Slots.Count; i++)
        {
            if (Slots[i].HasItem(item)) return Slots[i];
        }
        return null;
    }

    public ItemSlot GetSlot(int i)
    {
        return Slots[i];
    }
}