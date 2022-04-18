using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformLever : MonoBehaviour
{
    public MovingPlatform movingPlatform;
    private bool canActivate = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canActivate)
        {
            movingPlatform.Toggle();

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
