using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItem : MonoBehaviour
{
    public int item;
    public Crafting CraftingObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Selected()
    {
        CraftingObj.item = DataManager.Instance.gameData.Inventory[item];
        CraftingObj.SetUIInfo();
    }

}
