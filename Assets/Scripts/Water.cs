using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    float startingWaterLevel;
    float currentWaterLevel;

    public PlanetStatus PS;
    // Start is called before the first frame update
    void Start()
    {
        startingWaterLevel = transform.localScale.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.eulerAngles += new Vector3(1, 1, 1) * Time.deltaTime;

        currentWaterLevel = startingWaterLevel + (PS.WaterCounter / 10);
        transform.localScale = new Vector3(currentWaterLevel, currentWaterLevel, currentWaterLevel);
    }
}
