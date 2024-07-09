using System;
using UnityEngine;

public class ShopItemClass
{
    public string Name { get; }
    public int Price { get; }
    public GameObject ItemPrefab { get; }

    public ShopItemClass(string name, int price)
    {
        Name = name;
        Price = price;
    }
}
