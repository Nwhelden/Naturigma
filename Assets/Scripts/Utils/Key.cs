using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    public AudioClip destructSFX;
    private Vector3 originalPos;
    private bool isHeld = false;
    private bool floating = true;
    //private bool isActive = false;
    //public UnityEvent activate;
    //public UnityEvent deactivate;

    private void Start()
    {
        originalPos = transform.position;
        Float();
    }

    public void Respawn()
    {
        if (GetComponent<AudioSource>() && destructSFX != null)
        {
            GetComponent<AudioSource>().PlayOneShot(destructSFX);
        }
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = originalPos;

        if (floating) {
            Float();
        }
    }

    public bool CheckHeld()
    {
        return isHeld;
    }

    public void SetHeld(bool held)
    {
        isHeld = held;
    }

    private void Float()
    {
        var rb = GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    public void TurnToKey()
    {
        gameObject.tag = "Item";
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponent<Rigidbody>().useGravity = true;
        floating = false;
    }

    public void DoNothing()
    {
        print("Do Nothing lol");
    }
}
