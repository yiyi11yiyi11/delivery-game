using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class orderDisplayWindow : MonoBehaviour
{
    public GameObject window;
    public void OnBtnCloseClick() {
        window.SetActive(false);
    }
}
