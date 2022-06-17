using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Order: MonoBehaviour
{
    public enum OrderStatus
    {
        NOT_STARTED,
        HEADING_TO_RESTAURANT,
        PICKED_UP,
        NOT_DELIVERED,
        DELIVERED_NOT_ON_TIME,
        DELIVERED_ON_TIME,
    }
    public string orderName;
    public string orderAddressFrom;
    public string orderAddressTo;
    public int orderNumber;
    public int orderReward;
    public float orderTime;
    public float startTime;
    public float currentRemainTIme;

    public GameObject startLocation;
    public GameObject endLocation;
    public GameObject playerCurrent;


    private float timer = 0;

    public OrderStatus Status;

    private void Awake()
    {
        OrderManager.AddOrderToManager(this);
    }
    private void Update()
    {
        if(IsOrderActive())
        {
            timer += Time.deltaTime;
            currentRemainTIme = orderTime - timer;
            if (currentRemainTIme < 0) {
                currentRemainTIme = 0;
            }
        }
    }

    public bool IsOrderStarted()
    {
        return Status >= OrderStatus.HEADING_TO_RESTAURANT;
    }

    public bool IsOrderActive()
    {
        return IsOrderStarted() && !IsOrderCompleted();
    }

    public bool IsArrivedRestaurant() 
    {
        return Status >= OrderStatus.PICKED_UP;
    }

    public bool IsPickedUp() 
    {
        return Status >= OrderStatus.PICKED_UP;
    }

    public bool IsOrderCompleted()
    {
        return Status >= OrderStatus.NOT_DELIVERED;
    }

    public void HandleOrderStart()
    {
        Status = OrderStatus.HEADING_TO_RESTAURANT;
        print("order:"+this.orderNumber+" is Activated");
    }

    public void HandleOrderPickedup()
    {
        Status = OrderStatus.PICKED_UP;
        print("order:" + this.orderNumber + " is Pickedup");
    }		    

    public void HandleOrderComplete() 
    {
        if(IsOrderCompleted()) return;
        Debug.Log(orderName + "complete.");
        print("Used Time:" + timer);
        if(timer <= orderTime)
        {
            Status = OrderStatus.DELIVERED_ON_TIME;
            OrderManager.totalMoney += orderReward;
        }
        else
        {
            Status = OrderStatus.DELIVERED_NOT_ON_TIME;
        }
    }
}
