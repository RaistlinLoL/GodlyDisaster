using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public PlanetStatus PS;

    [SerializeField] float airToReproduce;
    [SerializeField] float airProductionTimer;
    private float counterToProduceAir = 0;
    
    void Start()
    {
        PS = GameObject.Find("PlanetStatus").GetComponent<PlanetStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        counterToProduceAir += Time.deltaTime;

        if (counterToProduceAir >= airProductionTimer)
        {
            PS.AirCounter += airToReproduce;
            counterToProduceAir = 0;
        }
    }
}
