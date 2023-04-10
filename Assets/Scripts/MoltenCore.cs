using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoltenCore : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
    }
}
