using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuUI;
    public GameObject HowToPlayUI;
    public GameObject LRUI;
    public PowerSelected PS;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        PS.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginGame()
    {
        Time.timeScale = 1;

        LRUI.gameObject.SetActive(true);
        MenuUI.gameObject.SetActive(false);

        PS.enabled = true;
    }

    public void HowToPlay()
    {
        MenuUI.gameObject.SetActive(false);
        HowToPlayUI.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        MenuUI.gameObject.SetActive(true);
        HowToPlayUI.gameObject.SetActive(false);
    }
}
