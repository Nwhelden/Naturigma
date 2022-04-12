using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keylock : MonoBehaviour
{
    public bool isOn;
    public GameObject keyGO;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Item" && !isOn)
        {
            isOn = true;
            keyGO = collision.gameObject;
            keyGO.gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Mouse0))
        {
            isOn = false;
            keyGO.gameObject.SetActive(true);
            keyGO.transform.position = other.transform.position + transform.up;
        }
    }
}
