/*using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour, IPointerClickHandler
{
    public Image Image;              
    public TextMeshProUGUI AmountText;

    [Header("Highlight")]
    public Image Background;         
    public Color NormalColor;
    public Color SelectedColor;

    private ItemData item;
    private InventoryUI inventoryUI;

    public void Initialize(ItemSlot slot, InventoryUI inventoryUI)
    {
        this.inventoryUI = inventoryUI;
        item = slot.Item;

        Image.enabled = true;
        Image.sprite = slot.Item.Image;
        Image.preserveAspect = true;

        AmountText.text = slot.Amount.ToString();
        AmountText.enabled = (slot.Amount > 1);

        SetSelected(false);
    }

    public void InitializeEmpty(InventoryUI inventoryUI)
    {
        this.inventoryUI = inventoryUI;
        item = null;

        Image.enabled = false;
        Image.sprite = null;

        AmountText.enabled = false;
        AmountText.text = "";

        SetSelected(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (inventoryUI == null || item == null) return;
        inventoryUI.SelectSlot(this, item);
    }

    public void SetSelected(bool selected)
    {
        if (Background == null) return;

        if (selected)
        {
            Background.color = SelectedColor;
        }
        else
        {
            Background.color = NormalColor;
        }
    }
}*/

using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour, IPointerClickHandler
{
    public Image Image;
    public TextMeshProUGUI AmountText;

    [Header("Highlight")]
    public Image Background;
    public Color NormalColor = Color.white;
    public Color SelectedColor = new Color(1f, 1f, 0.5f);

    private ItemData item;
    private InventoryUI inventoryUI;

    public ItemData GetItem()
    {
        return item;
    }

    public void Initialize(ItemSlot slot, InventoryUI inventoryUI)
    {
        this.inventoryUI = inventoryUI;
        item = slot.Item;

        Image.enabled = true;
        Image.sprite = slot.Item.Image;
        Image.preserveAspect = true;

        AmountText.text = slot.Amount.ToString();
        AmountText.enabled = (slot.Amount > 1);

        SetSelected(false);
    }

    public void InitializeEmpty(InventoryUI inventoryUI)
    {
        this.inventoryUI = inventoryUI;
        item = null;

        Image.enabled = false;
        Image.sprite = null;

        AmountText.enabled = false;
        AmountText.text = "";

        SetSelected(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (inventoryUI == null) return;
        if (item == null) return;

        inventoryUI.SelectSlot(this, item);
    }

    public void SetSelected(bool selected)
    {
        if (Background == null) return;

        if (selected)
        {
            Background.color = SelectedColor;
        }
        else
        {
            Background.color = NormalColor;
        }
    }
}