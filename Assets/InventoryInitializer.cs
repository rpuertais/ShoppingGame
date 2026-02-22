using System.Collections.Generic;
using UnityEngine;

public class InventoryInitializer : MonoBehaviour
{
    [System.Serializable]
    public class StartItem
    {
        public ItemData item;
        public int amount = 1;
    }

    public Inventory playerInventory;
    public Inventory shopInventory;

    [Header("Start Items")]
    public List<StartItem> playerStartItems = new List<StartItem>();
    public List<StartItem> shopStartItems = new List<StartItem>();

    [Header("Reset each Play")]
    public bool clearInventoriesOnStart = true;

    private void Awake()
    {
        if (playerInventory == null || shopInventory == null)
        {
            Debug.LogError("InventoryInitializer: falta assignar playerInventory o shopInventory.");
            return;
        }

        if (clearInventoriesOnStart)
        {
            playerInventory.Clear();
            shopInventory.Clear();
        }

        AddList(playerInventory, playerStartItems);
        AddList(shopInventory, shopStartItems);
    }

    private void AddList(Inventory inv, List<StartItem> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].item == null) continue;
            inv.AddItem(list[i].item, list[i].amount);
        }
    }
}