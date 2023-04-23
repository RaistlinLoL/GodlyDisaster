using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Love : MonoBehaviour
{
    public PlanetStatus PS;
    int createdEntities = 0;

    bool loveActive = true;

    // Start is called before the first frame update
    void Start()
    {
        PS = GameObject.Find("PlanetStatus").GetComponent<PlanetStatus>();
        StartCoroutine(LoveCooldown());
    }

    private void OnTriggerStay(Collider collision)
    {
        if((collision.gameObject.tag == "Human"|| collision.gameObject.tag == "Lion" 
            || collision.gameObject.tag == "Chicken" || collision.gameObject.tag == "Wolf") 
            && createdEntities < 2 && loveActive)
        {
            loveActive = false;
            Instantiate(collision.gameObject, collision.transform.position, Quaternion.identity);

            createdEntities++;

            PS.CorruptionCounter -= 2;
            if (PS.CorruptionCounter < 0)
            {
                PS.CorruptionCounter = 0;
            }
        }
    }

    IEnumerator LoveCooldown()
    {
        while (true)
        {
            createdEntities = 0;
            loveActive = true;
            yield return new WaitForSeconds(1);
        }
    }
}
