using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float yOffset = 5.0f;
    public float throwForce = 10.0f;

    private bool holding = false;
    private HashSet<GameObject> items;
    private GameObject curr = null;
    private PlayerBouncePad headPad;
    private PlayerController player;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        items = new HashSet<GameObject>();
        headPad = GetComponent<PlayerBouncePad>();
        player = GetComponent<PlayerController>();
        gm = GameObject.FindGameObjectWithTag("Managers").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isActive() && Input.GetMouseButtonDown(0))
        {
            if (curr != null)
            {
                Throw();
            }
            else
            {
                Pick();
            }
        }
    }

    // If an item is within, mark it
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item") || other.gameObject.CompareTag("Player"))
        {
            items.Add(other.gameObject);
        }
    }

    //When an item leaves the player's 
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Item") || other.gameObject.CompareTag("Player"))
        {
            items.Remove(other.gameObject);
        }
    }

    private void Throw()
    {
        //
        curr.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        // Throw the currently picked-up item
        var itemRb = curr.GetComponent<Rigidbody>();
        itemRb.useGravity = true;
        itemRb.AddForce(transform.forward * throwForce, ForceMode.Impulse);


        // If an agent is thrown, enable the agent's movement
        if (curr.CompareTag("Player"))
        {
            gm.EnableSwitching();
        }

        // Reset values
        curr.transform.parent = null;
        headPad.ToggleActive();
        curr = null;
    }

    private void Pick()
    {
        var iter = items.GetEnumerator();
        if (iter.MoveNext())
        {
            var parent = gameObject.transform;
            curr = iter.Current;

            // if an agent is picked up, disable the agent's movement
            if (curr.CompareTag("Player"))
            {
                gm.DisableSwitching();
            }

            // Disable Player's bounce pad to prevent conflictions
            // Disable 
            headPad.ToggleActive();

            // Position the item over the head of the Player
            //curr.GetComponent<Rigidbody>().useGravity = false;
            curr.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            curr.transform.SetParent(gameObject.transform);
            curr.transform.position = new Vector3(parent.position.x, parent.position.y + yOffset, parent.position.z);

            Debug.Log("Picked up " + curr.name);
        }
    }
}
