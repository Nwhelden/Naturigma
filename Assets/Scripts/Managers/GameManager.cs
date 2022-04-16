using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector3 RespawnPointShroom;
    private Vector3 RespawnPointFung;
    public GameObject shroomus;
    public GameObject fungbert;

    // Start is called before the first frame update
    void Start()
    {
        RespawnPointShroom = shroomus.transform.position;
        RespawnPointFung = fungbert.transform.position;
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
        var rspwn = player.Equals(shroomus) ? RespawnPointShroom : RespawnPointFung;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.transform.position = rspwn;
    }

    public void SetRespawn(GameObject player, Vector3 position, Vector3 shroomOffset, Vector3 fungOffset)
    {
        if (player.Equals(shroomus))
        {
            RespawnPointShroom = position + shroomOffset;
        }
        else
        {
            RespawnPointFung = position + fungOffset;
        }
    }
}
