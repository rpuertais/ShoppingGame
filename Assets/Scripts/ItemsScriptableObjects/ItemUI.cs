using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public ItemData Item;

    public TextMeshProUGUI TextName;
    public TextMeshProUGUI TextDescription;

    public TextMeshProUGUI TextType;
    public TextMeshProUGUI TextCost;
    public TextMeshProUGUI TextSell;
    public TextMeshProUGUI TextLifeRestore;

    public Image Image;

    private void Start()
    {
        if (Item != null) SetCard(Item);
        else Clear();
    }

    public void SetCard(ItemData item)
    {
        Item = item;

        if (TextName != null) TextName.text = item.Name;
        if (TextDescription != null) TextDescription.text = item.Description;

        if (TextType != null) TextType.text = $"Type: {item.Type}";
        if (TextCost != null) TextCost.text = $"Cost: {item.Cost}";
        if (TextSell != null) TextSell.text = $"Sell: {item.Sell}";

        if (TextLifeRestore != null)
        {
            if (item.IsConsumable)
            {
                TextLifeRestore.gameObject.SetActive(true);
                TextLifeRestore.text = $"Life Restore: {item.LifeRestore}";
            }
            else
            {
                TextLifeRestore.gameObject.SetActive(false);
            }
        }

        if (Image != null) Image.sprite = item.Image;
    }

    public void Clear()
    {
        Item = null;

        if (TextName != null) TextName.text = "";
        if (TextDescription != null) TextDescription.text = "";

        if (TextType != null) TextType.text = "";
        if (TextCost != null) TextCost.text = "";
        if (TextSell != null) TextSell.text = "";

        if (TextLifeRestore != null)
        {
            TextLifeRestore.text = "";
            TextLifeRestore.gameObject.SetActive(false);
        }

        if (Image != null) Image.sprite = null;
    }
}