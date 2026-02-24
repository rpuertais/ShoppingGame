using UnityEngine;

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
}