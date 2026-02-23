using UnityEngine;

public enum InventoryOwner
{
    Player,
    Shop
}

public class SelectionManager : MonoBehaviour
{
    public ItemUI selectedItemUI;

    public ItemData SelectedItem { get; private set; }
    public InventoryOwner SelectedFrom { get; private set; }

    public bool HasSelection()
    {
        return SelectedItem != null;
    }

    public void Select(ItemData item, InventoryOwner from)
    {
        SelectedItem = item;
        SelectedFrom = from;

        if (selectedItemUI != null)
            selectedItemUI.SetCard(item);
    }

    public void ClearSelection()
    {
        SelectedItem = null;

        if (selectedItemUI != null)
            selectedItemUI.Clear();
    }
}