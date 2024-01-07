using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public enum ItemType
    {
        Bone,
        Skull,
        Undead_Wisp,
    }

    public ItemType itemType;
    public int amount;
}
