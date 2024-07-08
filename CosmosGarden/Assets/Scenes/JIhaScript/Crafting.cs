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

        for(int i = 0; i < item.crafting.Count; i++)
        {
            string itemName = SplitCraftingStr(item.crafting[i]);
            Item InvenItem = itemList.Inventory.Find(item => item.itemName == itemName);

            craftingCondition.text += $"{InvenItem.itemName} ( {InvenItem.Amount} / {SplitCraftingInt(item.crafting[i])} ) \n";
        }

        itemImage.sprite = item.sprite;


    }
    public bool ConditionSatisfy()
    {
        for(int i = 0; i < item.crafting.Count; i++)
        {
            if (!ItemAmountCheck(item.crafting[i])) return false;
        }

        if (item.Amount <= 0) InventorySlot.AddItem(item);
        item.Amount++;
        InventorySlot.FreshSlot();

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
        Debug.Log(SplitItem[0]);

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
