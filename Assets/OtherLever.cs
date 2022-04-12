using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherLever : MonoBehaviour
{
    public bool isOn;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E) && !isOn)
        {
            //animate lever flip
            transform.Rotate(0, 180, 0);
            isOn = true;
        }
    }
}
