using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public string startlevel;
    public string loadlevel1;
    public string loadlevel2;



    public void StartLevel1()
    {
        Application.LoadLevel(startlevel);
    }

    public void Level1Button()
    {
        Application.LoadLevel(loadlevel1);
    }

    public void Level2Button()
    {
        Application.LoadLevel(loadlevel2);
    }


    public void QuitButton()
    {
        Application.Quit();
        print("Quitting");
    }
}

