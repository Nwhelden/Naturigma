using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 startingPos;
    public Vector3 translationValue;

    public bool goToEnd = true;

    float speed = 0.5f;

    private void Start()
    {
        StartCoroutine(Flip());
    }

    private void Update()
    {
        if (goToEnd)
            transform.position = Vector3.Lerp(transform.position, startingPos + translationValue, speed * Time.deltaTime);
        else
            transform.position = Vector3.Lerp(transform.position, startingPos, speed * Time.deltaTime);
    }

    IEnumerator Flip()
    {
        goToEnd = true;
        yield return new WaitForSeconds(4f);
        goToEnd = false;
        yield return new WaitForSeconds(4f);

        StartCoroutine(Flip());
    }
}
