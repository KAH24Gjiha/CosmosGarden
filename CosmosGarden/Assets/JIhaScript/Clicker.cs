using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    public GameData data;
    public InventorySlot inventory;

    public bool isAuto = true;

    private void Start()
    {
        data = DataManager.Instance.gameData;
        StartCoroutine(AutoCilck());
    }

    public void Click()
    {
        for(int i = 0; i < data.clickIncrease.Count; i++)
        {
            data.Inventory[i].Amount += data.Level_Trash[(int)(data.playerLV / 10)];
            inventory.FreshSlot();
        }
    }
    public IEnumerator AutoCilck()
    {
        while (isAuto)
        {
            yield return new WaitForSeconds(data.Level_Auto[(int)(data.playerLV / 10)]);
            Click();
        }
    }

}
