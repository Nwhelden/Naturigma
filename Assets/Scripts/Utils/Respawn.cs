using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public AudioClip destructSFX;
    private Vector3 originalPos;
    

    //This script is last-minute and I don't like it; please never use again
    private void Start()
    {
        originalPos = transform.position;
    }

    public void _Respawn()
    {
        if (GetComponent<AudioSource>() && destructSFX != null)
        {
            GetComponent<AudioSource>().PlayOneShot(destructSFX);
        }
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.position = originalPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Hazard>())
        {
            _Respawn();
        }
    }
}
