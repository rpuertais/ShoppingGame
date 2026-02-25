using UnityEngine;

public enum InventoryOwner
{
    Player,
    Shop
}

public class SelectionManager : MonoBehaviour
{
    public ItemUI SelectedItemUI;

    [Header("Click Sound")]
    public AudioSource AudioSource;
    public AudioClip ClickSound;

    public ItemData SelectedItem { get; private set; }
    public InventoryOwner SelectedFrom { get; private set; }

    private InventoryUI lastInventoryUI;

    public bool HasSelection()
    {
        return SelectedItem != null;
    }

    public void Select(ItemData item, InventoryOwner from, InventoryUI inventoryUI, bool playSound)
    {
        if (lastInventoryUI != null && lastInventoryUI != inventoryUI)
        {
            lastInventoryUI.ClearSelectionVisual();
        }

        lastInventoryUI = inventoryUI;

        SelectedItem = item;
        SelectedFrom = from;

        if (SelectedItemUI != null)
        {
            SelectedItemUI.SetCard(item);
        }

        if (playSound)
        {
            PlayClickSound();
        }
    }

    public void ClearSelection()
    {
        SelectedItem = null;

        if (SelectedItemUI != null)
        {
            SelectedItemUI.Clear();
        }

        if (lastInventoryUI != null)
        {
            lastInventoryUI.ClearSelectionVisual();
            lastInventoryUI = null;
        }
    }

    private void PlayClickSound()
    {
        if (AudioSource == null)
        {
            return; 
        }

        if (ClickSound == null) 
        {
            return;
        }
        AudioSource.PlayOneShot(ClickSound);
    }
}