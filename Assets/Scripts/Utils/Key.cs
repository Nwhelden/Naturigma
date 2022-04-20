using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    private Vector3 originalPos;
    private bool isHeld = false;
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
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = originalPos;
        Float();
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
}
