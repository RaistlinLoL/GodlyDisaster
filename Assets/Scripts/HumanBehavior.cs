using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    
    Vector3 targetPos;
    public PlanetStatus PS;
    int randTargetIndex;


    Vector3 pos = Vector3.zero;
    float timerToFindNewTarget = 0;
    [SerializeField] int maxTimerToFindNewTarget = 3;

    /*[SerializeField] bool isHuman;
    
    [SerializeField] bool isLion;

    [SerializeField] bool isChicken;
    [SerializeField] bool isWolf;*/
    enum CreatureType
    {
        Human,
        Lion,
        Chicken,
        Wolf
    }
    [SerializeField] CreatureType whatCreature;
    
    bool hasCaughtAnimal;


    void Start()
    {
        targetPos = transform.position;
        PS = GameObject.Find("PlanetStatus").GetComponent<PlanetStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        //Patrolling
        //transform.position += transform.forward * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetPos) < 10)
        {
            randTargetIndex = Random.Range(0,PS.ForestGroups.Count -1);
            targetPos = PS.ForestGroups[randTargetIndex].transform.position;
        }

        findTarget();



    }

    void findTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        
        transform.LookAt( transform.forward, transform.up);
        
    }

    void cutTreeDown(GameObject tree)
    {
        Destroy(tree);
        print("i cut down a tree");
    }
    void huntAnimal(GameObject animal, bool hasCaughtAnimal)
    {
        targetPos = animal.transform.position;
        if (hasCaughtAnimal)
        {
            Destroy(animal);
            hasCaughtAnimal = false;
            print("animal Has been hunted");
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            transform.LookAt( transform.forward, transform.up);
        }
    }
    private void OnTriggerStay(Collider other) {
       
        if (other.gameObject.tag == "PlanetMoment")
        {
            if (Vector3.Distance(other.gameObject.transform.position, transform.position) < 5)
            {
                randTargetIndex = Random.Range(0,PS.ForestGroups.Count -1); 
                targetPos = PS.ForestGroups[randTargetIndex].transform.position;
            }
            
                     
        }
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Chicken" || other.gameObject.tag == "Wolf")
        {
           hasCaughtAnimal = true;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (whatCreature == CreatureType.Human)
        {
            if (other.gameObject.tag == "Chicken" || other.gameObject.tag == "Wolf")
            {
                huntAnimal(other.gameObject, hasCaughtAnimal);
                print("iam hunting an animal");
            }

            if (other.gameObject.layer == 7)
            {
                targetPos = other.gameObject.transform.position;
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
                transform.LookAt( transform.forward, transform.up);
                if (Vector3.Distance(transform.position, other.transform.position) < 10)
                {
                    cutTreeDown(other.gameObject);
                    print("i have cut down a tree");
                }
            }

        }
        
        

    }
}
