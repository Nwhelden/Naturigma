using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector3 RespawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        RespawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    public void SetRespawn(Vector3 position)
    {
        RespawnPoint = position;
    }
}
