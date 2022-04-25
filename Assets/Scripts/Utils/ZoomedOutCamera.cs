using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomedOutCamera : MonoBehaviour
{
    public Camera mainCamera;
    Camera thisCam;
    public bool activeCam = false;
    public float speed = 5f;

    private void Start()
    {
        thisCam = GetComponent<Camera>();
        thisCam.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            activeCam = !activeCam;
            if(activeCam == false)
            {
                mainCamera.enabled = true;
                thisCam.enabled = false;
            }
            else
            {
                mainCamera.enabled = false;
                thisCam.enabled = true;
            }
        }
    }
}
