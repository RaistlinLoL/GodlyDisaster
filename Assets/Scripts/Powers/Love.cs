using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Love : MonoBehaviour
{
    public PlanetStatus PS;
    int createdEntities = 0;

    public Transform HumanParent;
    public Transform LionParent;
    public Transform ChickenParent;
    public Transform WolfParent;
    // Start is called before the first frame update
    void Start()
    {
        PS = GameObject.Find("PlanetStatus").GetComponent<PlanetStatus>();
        HumanParent = GameObject.Find("Humans").transform;
        LionParent = GameObject.Find("Lions").transform;
        ChickenParent = GameObject.Find("Chickens").transform;
        WolfParent = GameObject.Find("Wolves").transform;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Human" && createdEntities < 3)
        {
            GameObject CreatedAnimal = Instantiate(collision.gameObject, collision.transform.position, Quaternion.identity);
            CreatedAnimal.transform.SetParent(HumanParent);
            PS.HumanGroups.Add(CreatedAnimal);

            UniversalChanges(2);
        }

        if(collision.gameObject.tag == "Lion" && createdEntities < 3)
        {
            GameObject CreatedAnimal = Instantiate(collision.gameObject, collision.transform.position, Quaternion.identity);
            CreatedAnimal.transform.SetParent(LionParent);
            PS.AnimalGroups.Add(CreatedAnimal);

            UniversalChanges(2);
        }

        if(collision.gameObject.tag == "Chicken" && createdEntities < 3)
        {
            GameObject CreatedAnimal = Instantiate(collision.gameObject, collision.transform.position, Quaternion.identity);
            CreatedAnimal.transform.SetParent(ChickenParent);
            PS.AnimalGroups.Add(CreatedAnimal);

            UniversalChanges(2);
        }

        if(collision.gameObject.tag == "Wolf" && createdEntities < 3)
        {
            GameObject CreatedAnimal = Instantiate(collision.gameObject, collision.transform.position, Quaternion.identity);
            CreatedAnimal.transform.SetParent(WolfParent);
            PS.AnimalGroups.Add(CreatedAnimal);

            UniversalChanges(2);
        }
    }

    void UniversalChanges(int i)
    {
        createdEntities++;

        PS.CorruptionCounter -= i;
        if (PS.CorruptionCounter < 0)
        {
            PS.CorruptionCounter = 0;
        }
    }
}
