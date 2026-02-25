using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    public Inventory PlayerInventory;
    public Inventory ShopInventory;

    public CoinsWallet PlayerWallet;
    public SelectionManager Selection;

    public PlayerStats PlayerStats;

    [Header("Audio")]
    public AudioSource AudioSource;
    public AudioClip UseSound;

    public void BuySelected()
    {
        if (Selection == null || PlayerInventory == null || ShopInventory == null || PlayerWallet == null)
        {
            return;
        }

        ItemData item = Selection.SelectedItem;

        if (Selection.HasSelection() && Selection.SelectedFrom == InventoryOwner.Shop && item != null && ShopInventory.HasItem(item) && PlayerWallet.CanAfford(item.Buy))
        {
            if (PlayerWallet.Spend(item.Buy))
            {
                ShopInventory.RemoveItem(item);
                PlayerInventory.AddItem(item);

                UpdateSelectionAfterAction(item, InventoryOwner.Shop);
            }
        }
    }

    public void SellSelected()
    {
        if (Selection == null || PlayerInventory == null || ShopInventory == null || PlayerWallet == null)
        {
            return;
        }

        ItemData item = Selection.SelectedItem;

        if (Selection.HasSelection() && Selection.SelectedFrom == InventoryOwner.Player && item != null && PlayerInventory.HasItem(item) && PlayerWallet.Sell(item.Sell))
        {
            PlayerWallet.Add(item.Sell);

            PlayerInventory.RemoveItem(item);
            ShopInventory.AddItem(item);

            UpdateSelectionAfterAction(item, InventoryOwner.Player);
        }
    }

    public void UseSelected()
    {
        if (Selection == null || PlayerInventory == null || PlayerStats == null)
        {
            return;
        }

        ItemData item = Selection.SelectedItem;

        if (Selection.HasSelection() && Selection.SelectedFrom == InventoryOwner.Player && item != null && item.IsConsumable && PlayerInventory.HasItem(item) && !PlayerStats.IsFullLife())
        {
            PlayerStats.Heal(item.LifeRestore);
            PlayerInventory.RemoveItem(item);

            PlayUseSound();

            UpdateSelectionAfterAction(item, InventoryOwner.Player);
        }
    }

    private void UpdateSelectionAfterAction(ItemData item, InventoryOwner from)
    {
        if (Selection == null)
        {
            return;
        }

        bool keepSelection = false;

        if (item != null && item.IsStackable)
        {
            if (from == InventoryOwner.Player)
            {
                if (PlayerInventory != null && PlayerInventory.HasItem(item))
                {
                    keepSelection = true;
                }
            }
            else
            {
                if (ShopInventory != null && ShopInventory.HasItem(item))
                {
                    keepSelection = true;
                }
            }
        }

        if (!keepSelection)
        {
            Selection.ClearSelection();
        }
    }

    private void PlayUseSound()
    {
        if (AudioSource != null && UseSound != null)
        {
            AudioSource.PlayOneShot(UseSound);
        }
    }
}