using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    private Vector3 originalPos;
    private bool isHeld = false;
    private bool isActive = false;
    public UnityEvent activate;
    public UnityEvent deactivate;

    private void Start()
    {
        originalPos = transform.position;
    }

    // Activate causes change
    public void Activate()
    {
        isActive = true;
        activate.Invoke();
    }

    // Deactivate should return to status-quo
    public void Deactivate()
    {
        isActive = false;
        deactivate.Invoke();
    }

    public void Respawn()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = originalPos;
    }

    public bool CheckActive()
    {
        return isActive;
    }

    public bool CheckHeld()
    {
        return isHeld;
    }

    public void SetHeld(bool held)
    {
        isHeld = held;
    }
}
