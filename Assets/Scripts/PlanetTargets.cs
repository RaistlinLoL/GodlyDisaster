using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTargets : MonoBehaviour
{
    public GameObject[] targets = new GameObject[1482];
    //public List<GameObject> targets1;
    // Start is called before the first frame update
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("PlanetMoment");
        /*foreach(GameObject t in GameObject.FindGameObjectsWithTag("PlanetMoment"))
        {
            targets1.Add(t);
        }*/
        
    }

    // Update is called once per frame
    void Update()
    {
        targets = GameObject.FindGameObjectsWithTag("PlanetMoment");
        //targets1.RemoveAll(x => x == null);
    }
}
