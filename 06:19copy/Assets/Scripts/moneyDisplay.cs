using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moneyDisplay : MonoBehaviour
{
    public OrderManager orderManager;
  //  public static Order[] orders;

    [SerializeField] Text moneyText;

    // Update is called once per frame
    void Update()
    {
        moneyText.text = OrderManager.totalMoney.ToString();
    }
}
