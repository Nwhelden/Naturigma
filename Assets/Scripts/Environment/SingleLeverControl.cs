using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleLeverControl : MonoBehaviour
{
    public bool isOn;
    public GameObject activatedObject;
    private bool canActivate = false;

    public void Update()
    {
        activatedObject.SetActive(isOn);

        if (Input.GetKeyDown(KeyCode.E) && !isOn && canActivate)
        {
            //animate lever flip
            transform.Rotate(0, 180, 0);
            isOn = !isOn;

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
