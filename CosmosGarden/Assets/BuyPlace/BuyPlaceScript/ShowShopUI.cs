using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowShopUI : MonoBehaviour
{
    [SerializeField] GameObject ShopUI;
    private bool state;
    private void Start()
    {
        state = false;
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && state)
        {
            ShopUI.SetActive(false);
            state = false;
        }
    }
    public void OnClickShopButton()
    {
        if(!state)
        {
            ShopUI.SetActive(true);
            state = true;
        }
        /*else
        {
            ShopUI.SetActive(false);
        }*/
    }
}
