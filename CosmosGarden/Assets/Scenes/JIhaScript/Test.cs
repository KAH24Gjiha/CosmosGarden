using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Item item;
    public InventorySlot invenSlot;
    // Start is called before the first frame update
    public void ItemPlus() { if (item.Amount <= 0) invenSlot.AddItem(item); item.Amount++; invenSlot.FreshSlot(); }
}
