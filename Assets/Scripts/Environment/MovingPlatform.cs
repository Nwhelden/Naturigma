using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    /*
    public Vector3 startingPos;
    public Vector3 translationValue;

    public bool goToEnd;

    public float speed = 5f;

    private void Start()
    {
        goToEnd = false;
    }

    private void Update()
    {
        if (goToEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, startingPos + translationValue, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startingPos, speed * Time.deltaTime);
        }
    }
    */

    public GameObject respawnLeft;
    public GameObject respawnRight;

    public GameObject shroomus;
    public GameObject fungbert;
    
    public void Transition()
    {
        transform.position = transform.position + new Vector3(0, 11, 0);
        shroomus.transform.position = respawnLeft.transform.position;
        fungbert.transform.position = respawnRight.transform.position;
    }
}
