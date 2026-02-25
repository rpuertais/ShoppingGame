/*using UnityEngine;

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

        if (!playerWallet.CanAfford(item.Buy))
        {
            return;
        }

        if (playerWallet.Spend(item.Buy))
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
        if (playerWallet.Sell(item.Sell))
        {
            playerInventory.RemoveItem(item);
            shopInventory.AddItem(item);

            playerWallet.Add(item.Sell);
        }
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
            return;
        }

        if (playerStats != null)
        {
            playerStats.Heal(item.LifeRestore);
        }

        playerInventory.RemoveItem(item);
    }
}*/

using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    public Inventory playerInventory;
    public Inventory shopInventory;

    public CoinsWallet playerWallet;
    public SelectionManager selection;

    public PlayerStats playerStats;

    [Header("Optional SFX")]
    public AudioSource audioSource;
    public AudioClip useSound;

    public void BuySelected()
    {
        if (selection == null) return;
        if (!selection.HasSelection()) return;
        if (selection.SelectedFrom != InventoryOwner.Shop) return;

        ItemData item = selection.SelectedItem;
        if (item == null) return;

        if (shopInventory == null) return;
        if (!shopInventory.HasItem(item)) return;

        if (playerWallet == null) return;
        if (!playerWallet.CanAfford(item.Buy)) return;

        bool paid = playerWallet.Spend(item.Buy);
        if (!paid) return;

        shopInventory.RemoveItem(item);
        playerInventory.AddItem(item);

        
        KeepOrClearAfterAction(item, InventoryOwner.Shop);
    }

    public void SellSelected()
    {
        if (selection == null) return;
        if (!selection.HasSelection()) return;
        if (selection.SelectedFrom != InventoryOwner.Player) return;

        ItemData item = selection.SelectedItem;
        if (item == null) return;

        if (playerInventory == null) return;
        if (!playerInventory.HasItem(item)) return;

        if (playerWallet == null) return;
        if (!playerWallet.Sell(item.Sell)) return;

        playerWallet.Add(item.Sell);

        playerInventory.RemoveItem(item);
        shopInventory.AddItem(item);

        
        KeepOrClearAfterAction(item, InventoryOwner.Player);
    }

    public void UseSelected()
    {
        if (selection == null) return;
        if (!selection.HasSelection()) return;
        if (selection.SelectedFrom != InventoryOwner.Player) return;

        ItemData item = selection.SelectedItem;
        if (item == null) return;

        if (playerInventory == null) return;
        if (!playerInventory.HasItem(item)) return;

        if (!item.IsConsumable) return;

        if (playerStats == null) return;
        if (playerStats.IsFullLife()) return; 

        playerStats.Heal(item.LifeRestore);
        playerInventory.RemoveItem(item);

        
        PlayUseSound();

        
        KeepOrClearAfterAction(item, InventoryOwner.Player);
    }

    private void KeepOrClearAfterAction(ItemData item, InventoryOwner from)
    {
        if (selection == null) return;

        bool keep = false;

        if (item != null && item.IsStackable)
        {
            if (from == InventoryOwner.Player)
            {
                if (playerInventory != null && playerInventory.HasItem(item)) keep = true;
            }
            else
            {
                if (shopInventory != null && shopInventory.HasItem(item)) keep = true;
            }
        }

        if (keep)
        {
            
            if (from == selection.SelectedFrom)
            {
               
            }
        }
        else
        {
            selection.ClearSelection();
        }
    }

    private void PlayUseSound()
    {
        if (audioSource == null) return;
        if (useSound == null) return;

        audioSource.PlayOneShot(useSound);
    }
}