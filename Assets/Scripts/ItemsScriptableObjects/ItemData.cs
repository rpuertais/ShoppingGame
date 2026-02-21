using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Items/ItemData")]
public class ItemData : ScriptableObject
{
    [Header("Details")]
    public string Name;
    public string Description;

    public bool IsStackable;
    public bool IsConsumable;
    [Header("If consumable is true")]
    public int LifeRestore;

    [Header("Economy")]
    public int Cost;
    public int Sell;

    [Header("Image")]
    public Sprite Image;
}
