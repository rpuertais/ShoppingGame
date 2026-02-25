/*using System;
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
}*/

using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Items/Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField] private List<ItemSlot> Slots = new List<ItemSlot>();

    public int Length
    {
        get { return Slots.Count; }
    }

    public Action OnInventoryChange;

    public void Clear()
    {
        Slots.Clear();
        if (OnInventoryChange != null) OnInventoryChange.Invoke();
    }

    public bool HasItem(ItemData item)
    {
        if (item == null) return false;

        for (int i = 0; i < Slots.Count; i++)
        {
            if (Slots[i] != null && Slots[i].Item == item && Slots[i].Amount > 0)
                return true;
        }
        return false;
    }

    public void AddItem(ItemData item)
    {
        AddItem(item, 1);
    }

    public void AddItem(ItemData item, int amount)
    {
        if (item == null) return;
        if (amount <= 0) return;

        
        if (item.IsStackable == false)
        {
            for (int i = 0; i < amount; i++)
            {
                Slots.Add(new ItemSlot(item));
            }

            if (OnInventoryChange != null) OnInventoryChange.Invoke();
            return;
        }

        
        ItemSlot slot = null;
        for (int i = 0; i < Slots.Count; i++)
        {
            if (Slots[i].Item == item)
            {
                slot = Slots[i];
                break;
            }
        }

        if (slot == null)
        {
            slot = new ItemSlot(item);
            Slots.Add(slot);

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

        if (OnInventoryChange != null) OnInventoryChange.Invoke();
    }

    public void RemoveItem(ItemData item)
    {
        if (item == null) return;

        ItemSlot slot = null;
        for (int i = 0; i < Slots.Count; i++)
        {
            if (Slots[i].Item == item)
            {
                slot = Slots[i];
                break;
            }
        }

        if (slot == null) return;

        slot.RemoveOne();
        if (slot.IsEmpty())
        {
            Slots.Remove(slot);
        }

        if (OnInventoryChange != null) OnInventoryChange.Invoke();
    }

    public ItemSlot GetSlot(int i)
    {
        return Slots[i];
    }
}