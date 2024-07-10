using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Trash,
    Recycle
}
[Serializable]
public class Item 
{
    public string itemName;
    public string itemInfo;

    public int Amount;
    public int Price;

    public ItemType itemType;
    public Sprite sprite;

    public string[] crafting;

    public Item(string itemName,
        string itemInfo,
        int Price,
        ItemType itemType,
        Sprite sprite,
        string[] crafting)
    {
        this.itemName = itemName;
        this.itemInfo = itemInfo;
        this.Price = Price;
        this.itemType = itemType;
        this.sprite = sprite;
        this.crafting = crafting;
    }
}


