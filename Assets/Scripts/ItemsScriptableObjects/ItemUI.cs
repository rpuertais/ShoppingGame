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

    private void OnEnable()
    {
        Localizer.OnLanguageChange += RefreshLanguage;
    }

    private void OnDisable()
    {
        Localizer.OnLanguageChange -= RefreshLanguage;
    }

    private void Start()
    {
        if (Item != null)
        {
            SetCard(Item);
        }
        else
        {
            Clear();
        }
    }

    public void SetCard(ItemData item)
    {
        Item = item;
        RefreshLanguage();
    }

    private void RefreshLanguage()
    {
        if (Item == null)
        {
            Clear();
            return;
        }
        TextName.text = Localizer.GetText(Item.NameKey);
        TextDescription.text = Localizer.GetText(Item.DescriptionKey);
        TextType.text = Localizer.GetText("GAME_TYPE") + ": " + Localizer.GetText(Item.Type.ToString());
        TextCost.text = Localizer.GetText("GAME_BUY") + ": " + Item.Buy;
        TextSell.text = Localizer.GetText("GAME_SELL") + ": " + Item.Sell;

        if (Item.IsConsumable)
        {
            TextLifeRestore.gameObject.SetActive(true);
            TextLifeRestore.text = Localizer.GetText("GAME_LIFE_RESTORE") + ": " + Item.LifeRestore;
        }
        else
        {
            TextLifeRestore.gameObject.SetActive(false);
            TextLifeRestore.text = "";
        }

        Image.gameObject.SetActive(true);
        Image.sprite = Item.Image;
        Image.color = Color.white;
    }

    public void Clear()
    {
        Item = null;

        TextName.text = "";
        TextDescription.text = "";

        TextType.text = "";
        TextCost.text = "";
        TextSell.text = "";

        TextLifeRestore.text = "";
        TextLifeRestore.gameObject.SetActive(false);

        Image.sprite = null;
        Image.gameObject.SetActive(false);
    }
}