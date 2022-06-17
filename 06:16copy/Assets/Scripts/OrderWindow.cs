using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderWindow : MonoBehaviour
{
    public OrderManager orderManager;

    public Text nameText;
    public Text addressFromText;
    public Text addressToText;
    public Text numberText;
    public Text rewardText;
    public Text timeText;
    
    public GameObject OrderText;

    void Start ()
    {
        OrderText.SetActive(false);
    }

    void Update()
    {
        for (int i = 0; i < OrderManager.currentOrderNum; i++) 
        {
            if(OrderManager.orders[i].IsOrderActive())
            {
                nameText.text = OrderManager.orders[i].orderName;
                addressFromText.text = OrderManager.orders[i].orderAddressFrom;
                addressToText.text = OrderManager.orders[i].orderAddressTo;
                numberText.text = "Order #" + OrderManager.orders[i].orderNumber.ToString();
                rewardText.text = "Earning: $" + OrderManager.orders[i].orderReward.ToString();
                timeText.text = "Time: " + OrderManager.orders[i].currentRemainTIme.ToString("#0") + " seconds";

                OrderText.SetActive(true);
            }

            if (OrderManager.orders[i].IsOrderCompleted()) 
            {
                OrderText.SetActive(false);
            }

        }
    }

    



}
