using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smite : MonoBehaviour
{
    public PlanetStatus PS;
    // Start is called before the first frame update
    void Start()
    {
        PS = GameObject.Find("PlanetStatus").GetComponent<PlanetStatus>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Destroy Plant
        if (collision.gameObject.tag == "PlanetMoment")
        {
            ReduceCorruption(2);
            Destroy(collision.gameObject);
        }
        //Destroy Human
        if (collision.gameObject.tag == "Human")
        {
            ReduceCorruption(2);
            Destroy(collision.gameObject);
        }
        //Destroy Animal
        if (collision.gameObject.tag == "Lion" || collision.gameObject.tag == "Chicken" || collision.gameObject.tag == "Wolf")
        {
            ReduceCorruption(2);
            Destroy(collision.gameObject);
        }
    }

    void ReduceCorruption(float i)
    {
        
        PS.CorruptionCounter -= i;
        if (PS.CorruptionCounter < 0)
        {
            PS.CorruptionCounter = 0;
        }
    }
}
