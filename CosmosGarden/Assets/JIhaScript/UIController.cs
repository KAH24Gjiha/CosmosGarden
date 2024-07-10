using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject[] UIWindow;
    // Start is called before the first frame update
    void Start()
    {
        UIOff();
    }

    // Update is called once per frame
    public void UIOff()
    {
        for(int i = 0; i < UIWindow.Length; i++)
        {
            UIWindow[i].SetActive(false);
        }
    }
}
