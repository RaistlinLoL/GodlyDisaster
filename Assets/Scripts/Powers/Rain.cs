using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public PlanetStatus PS;
    // Start is called before the first frame update
    void Start()
    {
        PS = GameObject.Find("PlanetStatus").GetComponent<PlanetStatus>();

        PS.WaterCounter += 10;
        if (PS.WaterCounter > 100)
        {
            PS.WaterCounter = 100;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {

    }
}
