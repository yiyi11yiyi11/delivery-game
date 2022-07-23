using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderColorManager : MonoBehaviour
{
    public OrderColor[] colors;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowOrderColor(int index)
    {
        colors[index].ShowColor(index);
    }

    public void CloseOrderColor(int index)
    {
        colors[index].CloseColor(index);
    }
}
