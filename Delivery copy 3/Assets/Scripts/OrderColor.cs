using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderColor : MonoBehaviour
{
    public OrderManager orderManager;
    public GameObject orderColorFrom;
    public GameObject orderColorTo;

    public void ShowColor(int index) {
        if (OrderManager.orders[index].IsPickedUp())
        {
            orderColorFrom.SetActive(true);
            orderColorTo.SetActive(true);
        }
    }

    public void CloseColor(int index) {
        if (OrderManager.orders[index].IsOrderCompleted())
        {
            orderColorFrom.SetActive(false);
            orderColorTo.SetActive(false);
        }
    }
}
