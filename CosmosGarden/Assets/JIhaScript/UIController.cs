using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject[] UIWindow = new GameObject[6];
    // Start is called before the first frame update
    void Start()
    {
        AllOff();
    }

    // Update is called once per frame
    public void AllOff()
    {
        for(int i = 0; i < UIWindow.Length - 1; i++)
        {
            UIWindow[i].SetActive(false);
        }
    }

    public void UIOff(int UIIndex)
    {
        UIWindow[UIIndex].SetActive(false);
    }
    public void UIOn(int UIIndex)
    {
        UIWindow[UIIndex].SetActive(true);
    }
}
