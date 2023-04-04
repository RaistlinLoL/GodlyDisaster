using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSelected : MonoBehaviour
{
    public enum powers
    {
        Rain,
        Smite,
        Growth,
        Love
    };
    public powers currentpower;

    public GameObject RainPower;
    public GameObject SmitePower;
    public GameObject GrowthPower;
    public GameObject LovePower;

    public MousePosition MousePos;

    public GameObject PlanetCenter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Power Used");
            GameObject createdPower;
            if(currentpower == powers.Rain)
            {
                createdPower = Instantiate(RainPower, MousePos.transform.position, Quaternion.identity);
            }
            else
            {
                createdPower = null;
            }
            createdPower.transform.LookAt(PlanetCenter.transform.position);
            createdPower.transform.Rotate(new Vector3(createdPower.transform.rotation.x +90, 
                createdPower.transform.rotation.y + 90, createdPower.transform.rotation.z));
        }
    }

    public void SelectRain()
    {
        currentpower = powers.Rain;
    }
    public void SelectSmite()
    {
        currentpower = powers.Smite;
    }
    public void SelectGrowth()
    {
        currentpower = powers.Growth;
    }
    public void SelectLove()
    {
        currentpower = powers.Love;
    }
}
