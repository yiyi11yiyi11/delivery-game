using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderWindow : MonoBehaviour
{
    public OrderManager orderManager;
    //public OrderColorManager colorManager;

    public Text nameText;
    public Text addressFromText;
    public Text addressToText;
    public Text numberText;
    public Text rewardText;
    public Text timeText;
    
    public GameObject OrderText;
    private int currentOrderIndex = 0;

    void Start ()
    {
        OrderText.SetActive(false);
        ShowOrder(currentOrderIndex);
    }
    public void ShowNextOrder()
    {
        if (OrderManager.GetActiveOrderNumber() <= 1 ) return;
        currentOrderIndex++;
        if (currentOrderIndex >= OrderManager.currentOrderNum) currentOrderIndex = 0;
        while (!OrderManager.orders[currentOrderIndex].IsOrderActive())
        {
            currentOrderIndex++;
            if (currentOrderIndex >= OrderManager.currentOrderNum) currentOrderIndex = 0;
        }
        ShowOrder(currentOrderIndex);
    }
    public void ShowOrder(int index)
    {
        if (index >= OrderManager.currentOrderNum) return;

        if (OrderManager.orders[index].IsOrderActive())
        {
            nameText.text = OrderManager.orders[index].orderName;
            addressFromText.text = OrderManager.orders[index].orderAddressFrom;
            addressToText.text = OrderManager.orders[index].orderAddressTo;
            numberText.text = "Order #" + OrderManager.orders[index].orderNumber.ToString();
            rewardText.text = "$" + OrderManager.orders[index].orderReward.ToString();
            timeText.text = OrderManager.orders[index].currentRemainTIme.ToString("#0");

            //colorManager.ShowOrderColor(index);

            OrderText.SetActive(true);
        }

        //if (OrderManager.orders[index].IsOrderCompleted())
        //{
        //    OrderText.SetActive(false);
        //}
    }
    void Update()
    {
        ShowOrder(currentOrderIndex);
    }

    



}
