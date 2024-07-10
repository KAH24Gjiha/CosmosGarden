using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int[] item;
    public InventorySlot invenSlot;
    // Start is called before the first frame update
    public void ItemPlus() { 
        for(int i = 0; i < item.Length; i++)
        {
            DataManager.Instance.gameData.Inventory[item[i]].Amount++;
            }
        
        invenSlot.FreshSlot(); 
    }
}
