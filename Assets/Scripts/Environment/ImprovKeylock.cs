using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovKeylock : MonoBehaviour
{
    public GameObject key;
    public GameObject activatedObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Item")
        {
            key = other.gameObject;
            key.transform.SetParent(gameObject.transform);
            key.gameObject.SetActive(false);

            activatedObject.SetActive(true);
        }
    }
}
