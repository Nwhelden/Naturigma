using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OtherLever : MonoBehaviour
{
    public bool isOn;
    private bool canActivate = false;
    public UnityEvent activate;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isOn && canActivate)
        {
            //animate lever flip
            transform.Rotate(0, 180, 0);
            isOn = true;
            activate.Invoke();

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
