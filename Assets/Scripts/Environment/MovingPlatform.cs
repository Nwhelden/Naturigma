using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
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
        //transform.position = Vector3.Lerp(transform.position, startingPos + translationValue, speed * Time.deltaTime);
        //transform.position = Vector3.Lerp(transform.position, startingPos, speed * Time.deltaTime);
    }

    /*IEnumerator Flip()
    {
        goToEnd = true;
        yield return new WaitForSeconds(4f);
        goToEnd = false;
        yield return new WaitForSeconds(4f);

        StartCoroutine(Flip());
    }*/
}
