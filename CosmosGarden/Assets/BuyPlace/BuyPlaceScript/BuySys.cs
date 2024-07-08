using UnityEngine;

public class BuySys : MonoBehaviour
{
    public static int money { get; private set; }
    public void Start()
    {
        money = 200;
    }
    public static void Buy(int cost)
    {

        if (cost > money)
        {
            Debug.Log("재화 부족");
            return;
        }
        money -= cost;
        Debug.Log(money);
    }
}