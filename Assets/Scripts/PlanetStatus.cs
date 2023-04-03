using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetStatus : MonoBehaviour
{
    float HumanCounter = 50;
    float WaterCounter = 50;
    float ForestCounter = 50;
    float AnimalCounter = 50;
    float AirCounter = 50;
    float CorruptionCounter = 50;

    float TotalPlanetHealth;

    public GameObject HumanSlider;
    public GameObject WaterSlider;
    public GameObject ForestSlider;
    public GameObject AnimalSlider;
    public GameObject AirSlider;
    public GameObject CorruptionSlider;

    public GameObject TotalSlider;


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
        SlidersUpdate();
    }

    void SlidersUpdate()
    {
        HumanSlider.GetComponent<Slider>().value = HumanCounter/100;
        WaterSlider.GetComponent<Slider>().value = WaterCounter/100;
        ForestSlider.GetComponent<Slider>().value = ForestCounter/100;
        AnimalSlider.GetComponent<Slider>().value = AnimalCounter/100;
        AirSlider.GetComponent<Slider>().value = AirCounter/100;
        CorruptionSlider.GetComponent<Slider>().value = CorruptionCounter/100;

        TotalSlider.GetComponent<Slider>().value = TotalPlanetHealth/100;
        
    }
}
