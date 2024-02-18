using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript
{
    public event EventHandler OnItemListChanged;

    private List<InventoryItem> itemList;

    //initializing list
    public InventoryScript()
    {
        itemList = new List<InventoryItem>();

        AddItem(new InventoryItem { itemType = InventoryItem.ItemType.Skull, amount = 1 });
        AddItem(new InventoryItem { itemType = InventoryItem.ItemType.Undead_Wisp, amount = 1 });
        AddItem(new InventoryItem { itemType = InventoryItem.ItemType.Bone, amount = 1 });
    }

    public void AddItem(InventoryItem item)
    {
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<InventoryItem> GetItemList()
    {
        return itemList;
    }
}
