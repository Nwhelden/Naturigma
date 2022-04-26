using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2MovingPlatform : MonoBehaviour
{
    //Rigidbody rb;
    
    public GameObject startWaypoint;
    public GameObject endWaypoint;
    public bool goToEnd;
    Vector3 travelVector;

    public bool isOn;

    public float speed;

    private void Start()
    {
        //rb = GetComponent<Rigidbody>();
        SetNewCourse();
    }

    private void Update()
    {
        if (isOn)
        {
            //rb.isKinematic = false;
            transform.position += -travelVector * speed * 0.25f * Time.deltaTime;

            if (goToEnd && Vector3.Distance(transform.position, endWaypoint.transform.position) < 0.5f)
            {
                goToEnd = false;
                SetNewCourse();
            }
            if (!goToEnd && Vector3.Distance(transform.position, startWaypoint.transform.position) < 0.5f)
            {
                goToEnd = true;
                SetNewCourse();
            }
        }
        else
        {
            //rb.isKinematic = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.rigidbody && isOn && collision.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<Rigidbody>().MovePosition(transform.position + -travelVector * speed * 0.25f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }

    public void SetNewCourse()
    {
        if (goToEnd)
        {
            travelVector = transform.position - endWaypoint.transform.position;
        }
        else
        {
            travelVector = transform.position - startWaypoint.transform.position;
        }
    }

    public void ActivatePlatform()
    {
        isOn = true;
    }

    public void DeactivatePlatform()
    {
        isOn = false;
    }
}
