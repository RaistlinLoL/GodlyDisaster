using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growth : MonoBehaviour
{
    int rngTree;

    public GameObject Tree1;
    public GameObject Tree2;
    public GameObject Tree3;
    public GameObject Tree4;

    public GameObject CreatedTree;
    public Transform TreeParent;

    public MousePosition MP;
    public PlanetStatus PS;

    bool canPlaceTree = true;
    // Start is called before the first frame update
    void Start()
    {
        MP = GameObject.Find("MouseDot").GetComponent<MousePosition>();
        TreeParent = GameObject.Find("Trees").transform;
        PS = GameObject.Find("PlanetStatus").GetComponent<PlanetStatus>();

        StartCoroutine(GrowCooldown());
    }

    private void FixedUpdate()
    {
        if (canPlaceTree)
        {
            PlaceTree();
        }
    }

    void PlaceTree()
    {
        canPlaceTree = false;
        rngTree = Random.Range(1, 5);
        if (rngTree == 1)
        {
            CreatedTree = Instantiate(Tree1, MP.transform.position, Quaternion.identity);
        }
        if (rngTree == 2)
        {
            CreatedTree = Instantiate(Tree2, MP.transform.position, Quaternion.identity);
        }
        if (rngTree == 3)
        {
            CreatedTree = Instantiate(Tree3, MP.transform.position, Quaternion.identity);
        }
        if (rngTree == 4)
        {
            CreatedTree = Instantiate(Tree4, MP.transform.position, Quaternion.identity);
        }
        CreatedTree.transform.rotation = transform.rotation;
        CreatedTree.transform.SetParent(TreeParent);
        PS.ForestGroups.Add(CreatedTree);

        ChangeCorruption(1);
    }

    IEnumerator GrowCooldown()
    {

        while (true)
        {
            canPlaceTree = true;
            yield return new WaitForSeconds(1);
        }
    }

    void ChangeCorruption(float i)
    {
        PS.CorruptionCounter -= i;
        if (PS.CorruptionCounter < 0)
        {
            PS.CorruptionCounter = 0;
        }
    }
}
