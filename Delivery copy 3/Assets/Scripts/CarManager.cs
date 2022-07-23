using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public GameObject[] carsPrefab;
    public GameObject startPositions;
    public GameObject endPositions;
    public float secondsBetweenGenerateCarLow;
    public float secondsBetweenGenerateCarHigh;
    public float minSpeed;
    public float maxSpeed;
    private float timer;
    private float randomTime;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        randomTime = Random.Range(secondsBetweenGenerateCarLow, secondsBetweenGenerateCarHigh);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>= randomTime)
        {
            int index = Random.Range(0, carsPrefab.Length);
            GameObject newcar = Instantiate(carsPrefab[index]);
            newcar.transform.position = startPositions.transform.position;
            newcar.GetComponent<Car>().speed = Random.Range(minSpeed, maxSpeed);
            newcar.GetComponent<Car>().endPosition = endPositions.transform.position;
            timer = 0;
            randomTime = Random.Range(secondsBetweenGenerateCarLow, secondsBetweenGenerateCarHigh);

        }
    }
}