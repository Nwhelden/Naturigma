using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits_Buttons : MonoBehaviour
{
    public GameObject creditspage1;
    public GameObject startbuttons;
    public GameObject creditspage2;
    public GameObject creditspage3;

    public void Credits1Button()
    { 
        creditspage1.SetActive(true);
        creditspage2.SetActive(false);
        creditspage3.SetActive(false);
        startbuttons.SetActive(false);
    }

    public void Credits2Button()
    {
        creditspage1.SetActive(false);
        creditspage2.SetActive(true);
        creditspage3.SetActive(false);
        startbuttons.SetActive(false);
    }

    public void Credits3Button()
    {
        creditspage1.SetActive(false);
        creditspage2.SetActive(false);
        creditspage3.SetActive(true);
        startbuttons.SetActive(false);
    }

    public void Back()
    {
        creditspage1.SetActive(false);
        creditspage2.SetActive(false);
        startbuttons.SetActive(true);
    }
}
