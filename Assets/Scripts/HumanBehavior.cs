using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    
    [SerializeField]Vector3 targetPos;
    public PlanetStatus PS;
    int randTargetIndex;


    Vector3 pos = Vector3.zero;
    float timerToFindNewTarget = 0;
    [SerializeField] int maxTimerToFindNewTarget = 3;

    //values that determin the creaturs actions
    [SerializeField]private float hunger = .75f;
    [SerializeField]private float thirst = .75f;
    [SerializeField]private float oxygenLevel = .75f;

    //human specific values
    [SerializeField]private int woodSupply = 6;
    [SerializeField]private float waterSupply = .25f;


    //stat decrement timer
    [SerializeField]private float consumeMax = 5;
    [SerializeField]private float timerToConsume = 0;

    //consumption rates
    [SerializeField]private float thirstConsumeRate = .001f;
    [SerializeField]private float hungerConsumeRate = .001f;
    [SerializeField]private float oxygenConsumeRate = .08f;
    //human specific consumption rates
    [SerializeField] private int woodConsumptionRate = 1;
    

    //stat regeneration rate
    float thirstRegenRate = 1f;
    float hungerRegenRate = 1.0f;
    float oxygenRegenRate = .16f;
    //human specific regen rate
    int woodRegenRate = 5;

    bool isDoingSomething;


    float patrollingTimer;

    List<GameObject> chickens = new List<GameObject>();
    List<GameObject> wolfs = new List<GameObject>();
    List<GameObject> Humans = new List<GameObject>();
    List<GameObject> Lions = new List<GameObject>();
    bool patrolDoOnce = true;
    bool findAnimalDoOnce = true;
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

    enum state
    {
        paptrolling,
        hunting,
        findingWater,
        findingWood,
    }

    [SerializeField] private state whatIsState;
    void Start()
    {
        targetPos = transform.position;
        PS = GameObject.Find("PlanetStatus").GetComponent<PlanetStatus>();

        isDoingSomething = false;

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Chicken").Length; i++)
        {
            chickens.Add(GameObject.FindGameObjectsWithTag("Chicken")[i]);
        }
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Wolf").Length; i++)
        {
            chickens.Add(GameObject.FindGameObjectsWithTag("Wolf")[i]);
        }
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Lion").Length; i++)
        {
            chickens.Add(GameObject.FindGameObjectsWithTag("Lion")[i]);
        }
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Human").Length; i++)
        {
            chickens.Add(GameObject.FindGameObjectsWithTag("Human")[i]);
        }
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        //Patrolling
        
        
        if (Vector3.Distance(transform.position, targetPos) < 10 && isDoingSomething == false || patrollingTimer >= 10)
        {
            Patrol();

        }

        if (whatIsState == state.paptrolling) 
        {
            patrollingTimer += Time.deltaTime;
        }
        findTarget();

        //consuming resources
        timerToConsume += Time.deltaTime;

        if (timerToConsume >= consumeMax)
        {
            if (whatCreature == CreatureType.Human){
                waterSupply -= thirstConsumeRate;
                if (waterSupply <= 0){
                    //thirst -= thirstConsumeRate;
                }
                //hunger
                 hunger -= hungerConsumeRate;
                 //if hunger hits 0 it dies
                if (hunger <= 0)
                {
                    Destroy(this.gameObject);
                    print("iam dying from hunger");
                }
                //if thirst hits 0 get hungrier faster
                if (thirst <= 0)
                {
                    //hunger -= hungerConsumeRate;
                }
                //else decreas thirst when out of water
                else if (waterSupply <= 0)
                {
                    //thirst -= thirstConsumeRate;
                }
                oxygenLevel -= oxygenConsumeRate;
                woodSupply -= woodConsumptionRate;
                timerToConsume = 0;
            }
            else{
                //hunger
                hunger -= hungerConsumeRate;
                //if hunger hits 0 die
                if (hunger <= 0)
                {
                    Destroy(this.gameObject);
                    print("iam dying from hunger");
                }
                //if thirst hits 0 it gets hungry faster
                if (thirst <= 0)
                {
                    //hunger -= hungerConsumeRate;
                }
                //else decrease thirst
                else
                {
                    //thirst -= thirstConsumeRate;
                }
                
                oxygenLevel -= oxygenConsumeRate;
                timerToConsume = 0;
            }

        }

        findFood();

        // patroll when states are good, will take other things into consideration later
        if (hunger >= .90 && patrolDoOnce == true)
        {
            Patrol();
            print("is now patrolling");
            patrolDoOnce = false;
        }
        

    }

    void findTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        
        transform.LookAt( transform.forward, transform.up);
        
    }
    private void Patrol()
    {
        randTargetIndex = Random.Range(0, PS.ForestGroups.Count - 1);
        targetPos = PS.ForestGroups[randTargetIndex].transform.position;
        whatIsState = state.paptrolling;
        patrollingTimer = 0;
    }


    /// <summary>
    /// how humans cut down trees
    /// </summary>
    /// <param name="tree"></param>
    void cutTreeDown(GameObject tree)
    {
        Destroy(tree);
        isDoingSomething = true;
        woodSupply += woodRegenRate;
        print("i cut down a tree");
    }
    /// <summary>
    /// how the animals hunt
    /// </summary>
    /// <param name="animal"></param>
    /// <param name="hasCaughtAnimal"></param>
    void huntAnimal(GameObject animal, bool hasCaughtAnimal)
    {
        isDoingSomething = true;
        targetPos = animal.transform.position;
        whatIsState = state.hunting;
        if (hasCaughtAnimal)
        {
            Destroy(animal);
            isDoingSomething = false;
            hunger += hungerRegenRate;
            hasCaughtAnimal = false;
            patrolDoOnce = true;
            print("animal Has been hunted");
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            transform.LookAt( transform.forward, transform.up);
        }
    }


    void findFood()
    {
        if (hunger <= .75)
        {
            //finding an animal
            if (whatCreature == CreatureType.Human)
            {
                int randNum = Random.Range(1, 2);
                switch (randNum)
                {
                    case 1:
                        huntAnimal(GameObject.FindGameObjectsWithTag("Chicken")[
                            Random.Range(0, GameObject.FindGameObjectsWithTag("Chicken").Length -1)], hasCaughtAnimal);
                        break;
                    case 2:
                        huntAnimal(GameObject.FindGameObjectsWithTag("Wolf")[
                           Random.Range(0, GameObject.FindGameObjectsWithTag("Wolf").Length)], hasCaughtAnimal);
                        break;
                    default:
                        print("food not in range");
                        break;
                }
            }
            else if (whatCreature == CreatureType.Wolf)
            {
                huntAnimal(GameObject.FindGameObjectsWithTag("Chicken")[
                           Random.Range(0, GameObject.FindGameObjectsWithTag("Chicken").Length)], hasCaughtAnimal);
            }
            else if (whatCreature == CreatureType.Lion)
            {
                int randNum = Random.Range(1,3);
                switch (randNum)
                {
                    case 1:
                        huntAnimal(GameObject.FindGameObjectsWithTag("Chicken")[
                            Random.Range(0, GameObject.FindGameObjectsWithTag("Chicken").Length)], hasCaughtAnimal);
                        break;
                    case 2:
                        huntAnimal(GameObject.FindGameObjectsWithTag("Wolf")[
                           Random.Range(0, GameObject.FindGameObjectsWithTag("Wolf").Length)], hasCaughtAnimal);
                        break;
                    case 3:
                        huntAnimal(GameObject.FindGameObjectsWithTag("Human")[
                            Random.Range(0, GameObject.FindGameObjectsWithTag("Human").Length)], hasCaughtAnimal);
                        break;
                    default:
                        print("food not in range");
                        break;
                }
            }
            else if (whatCreature == CreatureType.Chicken)
            {

            }
            
            isDoingSomething = true;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            transform.LookAt(transform.forward, transform.up);
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
        if (other.gameObject.tag == "Chicken" || other.gameObject.tag == "Wolf" || other.gameObject.tag == "Lion" || other.gameObject.tag == "human")
        {
            if (other.gameObject.transform.position == targetPos)
            {
                //cought the animal you are chasing
                hasCaughtAnimal = true;
            }
           
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (whatCreature == CreatureType.Human)
        {
            if (other.gameObject.tag == "Chicken" || other.gameObject.tag == "Wolf" || other.gameObject.layer == 8)
            {
                if (hunger <= .75f)
                {
                    huntAnimal(other.gameObject, hasCaughtAnimal);
                    print("iam hunting an animal");
                }
               
            }

            if (other.gameObject.layer == 7)
            {
                if (woodSupply <= 5)
                {
                    targetPos = other.gameObject.transform.position;
                    isDoingSomething = true;
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

        if (whatCreature == CreatureType.Lion)
        {
            if (hunger <= .75f)
            {
                if (other.gameObject.tag == "Chicken" || other.gameObject.tag == "Wolf" || other.gameObject.tag == "Human")
                {
                    huntAnimal(other.gameObject, hasCaughtAnimal);
                    print("lion is hunting something");
                }
            }
            
        }

        if (whatCreature == CreatureType.Wolf)
        {
            if (hunger <= .75f)
            {
                if (other.gameObject.tag == "Chicken" )
                {
                    huntAnimal(other.gameObject, hasCaughtAnimal);
                    print("wolf has hunted something");
                }
            }
        }

        if (whatCreature == CreatureType.Chicken)
        {
            if (other.gameObject.layer == 8)
            {
                if (other.gameObject.tag == "Grass")
                {
                    huntAnimal(other.gameObject, hasCaughtAnimal);
                    print("chicken has hunted food");
                }
            }
        }
        
        

    }
}
