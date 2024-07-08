using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Trash,
    Recycle
}
[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string itemName;
    public string itemInfo;

    public int Amount;
    public int Price;

    public ItemType itemType;
    public Sprite sprite;

    public List<string> crafting;
}


