using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Managers").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gm.Respawn(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Item"))
        {
            var key = other.gameObject.GetComponent<Key>();
            if (key != null)
            {
                key.Respawn();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gm.Respawn(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Item"))
        {
            var key = collision.gameObject.GetComponent<Key>();
            if (key != null)
            {
                key.Respawn();
            }
        }
    }
}
