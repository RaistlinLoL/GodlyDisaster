using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTargets : MonoBehaviour
{
    public GameObject[] targets = new GameObject[1482];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targets = GameObject.FindGameObjectsWithTag("PlanetMoment");
    }
}
