using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraLoc1, cameraLoc2;
    public GameObject Agent1, Agent2;

    public int Smoothvalue = 2;
    public float PosY = 5;
    public float PosZ = 5;
    public float PosX = 15;

    public Vector3 offset;

    public float tilt = 30;

    private GameObject Target;
    private bool toggle = true;
    private bool disabled = false;

    void Start()
    {
        Target = Agent1;
        Agent2.GetComponent<PlayerController>().ToggleActive();
    }

    void Update()
    {
        Vector3 Targetpos = new Vector3(Target.transform.position.x, Target.transform.position.y + PosY, Target.transform.position.z - PosZ);
        transform.position = Vector3.Lerp(transform.position, Targetpos, Time.deltaTime * Smoothvalue);

        var rotation = transform.rotation.eulerAngles;
        rotation.x = tilt;
        transform.rotation = Quaternion.Euler(rotation);

        if (Input.GetKey(KeyCode.C))
        {
            if(Agent1.GetComponent<PlayerController>().disabled == false)
            {
                transform.position = cameraLoc1.position;
                transform.LookAt(Agent1.transform);
            }
            else
            {
                transform.position = cameraLoc2.position;
                transform.LookAt(Agent2.transform);
            }
        }

        if (!disabled && Input.GetKeyDown(KeyCode.Return))
        {
            toggle = !toggle;
            Target =  toggle ? Agent1 : Agent2;

            Agent1.GetComponent<PlayerController>().ToggleActive();
            Agent2.GetComponent<PlayerController>().ToggleActive();
        }
    }



    public void DisableSwitching()
    {
        disabled = true;
    }

    public void EnableSwitching()
    {
        disabled = false;
    }
}

/*
transform.position = Vector3.Lerp(transform.position, Target.transform.position + offset, Smoothvalue);
if (Input.GetKey(KeyCode.Q))
{
    transform.RotateAround(Targetpos, Vector3.up, 100.0f * Time.deltaTime);
}
else if (Input.GetKey(KeyCode.E))
{
    transform.RotateAround(Targetpos, Vector3.up, -100.0f * Time.deltaTime);
}
*/
