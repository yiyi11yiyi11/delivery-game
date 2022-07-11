using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class delivered : MonoBehaviour
{
    public OrderManager orderManager;
    
    public GameObject DeliveredOrder;

    private Coroutine co;
    void Start ()
    {
    }
    
    public void ShowDelivered(int index)
    {
        if (OrderManager.orders[index].IsOrderCompleted())
        {
            if(co!=null)
            {
                StopCoroutine(co);
            }
            DeliveredOrder.SetActive(true);
            co = StartCoroutine(HidePopUpDelivery(5));
        }
        //if (OrderManager.orders[index].IsOrderCompleted())
        //{
        //    OrderText.SetActive(false);
        //}
    }
    void Update()
    {
    }
    IEnumerator HidePopUpDelivery(float sec)
    {
        yield return new WaitForSeconds(sec);
        DeliveredOrder.SetActive(false);
    }

    



}
