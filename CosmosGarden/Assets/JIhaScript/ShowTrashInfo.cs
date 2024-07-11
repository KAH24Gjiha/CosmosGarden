using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowTrashInfo : MonoBehaviour
{
    public Image image;
    public TMP_Text nameText;
    public TMP_Text infoText;

    public Item item;
    public Sprite clear;

    void Start()
    {
        Init_Info();
    }

    // Update is called once per frame
    public void SelectItem()
    {
        item = this.transform.GetChild(0).GetComponent<InvenSlot>()._item;

        if(item != null)
        {
            image.sprite = item.sprite;
            nameText.text = item.itemName;
            infoText.text = item.itemInfo;
        }
    }
    public void Init_Info()
    {
        image.sprite = clear;
        nameText.text = " ";
        infoText.text = " ";
    }
}
