using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public float bounceForce = 10.0f;
    public float cooldown = 2.5f;
    private bool active = true;

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        active = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && active)
        {
            // transform.up allows for angled bouncepads (add force in direction of object's up vector)
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * bounceForce, ForceMode.Impulse);

            active = false;
            StartCoroutine(Cooldown());
        }
    }
}
