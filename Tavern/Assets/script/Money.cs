using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Money : MonoBehaviour
{

    private int money;

    void Start()
    {
        money = 0;
    }

    void Update()
    {

    }

    public void Moneypurasu(int value)
    {
        money += value;

        var text = GameObject.Find("money").GetComponent<Text>().text = money.ToString();
    }

    public int GetMoney()
    {
        return money;
    }
}
