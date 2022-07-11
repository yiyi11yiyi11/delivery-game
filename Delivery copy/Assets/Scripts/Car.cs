using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Vector3 endPosition;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, endPosition, speed*Time.deltaTime );
        this.transform.LookAt(endPosition);
        if(Vector3.Distance(this.transform.position,endPosition) <= 5)
        {
            Destroy(this.gameObject);
        }
    }
}