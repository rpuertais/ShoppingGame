using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    public Inventory playerInventory;
    public Inventory shopInventory;

    public CoinsWallet playerWallet;
    public SelectionManager selection;

    public PlayerStats playerStats;

    public void BuySelected()
    {
        if (selection == null) return;
        if (!selection.HasSelection()) return;
        if (selection.SelectedFrom != InventoryOwner.Shop) return;

        ItemData item = selection.SelectedItem;
        if (item == null) return;

        if (!playerWallet.CanAfford(item.Cost))
        {
            Debug.Log("Not enough coins!");
            return;
        }

        if (playerWallet.Spend(item.Cost))
        {
            shopInventory.RemoveItem(item);
            playerInventory.AddItem(item);
        }
    }

    public void SellSelected()
    {
        if (selection == null) return;
        if (!selection.HasSelection()) return;
        if (selection.SelectedFrom != InventoryOwner.Player) return;

        ItemData item = selection.SelectedItem;
        if (item == null) return;

        playerInventory.RemoveItem(item);
        shopInventory.AddItem(item);

        playerWallet.Add(item.Sell);
    }

    public void UseSelected()
    {
        if (selection == null) return;
        if (!selection.HasSelection()) return;
        if (selection.SelectedFrom != InventoryOwner.Player) return;

        ItemData item = selection.SelectedItem;
        if (item == null) return;

        if (!item.IsConsumable)
        {
            Debug.Log("Item is not consumable!");
            return;
        }

        if (playerStats != null)
        {
            playerStats.Heal(item.LifeRestore);
        }

        playerInventory.RemoveItem(item);
    }
}