using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustCameraZone : MonoBehaviour
{
    CameraController cam;

    public bool adjustCam;
    public float adjustTilt, adjustY, adjustZ;

    private void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !other.gameObject.GetComponent<PlayerController>().disabled)
        {
            adjustCam = true;
            cam.PosY += adjustY;
            cam.PosZ += adjustZ;
            cam.tilt += adjustTilt;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && !other.gameObject.GetComponent<PlayerController>().disabled)
        {
            adjustCam = false;
            cam.PosY -= adjustY;
            cam.PosZ -= adjustZ;
            cam.tilt -= adjustTilt;
        }
        
    }
    */

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !other.gameObject.GetComponent<PlayerController>().disabled)
        {
            if(adjustCam == false)
            {
                adjustCam = true;
                cam.PosY += adjustY;
                cam.PosZ += adjustZ;
                cam.tilt += adjustTilt;
            }
        }
        else if(other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerController>().disabled)
        {
            if(adjustCam == true)
            {
                adjustCam = false;
                cam.PosY += -adjustY;
                cam.PosZ += -adjustZ;
                cam.tilt += -adjustTilt;
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
