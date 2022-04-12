using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject endPoint;
    public GameObject startPoint;

    public bool goToEnd = true;

    float speed = 1f;

    private void Start()
    {
        StartCoroutine(Flip());
    }

    private void Update()
    {
        if (goToEnd)
            transform.position = Vector3.Lerp(transform.position, endPoint.transform.position, speed * Time.deltaTime);
        else
            transform.position = Vector3.Lerp(transform.position, startPoint.transform.position, speed * Time.deltaTime);
    }

    IEnumerator Flip()
    {
        goToEnd = true;
        yield return new WaitForSeconds(3.5f);
        goToEnd = false;
        yield return new WaitForSeconds(3.5f);

        StartCoroutine(Flip());
    }
}
