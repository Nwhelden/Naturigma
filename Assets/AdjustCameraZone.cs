using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustCameraZone : MonoBehaviour
{
    CameraController cam;

    public bool adjustCam;
    public float adjustTilt, adjustY, adjustZ;

    public bool checkForSwitch;

    private void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            checkForSwitch = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerController>().disabled == false)
        {
            if(adjustCam == false)
            {
                adjustCam = true;
                cam.PosY += adjustY;
                cam.PosZ += adjustZ;
                cam.tilt += adjustTilt;
            }
        }
        if (checkForSwitch)
        {
            if(other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerController>().disabled == true)
            {
                if (adjustCam == true)
                {
                    adjustCam = false;
                    cam.PosY += -adjustY;
                    cam.PosZ += -adjustZ;
                    cam.tilt += -adjustTilt;
                    checkForSwitch = false;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (adjustCam == true)
            {
                adjustCam = false;
                cam.PosY += -adjustY;
                cam.PosZ += -adjustZ;
                cam.tilt += -adjustTilt;
            }
        }
    }
}
