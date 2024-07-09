using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    [SerializeField]
    private Transform slotParent;
    [SerializeField]
    private InvenSlot[] slots;

    public SellItem[] sellItem;
    public GameObject SellSlot;

#if UNITY_EDITOR
    private void Awake()
    {
        //DataManager.Instance.LoadGameData();
        slots = slotParent.GetComponentsInChildren<InvenSlot>();
    }
#endif
    void Start()
    {
        FreshSlot();
    }


    public void FreshSlot()
    {
        DeleteItem();
        int i = 0;
        for (; i < slots.Length && i < slots.Length; i++)
        {
            slots[i].item = null;
        }
        Debug.Log(DataManager.Instance.gameData.Inventory.Count);
        for (i = 0; i < DataManager.Instance.gameData.Inventory.Count; i++)
        {
            if (DataManager.Instance.gameData.Inventory[i] != null)
            {
                slots[i].item = DataManager.Instance.gameData.Inventory[i];
            }
        }
        sellItem = SellSlot.GetComponentsInChildren<SellItem>();

        for (int j = 0; j < sellItem.Length; j++) sellItem[j].SlotUpdate();
    }

    public void AddItem(Item _item)
    {
        DataManager.Instance.gameData.Inventory.Add(_item);
    }

    public void DeleteItem()
    {
        for (int i = 0; i < DataManager.Instance.gameData.Inventory.Count; i++)
        {
            if (DataManager.Instance.gameData.Inventory[i] != null && DataManager.Instance.gameData.Inventory[i].Amount <= 0)
                DataManager.Instance.gameData.Inventory.Remove(DataManager.Instance.gameData.Inventory[i]);
            
        }
        
    }
    
}
