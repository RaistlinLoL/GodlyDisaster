using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Love : MonoBehaviour
{
    public PlanetStatus PS;
    int createdEntities = 0;

    // Start is called before the first frame update
    void Start()
    {
        PS = GameObject.Find("PlanetStatus").GetComponent<PlanetStatus>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if((collision.gameObject.tag == "Human"|| collision.gameObject.tag == "Lion" 
            || collision.gameObject.tag == "Chicken" || collision.gameObject.tag == "Wolf") 
            && createdEntities < 3)
        {
            Instantiate(collision.gameObject, collision.transform.position, Quaternion.identity);

            createdEntities++;

            PS.CorruptionCounter -= 2;
            if (PS.CorruptionCounter < 0)
            {
                PS.CorruptionCounter = 0;
            }
        }
    }
}
