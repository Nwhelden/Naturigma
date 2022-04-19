using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherLever : MonoBehaviour
{
    public bool isOn;
    private bool canActivate = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isOn && canActivate)
        {
            //animate lever flip
            transform.Rotate(0, 180, 0);
            isOn = true;

            if (GetComponent<AudioSource>() != null)
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerController>().isActive())
        {
            canActivate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerController>().isActive())
        {
            canActivate = false;
        }
    }
}
