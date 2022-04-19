using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHold : MonoBehaviour
{
    public bool isOn;
    Vector3 buttonTranslation = new Vector3(0, 0.5f, 0);

    public float cooldown = 1f;

    private void Update()
    {
        cooldown -= Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && cooldown <= 0f)
        {
            isOn = true;
            transform.position -= buttonTranslation;
            cooldown = 1f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (cooldown <= 0)
        {
            isOn = false;
            transform.position += buttonTranslation;
            cooldown = 1f;
        }
    }
}
