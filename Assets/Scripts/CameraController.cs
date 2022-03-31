using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject Agent1, Agent2;

    public int Smoothvalue = 2;
    public float PosY = 5;
    public float PosZ = 5;

    //public float PosX = 15;

    public float tilt = 30;

    private GameObject Target;
    private bool toggle = true;

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

        if (Input.GetKeyDown(KeyCode.Return))
        {
            toggle = !toggle;
            Target =  toggle ? Agent1 : Agent2;

            Agent1.GetComponent<PlayerController>().ToggleActive();
            Agent2.GetComponent<PlayerController>().ToggleActive();
        }
    }
}
