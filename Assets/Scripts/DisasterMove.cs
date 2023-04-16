using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisasterMove : MonoBehaviour
{
    int randTargetIndex;
    public PlanetStatus PS;
    public Vector3 targetPos;
    float patrollingTimer;
    float speed = 8;
    

    // Start is called before the first frame update
    void Start()
    {
        PS = GameObject.Find("PlanetStatus").GetComponent<PlanetStatus>();
        Destroy(gameObject, 20);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, targetPos) < 15  || patrollingTimer >= 15)
        {
            Patrol();
        }
        patrollingTimer += Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

    }

    void Patrol()
    {
        randTargetIndex = Random.Range(0, PS.ForestGroups.Count - 1);
        targetPos = PS.ForestGroups[randTargetIndex].transform.position;
        patrollingTimer = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Human" ||
            collision.gameObject.tag == "Wolf" ||
            collision.gameObject.tag == "Chicken"||
            collision.gameObject.tag == "Lion" ||
            collision.gameObject.tag == "Tree")
        {
            Destroy(collision.gameObject);
        }
    }
}
