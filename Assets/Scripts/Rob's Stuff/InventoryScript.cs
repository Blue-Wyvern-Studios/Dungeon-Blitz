using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript
{
    private List<InventoryItem> itemList;

    //initializing list
    public InventoryScript()
    {
        itemList = new List<InventoryItem>();

        AddItem(new InventoryItem { itemType = InventoryItem.ItemType.Skull, amount = 1 });
        Debug.Log(itemList.Count);
    }

    public void AddItem(InventoryItem item)
    {
        itemList.Add(item);
    }
}
