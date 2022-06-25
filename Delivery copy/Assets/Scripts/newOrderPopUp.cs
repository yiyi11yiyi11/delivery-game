using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newOrderPopUp : MonoBehaviour
{
    public OrderManager orderManager;
    
    public GameObject NewOrder;
    private int currentOrderIndex = 0;

    void Start ()
    {
        //NewOrder.SetActive(false);
        ShowNewOrder(currentOrderIndex);
    }
    
    public void ShowNewOrder(int index)
    {
        if (index >= OrderManager.currentOrderNum) return;

        if (OrderManager.orders[index].IsOrderActive())
        {
            NewOrder.SetActive(true);
        }
        

        

        //if (OrderManager.orders[index].IsOrderCompleted())
        //{
        //    OrderText.SetActive(false);
        //}
    }
    void Update()
    {
        ShowNewOrder(currentOrderIndex);
    }

    



}
