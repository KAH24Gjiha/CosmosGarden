using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelBtnScr : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI LvPriceText;
    [SerializeField] TextMeshProUGUI LvChangeText;
    public GameData data;

    private void Start()
    {
        data = DataManager.Instance.gameData;
    }
    public void OnBtnCkick()
    {
        if(data.Coin < data.LvPrice)
        {
            Debug.Log("소지금 부족");
            return;
        }
        data.Coin -= data.LvPrice;
        data.playerLV++;
        Debug.Log(data.Coin);

        NeedLvPriceCalculator();
    }
    public void NeedLvPriceCalculator()
    {
        int LvPer10 = data.playerLV / 10;
        switch (LvPer10)
        {
            case 0:
                data.LvPrice += 100; break;
            case 1:
                data.LvPrice += 200; break;
            case 2:
                if (data.playerLV < 25) data.LvPrice += 200;
                else data.LvPrice += 350;
                break;

            case 11:
                if (data.playerLV < 115) data.LvPrice += 350;
                else data.LvPrice += 450;
                break;

            default:
                if(data.playerLV < 120)
                {
                    if (LvPer10 % 2 == 1)
                        data.LvPrice += 200;
                    else
                        data.LvPrice += 350;
                }
                break;
        }
        UpdateLvBtn();
    }

    public void UpdateLvBtn()
    {
        LvPriceText.text = $"-{data.LvPrice}G";
        LvChangeText.text = $"{data.playerLV} -> {data.playerLV + 1}";
    }
}
