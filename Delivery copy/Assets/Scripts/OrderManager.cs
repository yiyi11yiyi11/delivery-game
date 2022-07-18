using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public static int totalMoney;    

    public static Order[] orders;

    public static int currentOrderNum = 0;

    //public GameObject OrderWindow;

    //public Canvas canvas;

    public Vector3[] AddressPositions;
    public Transform PlayerPosition;
    public int adjustAmount = 2; // Player's position vs. address position
    public bool[] isArrived;
    public bool[] onTheWay;
    public newOrderPopUp popUpManager;
    public pickedup pickUpManager;
    public delivered deliverManager;
    public orderIcon iconManager;

    private void Awake()
    {
        orders = new Order[10];
        isArrived = new bool[10];
        onTheWay = new bool[10];
    }
    void Start()
    {
        AddressPositions = new Vector3[10];
        for(int i = 0;i< currentOrderNum;i++)
        {
            AddressPositions[i] = orders[i].startLocation.transform.position;
        }
    }


    public static void AddOrderToManager(Order order)
    {
        orders[currentOrderNum] = order;
        currentOrderNum++;
    }

    public static int GetOrderNumber()
    {
        return currentOrderNum;
    }

    public static int GetActiveOrderNumber()
    {
        int count = 0;
        for(int i = 0;i< currentOrderNum;i++)
        {
            if (orders[i].IsOrderActive()) count++;
        }
        return count;
    }

    public static bool IsAllOrderCompleted()
    {
        bool result = true;
        for (int i = 0; i < currentOrderNum; i++)
        {
            if (!orders[i].IsOrderCompleted())
            {
                result = false;
            }
        }
        return result;
    }

    private void Update()
    {
        //this block codes are for active orders
        for(int i = 0;i< currentOrderNum;i++)
        {
            if (orders[i].IsOrderActive() || orders[i].IsOrderCompleted()) continue;
            if(Time.time>=orders[i].startTime)
            {
                orders[i].HandleOrderStart();
                popUpManager.ShowNewOrder(i);
                iconManager.ShowIcon(i);
              //GameObject obj = Instantiate(OrderWindow, canvas.transform);
              //obj.GetComponent<OrderWindow>().OpenOrderWindow(orders[i]);
            }
        }

        for(int i = 0;i< currentOrderNum; i++)
        {
            if(Vector3.Distance(PlayerPosition.position,AddressPositions[i])<= adjustAmount)
            {
                isArrived[i] = true;

            }
        }

        for (int i = 0; i < currentOrderNum;i++) 
        {
            if (isArrived[i] && !orders[i].IsArrivedRestaurant()) {
                //picked up
                orders[i].HandleOrderPickedup();
                pickUpManager.ShowPickedUp(i);
                AddressPositions[i] = orders[i].endLocation.transform.position;
                isArrived[i] = false;
                onTheWay[i] = true;
            }
        }

        for (int i = 0; i < currentOrderNum; i++)
        {
            if (isArrived[i] && orders[i].IsArrivedRestaurant())
            {
                //picked up
                orders[i].HandleOrderComplete();
                deliverManager.ShowDelivered(i);
                iconManager.CloseIcon(i);
                isArrived[i] = true;
                onTheWay[i] = false;
            }
        }

        if (IsAllOrderCompleted())
        {
            print("All order completed");
        }

    }

    public static void HandleOrderComplete(int orderNumber)
    {
        for (int i = 0; i < currentOrderNum; i++)
        {
            if(orders[i].orderNumber == orderNumber)
            {
                if(!orders[i].IsOrderActive())
                {
                    print("WARNING! ORDER IS NOT ACTIVE, BUT TRYING TO COMPLETE IT" + orderNumber);
                }
                else
                {
                    orders[i].HandleOrderComplete();
                    totalMoney += orders[i].orderReward;
                }
            }
        }
    }
   
}