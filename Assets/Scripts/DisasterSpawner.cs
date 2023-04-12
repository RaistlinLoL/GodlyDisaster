using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisasterSpawner : MonoBehaviour
{
    PlanetStatus PS;
    bool disasterTriggered;

    // Start is called before the first frame update
    void Start()
    {
        PS = GameObject.Find("PlanetStatus").GetComponent<PlanetStatus>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool eventOccured = false;
        //Checks if value is too high/low
        if ((PS.HumanCounter >= 85 || PS.HumanCounter <= 15) && !disasterTriggered)
        {

        }
        if ((PS.WaterCounter >= 85 || PS.WaterCounter <= 15) && !disasterTriggered)
        {

        }
        if ((PS.ForestCounter >= 85 || PS.ForestCounter <= 15) && !disasterTriggered)
        {

        }
        if ((PS.AnimalCounter >= 85 || PS.AnimalCounter <= 15) && !disasterTriggered)
        {

        }
        if ((PS.AirCounter >= 85 || PS.AirCounter <= 15) && !disasterTriggered)
        {

        }
        if ((PS.CorruptionCounter >= 85 || PS.CorruptionCounter <= 15) && !disasterTriggered)
        {

        }


        if(eventOccured)
        {
            disasterTriggered = true;
            Invoke("ResetDisasterTimer", 15);
        }
    }

    void ResetDisasterTimer()
    {
        disasterTriggered = false;
    }
}
