using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickedup : MonoBehaviour
{
    public OrderManager orderManager;
    
    public GameObject PickedUpOrder;

    private Coroutine co;
    void Start ()
    {
    }
    
    public void ShowPickedUp(int index)
    {
        if (OrderManager.orders[index].IsPickedUp())
        {
            if(co!=null)
            {
                StopCoroutine(co);
            }
            PickedUpOrder.SetActive(true);
            co = StartCoroutine(HidePopUpPickup(5));
        }
        //if (OrderManager.orders[index].IsOrderCompleted())
        //{
        //    OrderText.SetActive(false);
        //}
    }
    void Update()
    {
    }
    IEnumerator HidePopUpPickup(float sec)
    {
        yield return new WaitForSeconds(sec);
        PickedUpOrder.SetActive(false);
    }

    



}
