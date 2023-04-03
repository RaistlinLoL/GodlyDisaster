using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetStatus : MonoBehaviour
{
    float HumanCounter = 50;
    float WaterCounter = 50;
    float ForestCounter = 50;
    float AnimalCounter = 50;
    float AirCounter = 50;
    float CorruptionCounter = 50;

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
        CheckPlanetHealth();
    }

    void CheckPlanetHealth()
    {
        TotalPlanetHealth = (HumanCounter + WaterCounter + ForestCounter +
            AnimalCounter + AirCounter + CorruptionCounter) / 6;
    }
}
