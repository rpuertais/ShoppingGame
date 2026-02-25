using UnityEngine;

public enum ItemType
{
    GAME_TYPE_FOOD,
    GAME_TYPE_POTION,
    GAME_TYPE_WEPAPON
}

[CreateAssetMenu(fileName = "ItemData", menuName = "Items/ItemData")]
public class ItemData : ScriptableObject
{
    [Header("Localization Keys")]
    public string NameKey;
    public string DescriptionKey;

    [Header("Type")]
    public ItemType Type;

    [Header("Stack / Use")]
    public bool IsStackable = true;
    public bool IsConsumable = false;

    [Header("Consumable")]
    public int LifeRestore = 0;

    [Header("Economy")]
    public int Buy = 1;
    public int Sell = 1;

    [Header("Graphics")]
    public Sprite Image;
}