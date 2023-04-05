using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Camera mainCam;
    public LayerMask PlanetLayer;
    public bool OnPlanet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray rayToMouse = mainCam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(rayToMouse, out RaycastHit rayHit))
        {
            GetComponent<MeshRenderer>().enabled = true;
            transform.position = rayHit.point;
            OnPlanet = true;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
            OnPlanet = false;
        }
    }
}
