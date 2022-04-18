using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector3 startPos;
    public float destY;
    private bool goToEnd;
    public float speed = 5f;

    private void Start()
    {
        goToEnd = false;
        startPos = transform.position;
    }

    // Right now this just moves the platform up to the specified Y pos
    // Let me know if you want the platform to move across X and Z
    private void Update()
    {
        if (goToEnd)
        {
            if (transform.position.y < destY) {
                GetComponent<Rigidbody>().MovePosition(transform.position + Vector3.up * 1.0f * Time.deltaTime);
            }
        }
        else
        {
            if (transform.position.y > startPos.y) {
                GetComponent<Rigidbody>().MovePosition(transform.position + -Vector3.up * 1.0f * Time.deltaTime);
            }
        }
    }

    public void Toggle()
    {
        goToEnd = !goToEnd;
    }
}
