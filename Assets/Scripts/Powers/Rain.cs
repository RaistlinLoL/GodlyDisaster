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

    }

    private void FixedUpdate()
    {
        PS.WaterCounter += .1f;
        if (PS.WaterCounter > 100)
        {
            PS.WaterCounter = 100;
        }
    }
}
