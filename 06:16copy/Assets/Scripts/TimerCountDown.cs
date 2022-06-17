using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountDown : MonoBehaviour
{
    public OrderManager orderManager;
   // public static Order[] orders;

    [SerializeField] float startTime;
    float currentTime;
    bool timerStarted = false;
    [SerializeField] Text timerText;

    void Start()
    {
        currentTime = startTime;
        timerText.text = currentTime.ToString();
    }
    void Update()
    {
        for (int i = 0; i < OrderManager.currentOrderNum; i++) 
        {
            if(OrderManager.orders[i].IsOrderActive())
            {
                timerStarted = true;
            }
            if (timerStarted) 
            {
                timerText.text = OrderManager.orders[i].currentRemainTIme.ToString("#0");
            }

        }

    }
}