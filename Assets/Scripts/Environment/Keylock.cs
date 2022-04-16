using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keylock : MonoBehaviour
{
    public string keyName;
    public Vector3 KeyOffset;
    private bool active = false;
    
    private void OnTriggerEnter(Collider collision)
    {
        var obj = collision.gameObject;
        if (obj.CompareTag("Item") && obj.name.Equals(keyName) && !obj.GetComponent<Key>().CheckHeld())
        {
            // Position key
            obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            obj.GetComponent<Rigidbody>().useGravity = false;
            obj.transform.SetParent(gameObject.transform);
            obj.transform.position = gameObject.transform.position + KeyOffset;

            //Activate key
            obj.GetComponent<Key>().Activate();
        }
    }
}
