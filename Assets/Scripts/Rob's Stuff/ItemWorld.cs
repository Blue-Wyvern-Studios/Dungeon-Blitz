using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position, InventoryItem item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfWorldItem, position, Quaternion.identity);

        ItemWorld ItemWorld = transform.GetComponent<ItemWorld>();
        ItemWorld.SetItem(item);

        return ItemWorld;
    }

    private InventoryItem item;

    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetItem(InventoryItem item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
    }
}
