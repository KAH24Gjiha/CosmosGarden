using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InvenSlot : MonoBehaviour
{
    [SerializeField] public Image image;
    public TMP_Text text;
    //public Sprite spr;
    private Item _item;

    void Awake()
    {
        
    }

    public Item item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item != null)
            {
                image.sprite = item.sprite;
                text.text = item.Amount.ToString();
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                //image.sprite = spr;
                //image.color = new Color(1, 1, 1, 0);
                //image.color = new Color(1, 1, 1, 1);
                image.sprite = Resources.Load<Sprite>("Clear");


            }
        }
    }

}
