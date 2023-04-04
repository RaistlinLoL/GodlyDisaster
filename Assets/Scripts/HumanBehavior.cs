using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    
    Vector3 targetPos;
    GameObject[] targets = new GameObject[1482];
    int randTargetIndex;
    void Start()
    {
       targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        targets = GameObject.FindGameObjectsWithTag("PlanetMoment");
        //transform.position += transform.forward * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetPos) < 10)
        {
            randTargetIndex = Random.Range(0,targets.Length -1);
            targetPos = targets[randTargetIndex].transform.position;
        }

        findTarget();

    }

    void findTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
