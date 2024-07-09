using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSetting : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public string[] itemName;
    public string[] itemInfo;

    public int[] Price;

    public ItemType[] itemType;
    public Sprite[] sprite;

    [SerializeField]
    public string[] crafting;

    private void Awake()
    {
        if(DataManager.Instance.gameData.Inventory.Count <= 0)
        SetItem();
    }
    public string[] SetCrafting(string craftList)
    {
        string[] craft = craftList.Split('/');
        return craft;
    }
    public void SetItem()
    {
        for(int i = 0; i < itemName.Length; i++)
        {
            items.Add(new Item(
                itemName[i],
                itemInfo[i],
                Price[i],
                itemType[i],
                sprite[i],
                 SetCrafting(crafting[i])
                )) ;
        }
        DataManager.Instance.gameData.Inventory = items;
    }

}
