using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBouncePad : MonoBehaviour
{
    public float bounceForce = 10.0f;
    public float cooldown = 2.0f;
    private bool active = true;
    private bool disabled = false;

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        active = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Unity colliders are weird. There isn't an alternative unless we wrap Parent and Bouncepad with a game object.
        foreach (ContactPoint contact in collision.contacts)
        {
            var type = contact.thisCollider.GetType();
            if (type == typeof(BoxCollider) && collision.gameObject.tag == "Player" && active && !disabled)
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
                active = false;
                StartCoroutine(Cooldown());
                Debug.Log("Bounced");
            }
        }
    }

    public void ToggleActive()
    {
        disabled = !disabled;
    }
}
