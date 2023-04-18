using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoltenCore : MonoBehaviour
{

    [SerializeField] Transform reserectPoint;
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("MOLTEN CORE");
        other.gameObject.transform.position = reserectPoint.position;
    }
}
