using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Keylock : MonoBehaviour
{
    public string keyName;
    public AudioClip unlockSFX;
    public AudioClip lockSFX;
    public Vector3 KeyPos;
    public UnityEvent activate;
    public UnityEvent deactivate;

    private void OnTriggerEnter(Collider collision)
    {
        var obj = collision.gameObject;
        var key = collision.GetComponent<Key>();

        // Check if the item is a key, and if the key is associated with the lock
        // This allows multiple keys to exist in a scene, but limits the lock to 1 unique key 
        if (collision.CompareTag("Item") && key && obj.name.Equals(keyName))
        {
            // Position key
            key.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            key.GetComponent<Rigidbody>().useGravity = false;
            key.transform.SetParent(gameObject.transform);
            key.transform.position = KeyPos;

            //Activate key
            Activate();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Item") && collision.gameObject.name.Equals(keyName))
        {
            Deactivate();
        }
    }

    public void Activate()
    {
        activate.Invoke();
        GetComponent<AudioSource>().PlayOneShot(unlockSFX);
    }

    // Deactivate should return to status-quo
    public void Deactivate()
    {
        deactivate.Invoke();
        GetComponent<AudioSource>().PlayOneShot(lockSFX);
    }
}
