using UnityEngine;

public class InventoryInitializer : MonoBehaviour
{
    public Inventory PlayerInventory;
    public Inventory ShopInventory;

    [Header("Player start items")]
    public ItemData[] PlayerItems;
    public int[] PlayerAmounts;

    [Header("Shop start items")]
    public ItemData[] ShopItems;
    public int[] ShopAmounts;

    public bool ClearInventoriesOnStart = true;

    private void Start()
    {
        if (ClearInventoriesOnStart)
        {
            if (PlayerInventory != null)
            {
                PlayerInventory.Clear();
            }
            if (ShopInventory != null)
            {
                ShopInventory.Clear();
            }
        }

        InitInventory(PlayerInventory, PlayerItems, PlayerAmounts);
        InitInventory(ShopInventory, ShopItems, ShopAmounts);
    }

    private void InitInventory(Inventory inventory, ItemData[] items, int[] amounts)
    {
        if (inventory == null || items == null || amounts == null)
        {
            return;
        }

        int count = items.Length;
        if (amounts.Length < count)
        {
            count = amounts.Length;
        }

        for (int i = 0; i < count; i++)
        {
            if (items[i] != null && amounts[i] > 0)
            {
                inventory.AddItem(items[i], amounts[i]);
            }
        }
    }
}