using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetStatus : MonoBehaviour
{
    public float HumanCounter = 50;
    public float WaterCounter = 50;
    public float ForestCounter = 50;
    public float AnimalCounter = 50;
    public float AirCounter = 50;
    public float CorruptionCounter = 50;

    public float TotalPlanetHealth;

    public GameObject HumanSlider;
    public GameObject WaterSlider;
    public GameObject ForestSlider;
    public GameObject AnimalSlider;
    public GameObject AirSlider;
    public GameObject CorruptionSlider;

    public GameObject TotalSlider;

    public List<GameObject> SliderList;

    Color defaultColor;

    public List<GameObject> HumanGroups;
    public List<GameObject> ForestGroups;
    public List<GameObject> AnimalGroups;

    

    // Start is called before the first frame update
    void Start()
    {
        defaultColor = HumanSlider.transform.GetChild(0).GetComponentInChildren<Image>().color;
        AddStartingValues();
    }

    // Update is called once per frame
    void Update()
    {
        RemoveNullValues();
        CheckPlanetHealth();
    }

    void AddStartingValues()
    {
        //Plants
        foreach (GameObject t in GameObject.FindGameObjectsWithTag("Tree"))
        {
            ForestGroups.Add(t);
        }
    }

    void RemoveNullValues()
    {
        HumanGroups.RemoveAll(x => x == null);
        ForestGroups.RemoveAll(x => x == null);
        AnimalGroups.RemoveAll(x => x == null);
    }

    void CheckPlanetHealth()
    {
        HumanCounter = HumanGroups.Count * 3;
        ForestCounter = ForestGroups.Count / 2f;
        AnimalCounter = AnimalGroups.Count * 2;

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

        foreach (GameObject s in SliderList)
        {
            if(s.GetComponent<Slider>().value <= .15f || s.GetComponent<Slider>().value >= .85f)
            {
                s.transform.GetChild(0).GetComponentInChildren<Image>().color = Color.red;
            }
            else if(s.GetComponent<Slider>().value <= .25f || s.GetComponent<Slider>().value >= .75f)
            {
                s.transform.GetChild(0).GetComponentInChildren<Image>().color = Color.yellow;
            }
            else
            {
                s.transform.GetChild(0).GetComponentInChildren<Image>().color = defaultColor;
            }
        }
        
    }
}
