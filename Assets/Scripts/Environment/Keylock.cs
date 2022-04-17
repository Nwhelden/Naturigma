using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Keylock : MonoBehaviour
{
    public string keyName;
    public Vector3 KeyOffset;

    public UnityEvent activate;
    public UnityEvent deactivate;
    public GameObject key;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Item") && !collision.GetComponent<Key>().CheckHeld())
        {
            // Position key
            key = collision.gameObject;
            key.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            key.GetComponent<Rigidbody>().useGravity = false;
            key.transform.SetParent(gameObject.transform);
            key.transform.position = gameObject.transform.position + KeyOffset;

            //Activate key
            Activate();
        }
    }

    private void Update()
    {
        if (key != null && key.GetComponent<Key>().CheckHeld())
        {
            Deactivate();
            key = null;
        }
    }

    public void Activate()
    {
        activate.Invoke();
    }

    // Deactivate should return to status-quo
    public void Deactivate()
    {
        deactivate.Invoke();
    }
}
