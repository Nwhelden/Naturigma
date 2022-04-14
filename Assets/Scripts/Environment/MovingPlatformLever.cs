using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformLever : MonoBehaviour
{
    public MovingPlatform movingPlatform;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            movingPlatform.goToEnd = !movingPlatform.goToEnd;
        }
    }
}
