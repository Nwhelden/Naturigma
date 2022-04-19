using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    public GameObject gateGO;
    public bool activated;

    private void Update()
    {
        if (activated)
            gateGO.SetActive(false);
        else
            gateGO.SetActive(true);
    }

    public void OpeningGate()
    {
        activated = true;
    }

    public void CloseGate()
    {
        activated = false;
    }
}
