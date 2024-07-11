using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSpawn : MonoBehaviour
{
    public GameObject character;
    public Transform parent;

    public GameObject Button;

    public int price;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void Spawn()
    {
        if(isbuy())
        {
            DataManager.Instance.gameData.Coin -= price;
            Instantiate(character, new Vector3(0, -8, -10), Quaternion.Euler(0, 0, 0), parent);
        }
        
    }
    public bool isbuy()
    {
        if (DataManager.Instance.gameData.Coin >= price)
        {
            Button.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            return true;
        }
        else
        {
            Button.GetComponent<Image>().color = new Color(0.7f, 0.7f, 0.7f, 1);
            return false;
        }
    }

}
