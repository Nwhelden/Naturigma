using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLeverControl : MonoBehaviour
{
    public bool isOn;
    public OtherLever otherLever;
    public GameObject activatedObject;

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
