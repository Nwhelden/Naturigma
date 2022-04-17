using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Keyholes : MonoBehaviour
{
    public bool isOn;
    public GameObject key;
    public GameObject activatedObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            key = other.gameObject;
            key.gameObject.SetActive(false);

            activatedObject.GetComponent<Level2MovingPlatform>().isOn = true;
        }
    }
}
