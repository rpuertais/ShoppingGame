using UnityEngine;

public enum ItemType
{
    Food,
    Potion,
    Weapon
}

[CreateAssetMenu(fileName = "ItemData", menuName = "Items/ItemData")]
public class ItemData : ScriptableObject
{
    [Header("Details")]
    public string Name;
    [TextArea] public string Description;
    public ItemType Type;

    [Header("Stack / Use")]
    public bool IsStackable = true;
    public bool IsConsumable = false;

    [Header("Consumable")]
    public int LifeRestore = 0;

    [Header("Economy")]
    public int Cost = 1;
    public int Sell = 1;

    [Header("Graphics")]
    public Sprite Image;
}