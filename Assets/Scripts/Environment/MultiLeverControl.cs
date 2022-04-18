using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLeverControl : MonoBehaviour
{
    public bool isOn;
    public OtherLever otherLever;
    public GameObject activatedObject;
    private bool canActivate = false;

    public void Update()
    {
        if(isOn && otherLever.isOn)
        {
            activatedObject.SetActive(true);
        }
        else
        {
            activatedObject.SetActive(false);
        }

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
