using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newOrderPopUp : MonoBehaviour
{
    public OrderManager orderManager;
    
    public GameObject NewOrder;

    private Coroutine co;
    void Start ()
    {
    }
    
    public void ShowNewOrder(int index)
    {
        if (OrderManager.orders[index].IsOrderActive())
        {
            if(co!=null)
            {
                StopCoroutine(co);
            }
            NewOrder.SetActive(true);
            co = StartCoroutine(HidePopUp(5));
        }
        //if (OrderManager.orders[index].IsOrderCompleted())
        //{
        //    OrderText.SetActive(false);
        //}
    }
    void Update()
    {
    }
    IEnumerator HidePopUp(float sec)
    {
        yield return new WaitForSeconds(sec);
        NewOrder.SetActive(false);
    }

    



}
