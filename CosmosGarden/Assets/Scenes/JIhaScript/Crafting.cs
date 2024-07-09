using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Crafting : MonoBehaviour
{
    public Item item;
    public GameData itemList;
    public InventorySlot InventorySlot;

    public TMP_Text itemName;
    public TMP_Text itemInfo;
    public TMP_Text craftingCondition;
    public Image itemImage;

    void Start()
    {
        itemList = DataManager.Instance.gameData;
    }
    public void SetUIInfo()
    {
        itemName.text = item.itemName;
        itemInfo.text = item.itemInfo;
        craftingCondition.text = "";

        for (int i = 0; i < item.crafting.Length; i++)
        {
            string itemName = SplitCraftingStr(item.crafting[i]);
            Item InvenItem = itemList.Inventory.Find(iName => iName.itemName == itemName);

            craftingCondition.text += $"{InvenItem.itemName} ( {InvenItem.Amount} / {SplitCraftingInt(item.crafting[i])} ) \n";
        }

        itemImage.sprite = item.sprite;


    }
    public bool ConditionSatisfy()
    {
        for(int i = 0; i < item.crafting.Length; i++)
        {
            if (!ItemAmountCheck(item.crafting[i])) return false;
        }

        if (DataManager.Instance.gameData.Inventory.Find(iName => iName.itemName == item.itemName).Amount <= 0) InventorySlot.AddItem(item);
        itemList.Inventory.Find(iName => iName.itemName == item.itemName).Amount++;

        InventorySlot.FreshSlot();
        SetUIInfo();

        return true;
    }
    public void ItemCraft()
    {
        ConditionSatisfy();
    }
    public bool ItemAmountCheck(string itemCraft)
    {

        string itemName = SplitCraftingStr(itemCraft);
        int itemAmount = SplitCraftingInt(itemCraft);

        
        if (itemList.Inventory.Find(item => item.itemName == itemName).Amount >= itemAmount) 
        {
            itemList.Inventory.Find(item => item.itemName == itemName).Amount -= itemAmount;
            return true; 
        }
        else return false;
    }
    public string SplitCraftingStr(string itemCraft)
    {
        string[] SplitItem = itemCraft.Split(',');

        string itemName = SplitItem[0];
        return itemName;
    }
    public int SplitCraftingInt(string itemCraft)
    {
        string[] SplitItem = itemCraft.Split(',');

        int itemAmount = int.Parse(SplitItem[1]);
        return itemAmount;
    }


}
/*
            Item InvenItem;
            try
            {
                InvenItem = itemList.Inventory.Find(item => item.itemName == itemName);
            }
            catch
            {
                InvenItem = null;
            }

            if (InvenItem != null)
            {
                InvenItem = itemList.Inventory.Find(item => item.itemName == itemName);
                craftingCondition.text += $"{InvenItem.itemName} ( {InvenItem.Amount} / {SplitCraftingInt(item.crafting[i])} ) \n";
            }
            else {
                craftingCondition.text += $"{itemName} ( 0 / {SplitCraftingInt(item.crafting[i])} ) \n"; 
            }
            */
