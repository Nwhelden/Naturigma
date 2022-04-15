using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameManager gm;
    public Vector3 shroomOffset;
    public Vector3 fungOffset;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Managers").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager gm = FindObjectOfType<GameManager>();
            gm.SetRespawn(collision.gameObject, collision.gameObject.transform.position, shroomOffset, fungOffset);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager gm = FindObjectOfType<GameManager>();
            gm.SetRespawn(collision.gameObject, collision.gameObject.transform.position, shroomOffset, fungOffset);
        }
    }
}
