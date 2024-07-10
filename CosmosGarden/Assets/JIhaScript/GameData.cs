using System.Collections;
using System.Collections.Generic;
using TMPro;


public class GameData
{
    public List<Item> Inventory = new List<Item>();
    public int Coin = 500;

    public int playerLV;
    public int LvPrice = 200;

    public int[] Level_Trash = new int[] { 1, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 5 };
    public int[] Level_Auto = new int[] { 15, 13, 10, 8, 8, 8, 8, 8, 6, 6, 4, 2 };

    public List<int> clickIncrease = new List<int>() { 0, 1, 5 };

}
