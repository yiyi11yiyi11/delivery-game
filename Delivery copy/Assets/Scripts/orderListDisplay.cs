using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class orderListDisplay : MonoBehaviour
{
    public GameObject orderDisplay;
    public void OnBtnShowClick() 
    {
       // UIManager.Instance.ShowPanel("orderDisplay");
        orderDisplay.SetActive(true);
    }
}
