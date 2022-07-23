using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class orderIcon : MonoBehaviour
{
    public OrderManager orderManager;
    public GameObject orderIconFrom;
    public GameObject orderIconTo;

    public void ShowIcon(int index) {
        if (OrderManager.orders[index].IsPickedUp())
        {
            orderIconFrom.SetActive(true);
            orderIconTo.SetActive(true);
        }
    }

    public void CloseIcon(int index) {
        if (OrderManager.orders[index].IsOrderCompleted())
        {
            orderIconFrom.SetActive(false);
            orderIconTo.SetActive(false);
        }
    }
}
