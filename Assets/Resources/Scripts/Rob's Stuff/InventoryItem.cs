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

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Bone:         return ItemAssets.Instance.BoneSprite;
            case ItemType.Skull:        return ItemAssets.Instance.SkullSprite;
            case ItemType.Undead_Wisp:  return ItemAssets.Instance.Undead_WispSprite;

        }
    }
}
