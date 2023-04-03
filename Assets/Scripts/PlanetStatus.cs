using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetStatus : MonoBehaviour
{
    float HumanCounter;
    float WaterCounter;
    float ForestCounter;
    float AnimalCounter;
    float AirCounter;
    float CorruptionCounter;

    float TotalPlanetHealth;

    List<GameObject> HumanGroups;
    List<GameObject> WaterGroups;
    List<GameObject> ForestGroups;
    List<GameObject> AnimalGroups;
    List<GameObject> AirGroups;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckPlanetHealth()
    {
        TotalPlanetHealth = (HumanCounter + WaterCounter + ForestCounter +
            AnimalCounter + AirCounter + CorruptionCounter) / 6;
    }
}
