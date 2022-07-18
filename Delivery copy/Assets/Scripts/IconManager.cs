using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconManager : MonoBehaviour
{
    public orderIcon[] icons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowOrderIcon(int index)
    {
        icons[index].ShowIcon(index);
    }

    public void CloseOrderIcon(int index)
    {
        icons[index].CloseIcon(index);
    }
}
