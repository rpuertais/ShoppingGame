using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour, IPointerClickHandler
{
    public Image Image;
    public TextMeshProUGUI AmountText;

    private ItemData item;
    private InventoryUI inventoryUI;

    public void Initialize(ItemSlot slot, InventoryUI inventoryUI)
    {
        this.inventoryUI = inventoryUI;
        item = slot.Item;

        Image.sprite = slot.Item.Image;
        Image.SetNativeSize();

        AmountText.text = slot.Amount.ToString();
        AmountText.enabled = (slot.Amount > 1);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (inventoryUI == null || item == null) return;
        inventoryUI.SelectItem(item);
    }
}