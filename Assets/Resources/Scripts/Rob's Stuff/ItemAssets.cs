using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfWorldItem;

    public Sprite BoneSprite;
    public Sprite SkullSprite;
    public Sprite Undead_WispSprite;
}
