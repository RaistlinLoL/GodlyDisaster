using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
   
    
    [SerializeField] GameObject entity;
    [SerializeField] float spawnRate;
    [SerializeField] int initialSpawn;

    float spawnTime = 0;
    void Start()
    {
        for (int i = 0; i < initialSpawn; i++)
        {
            Instantiate(entity, this.transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;

        if (spawnTime >= spawnRate)
        {
            Instantiate(entity, this.transform.position, Quaternion.identity);
            spawnTime = 0;
        }
    }
}
