using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SellItem : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text amountText;
    public TMP_Text priceText;
    public Image image;

    public Item item;

    public Button sellBtn;

    // Start is called before the first frame update
    void Start()
    {
        SlotUpdate();
    }

    public void Sell()
    {
        if (item.Amount > 0)
        {
            item.Amount--;
            DataManager.Instance.gameData.Coin += item.Price;
            SlotUpdate();
        }
        
    }
    public void SlotUpdate()
    {
        nameText.text = item.itemName;
        amountText.text = item.Amount.ToString();
        priceText.text = item.Price.ToString();
        image.sprite = item.sprite;

        if (item.Amount <= 0) sellBtn.gameObject.GetComponent<Image>().color = new Color(0.7f, 0.7f, 0.7f, 1);
    }
}
