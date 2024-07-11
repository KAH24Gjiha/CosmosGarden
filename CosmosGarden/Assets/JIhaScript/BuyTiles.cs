using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class BuyTiles : MonoBehaviour
{
    public EditTile editTile;

    public GameObject Button;
    public UIController UIController;
    public int[] items;

    public Tile tile;
    public bool isLand;
    public int price;

    public void Buy()
    {
        if(isbuy())
        {
            DataManager.Instance.gameData.Coin -= price;

            editTile.NewTile = tile;
            editTile.isEditLand = isLand;
            editTile.IsSettings();

            UIController.UIOff(4);
            UIController.UIOff(5);

            if (isLand) SetItem();
        }
        isbuy();
    }
    public bool isbuy()
    {
        if (DataManager.Instance.gameData.Coin >= price)
        {
            Button.GetComponent<Image>().color = new Color(1,1,1,1);
            return true;
        }
        else
        {
            Button.GetComponent<Image>().color = new Color(0.7f, 0.7f, 0.7f, 1);
            return false;
        }
    }
    public void SetItem()
    {
        for (int i = 0; i < items.Length; i++)
            DataManager.Instance.gameData.clickIncrease.Add(items[i]);
    }
}
