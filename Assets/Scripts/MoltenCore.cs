using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoltenCore : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("MOLTEN CORE");
        Destroy(other.gameObject);
    }
}
