using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits_Buttons : MonoBehaviour
{
    public GameObject creditsmenu;
    public GameObject startbuttons;

    public void CreditsButton()
    { 
        creditsmenu.SetActive(true);
        startbuttons.SetActive(false);
    }

    public void Back()
    {
        creditsmenu.SetActive(false);
        startbuttons.SetActive(true);
    }
}
