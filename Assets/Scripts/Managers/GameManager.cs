using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector3 RespawnPoint;
    public GameObject shroomus;
    public GameObject fungbert;

    // Start is called before the first frame update
    void Start()
    {
        RespawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn(shroomus);
            Respawn(fungbert);
        }
    }

    public void DisableMovement()
    {
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            player.GetComponent<PlayerController>().Disable();
        }
    }

    public void EnableMovement()
    {
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            player.GetComponent<PlayerController>().ToggleActive();
        }
    }

    public void DisableSwitching()
    {
        Camera.main.GetComponent<CameraController>().DisableSwitching();
    }

    public void EnableSwitching()
    {
        Camera.main.GetComponent<CameraController>().EnableSwitching();

    }

    public void Respawn(GameObject player)
    {
        player.transform.position = RespawnPoint;
        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    public void SetRespawn(Vector3 position)
    {
        RespawnPoint = position;
    }
}
