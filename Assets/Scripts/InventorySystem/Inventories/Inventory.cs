using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Items/Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField] private List<ItemSlot> slots = new List<ItemSlot>();

    public Action OnInventoryChange;

    public int GetLength()
    { 
        return slots.Count;
    }

    public void Clear()
    {
        slots.Clear();
        if (OnInventoryChange != null)
        {
            OnInventoryChange.Invoke();
        }
    }

    public bool HasItem(ItemData item)
    {
        if (item == null)
        {
            return false;
        }

        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i] != null && slots[i].Item == item && slots[i].Amount > 0)
            {
                return true;
            }
        }
        return false;
    }

    public void AddItem(ItemData item)
    {
        AddItem(item, 1);
    }

    public void AddItem(ItemData item, int amount)
    {
        if (item == null || amount <= 0)
        {
            return;
        }
        
        if (item.IsStackable == false)
        {
            for (int i = 0; i < amount; i++)
            {
                slots.Add(new ItemSlot(item));
            }

            if (OnInventoryChange != null)
            {
                OnInventoryChange.Invoke();
            }
            return;
        }

        ItemSlot slot = null;
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].Item == item)
            {
                slot = slots[i];
                break;
            }
        }

        if (slot == null)
        {
            slot = new ItemSlot(item);
            slots.Add(slot);

            for (int i = 1; i < amount; i++)
            {
                slot.AddOne();
            }
        }
        else
        {
            for (int i = 0; i < amount; i++)
            {
                slot.AddOne();
            }
        }

        if (OnInventoryChange != null)
        {
            OnInventoryChange.Invoke();
        }
    }

    public void RemoveItem(ItemData item)
    {
        if (item == null) return;

        ItemSlot slot = null;
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].Item == item)
            {
                slot = slots[i];
                break;
            }
        }

        if (slot == null)
        {
            return;
        }

        slot.RemoveOne();
        if (slot.IsEmpty())
        {
            slots.Remove(slot);
        }

        if (OnInventoryChange != null)
        {
            OnInventoryChange.Invoke();
        }
    }

    public ItemSlot GetSlot(int i)
    {
        return slots[i];
    }
}