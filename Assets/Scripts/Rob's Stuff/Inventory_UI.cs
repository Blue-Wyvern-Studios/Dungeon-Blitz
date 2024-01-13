using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    private InventoryScript inventory;
    private Transform itemSlotContainer;
    private Transform itemSlot;

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlot = itemSlotContainer.Find("itemSlot");
    }

    public void SetInventory(InventoryScript inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 300f;
        foreach (InventoryItem item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlot, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            x++;
            if(x > 7)
            {
                x = 0;
                y++;
            }
        }
    }
}
