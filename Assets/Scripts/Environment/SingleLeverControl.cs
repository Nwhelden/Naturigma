using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleLeverControl : MonoBehaviour
{
    public bool isOn;
    public GameObject activatedObject;

    public void Update()
    {
        activatedObject.SetActive(isOn);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            //animate lever flip
            transform.Rotate(0, 180, 0);
            isOn = !isOn;
        }
    }
}
