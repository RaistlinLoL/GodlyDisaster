using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSelected : MonoBehaviour
{
    enum powers
    {
        Rain,
        Smite,
        Growth,
        Love
    };
    powers currentpower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
