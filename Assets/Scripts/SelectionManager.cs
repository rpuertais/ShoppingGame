/*using UnityEngine;

public enum InventoryOwner
{
    Player,
    Shop
}
public class SelectionManager : MonoBehaviour
{
    public ItemUI selectedItemUI;

    [Header("Sound")]
    public AudioSource audioSource;
    public AudioClip clickSound;

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

        PlayClickSound();
    }

    public void ClearSelection()
    {
        SelectedItem = null;

        if (selectedItemUI != null)
            selectedItemUI.Clear();
    }

    private void PlayClickSound()
    {
        if (audioSource == null || clickSound == null) return;
        audioSource.PlayOneShot(clickSound);
    }
}*/

using UnityEngine;

public enum InventoryOwner
{
    Player,
    Shop
}

public class SelectionManager : MonoBehaviour
{
    public ItemUI selectedItemUI;

    [Header("Click Sound")]
    public AudioSource audioSource;
    public AudioClip clickSound;

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

        if (selectedItemUI != null)
        {
            selectedItemUI.SetCard(item);
        }

        if (playSound)
        {
            PlayClickSound();
        }
    }

    public void ClearSelection()
    {
        SelectedItem = null;

        if (selectedItemUI != null)
        {
            selectedItemUI.Clear();
        }

        if (lastInventoryUI != null)
        {
            lastInventoryUI.ClearSelectionVisual();
            lastInventoryUI = null;
        }
    }

    private void PlayClickSound()
    {
        if (audioSource == null) return;
        if (clickSound == null) return;

        audioSource.PlayOneShot(clickSound);
    }
}