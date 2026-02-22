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
        if (Item != null) SetCard(Item);
        else Clear();
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

        if (TextName != null)
            TextName.text = Localizer.GetText(Item.NameKey);

        if (TextDescription != null)
            TextDescription.text = Localizer.GetText(Item.DescriptionKey);

        if (TextType != null)
            TextType.text = $"{Localizer.GetText("GAME_TYPE")}: {Item.Type}";

        if (TextCost != null)
            TextCost.text = $"{Localizer.GetText("GAME_BUY")}: {Item.Buy}";

        if (TextSell != null)
            TextSell.text = $"{Localizer.GetText("GAME_SELL")}: {Item.Sell}";

        if (TextLifeRestore != null)
        {
            if (Item.IsConsumable)
            {
                TextLifeRestore.gameObject.SetActive(true);
                TextLifeRestore.text =
                    $"{Localizer.GetText("GAME_LIFE_RESTORE")}: {Item.LifeRestore}";
            }
            else
            {
                TextLifeRestore.gameObject.SetActive(false);
            }
        }

        if (Image != null)
            Image.sprite = Item.Image;
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