using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisasterSpawner : MonoBehaviour
{
    PlanetStatus PS;
    bool disasterTriggered;
    public GameObject Disaster1;
    int rng;
    public Vector3 SpawnLoc;
    bool eventOccured = false;
    public GameObject PlanetCenter;

    // Start is called before the first frame update
    void Start()
    {
        PS = GameObject.Find("PlanetStatus").GetComponent<PlanetStatus>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Checks if value is too high/low
        if ((PS.HumanCounter >= 85 || PS.HumanCounter <= 15) && !disasterTriggered)
        {
            FindSpawnLoc();
            Instantiate(Disaster1, SpawnLoc, Quaternion.identity);
            eventOccured = true;
        }
        if ((PS.WaterCounter >= 85 || PS.WaterCounter <= 15) && !disasterTriggered)
        {
            FindSpawnLoc();
            Instantiate(Disaster1, SpawnLoc, Quaternion.identity);
            eventOccured = true;
        }
        if ((PS.ForestCounter >= 85 || PS.ForestCounter <= 15) && !disasterTriggered)
        {
            FindSpawnLoc();
            Instantiate(Disaster1, SpawnLoc, Quaternion.identity);
            eventOccured = true;
        }
        if ((PS.AnimalCounter >= 85 || PS.AnimalCounter <= 15) && !disasterTriggered)
        {
            FindSpawnLoc();
            Instantiate(Disaster1, SpawnLoc, Quaternion.identity);
            eventOccured = true;
        }
        if ((PS.AirCounter >= 85 || PS.AirCounter <= 15) && !disasterTriggered)
        {
            FindSpawnLoc();
            Instantiate(Disaster1, SpawnLoc, Quaternion.identity);
            eventOccured = true;
        }
        if ((PS.CorruptionCounter >= 85 || PS.CorruptionCounter <= 15) && !disasterTriggered)
        {
            FindSpawnLoc();
            Instantiate(Disaster1, SpawnLoc, Quaternion.identity);
            eventOccured = true;
        }


        if(eventOccured && !disasterTriggered)
        {
            disasterTriggered = true;
            Invoke("ResetDisasterTimer", 15);
        }
    }

    void FindSpawnLoc()
    {
        if(PS.ForestGroups.Count != 0)
        {
            rng = Random.Range(0, PS.ForestGroups.Count - 1);

            SpawnLoc = PS.ForestGroups[rng].transform.position;

            Vector3 awayDirection = SpawnLoc - PlanetCenter.transform.position;
            awayDirection.Normalize();

            SpawnLoc += awayDirection * 20;
        }
        
    }
    void ResetDisasterTimer()
    {
        disasterTriggered = false;
        eventOccured = false;
    }
}
