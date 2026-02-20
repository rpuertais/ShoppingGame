using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{

    public ItemData Item;

    public TextMeshProUGUI TextName;
    public TextMeshProUGUI TextDescription;
    public TextMeshProUGUI TextCost;
    public TextMeshProUGUI TextSell;
    public TextMeshProUGUI TextLifeRestore;
    public Image Image;

    void Start()
    {
        SetCard(Item);
    }

    void SetCard(ItemData Item)
    {
        TextName.text = Item.Name;
        TextDescription.text = Item.Description;
        TextCost.text = Item.Cost.ToString();
        TextSell.text = Item.Sell.ToString();
        TextLifeRestore.text = Item.LifeRestore.ToString();
        Image.sprite = Item.Image;
    }
}

