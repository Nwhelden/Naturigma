using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2LeverToggle : MonoBehaviour
{
    public bool playerInRange;
    public bool isOn;

    public Level2MovingPlatform platform;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            isOn = !isOn;
        }

        platform.isOn = isOn;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (!playerController.disabled)
            {
                playerInRange = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
