using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelBtnScr : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI LvPriceText;
    [SerializeField] TextMeshProUGUI LvChangeText;

    int LvPrice = 200;          //
    int playerLV = 1;           //
    int playerCoin = 1000000;   // �׳� �ӽ÷� ��������� ��������
    public void OnBtnCkick()
    {
        if(playerCoin < LvPrice)
        {
            Debug.Log("������ ����");
            return;
        }
        playerCoin -= LvPrice;
        playerLV++;
        Debug.Log(playerCoin);

        NeedLvPriceCalculator();
    }
    public void NeedLvPriceCalculator()
    {
        int LvPer10 = playerLV / 10;
        switch (LvPer10)
        {
            case 0:
                LvPrice += 100; break;
            case 1:
                LvPrice += 200; break;
            case 2:
                if (playerLV < 25) LvPrice += 200;
                else LvPrice += 350;
                break;

            case 11:
                if (playerLV < 115) LvPrice += 350;
                else LvPrice += 450;
                break;

            default:
                if(playerLV < 120)
                {
                    if (LvPer10 % 2 == 1)
                        LvPrice += 200;
                    else
                        LvPrice += 350;
                }
                break;
        }
        UpdateLvBtn();
    }

    public void UpdateLvBtn()
    {
        LvPriceText.text = $"-{LvPrice}G";
        LvChangeText.text = $"{playerLV} -> {playerLV + 1}";
    }
}
