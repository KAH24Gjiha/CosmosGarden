using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinUpdate : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        this.gameObject.GetComponent<TMP_Text>().text = DataManager.Instance.gameData.Coin.ToString();
    }
}
