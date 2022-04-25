using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float yOffset = 5.0f;
    public float throwForce = 10.0f;
    public bool playerPickup = true;

    //audio
    public AudioClip throwSFX;
    public AudioClip pickSFX;

    private bool holding = false;
    private HashSet<GameObject> items;
    private GameObject curr = null;
    private GameObject interaction = null;
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
            else if (interaction != null)
            {
                Extract();
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
        if (other.gameObject.CompareTag("Item") || (playerPickup && other.gameObject.CompareTag("Player")))
        {
            items.Add(other.gameObject);
        }
        /*
        else if (other.gameObject.CompareTag("Extractable"))
        {
            interaction = other.gameObject;
        }
        */
    }

    //When an item leaves the player's 
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Item") || (playerPickup && other.gameObject.CompareTag("Player")))
        {
            items.Remove(other.gameObject);
        }
        /*
        else if (other.gameObject.CompareTag("Extractable"))
        {
            interaction = null;
        }
        */
    }

    private void Throw()
    {
        //
        curr.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        // Throw the currently picked-up item
        var itemRb = curr.GetComponent<Rigidbody>();
        itemRb.useGravity = true;
        itemRb.isKinematic = false;
        itemRb.AddForce(transform.forward * throwForce, ForceMode.Impulse);

        // item-specific functions
        // If an agent is thrown, enable the agent's movement
        if (curr.CompareTag("Player"))
        {
            gm.EnableSwitching();
        }
        else if (curr.GetComponent<Key>() != null)
        {
            curr.GetComponent<Key>().SetHeld(false);
        }

        // Reset values
        curr.transform.parent = null;
        if (headPad != null)
        {
            headPad.ToggleActive();
        }
        curr = null;

        // Play Audio
        if (throwSFX != null)
        {
            GetComponent<AudioSource>().PlayOneShot(throwSFX);
        }
    }

    private void Pick()
    {
        var iter = items.GetEnumerator();
        if (iter.MoveNext())
        {
            var parent = gameObject.transform;
            curr = iter.Current;

            // item-specific functions
            // if an agent is picked up, disable the agent's movement
            // if key is active, deactivate it on pick-up
            if (curr.CompareTag("Player"))
            {
                gm.DisableSwitching();
            }
            else if (curr.GetComponent<Key>() != null)
            {
                var key = curr.GetComponent<Key>();
                key.SetHeld(true);

                /*
                if (key.CheckActive())
                {
                    key.Deactivate();
                }
                */
            }

            // Disable Player's bounce pad to prevent conflictions
            // Disable 
            if (headPad != null)
            {
                headPad.ToggleActive();
            }

            // Position the item over the head of the Player
            //curr.GetComponent<Rigidbody>().useGravity = false;
            curr.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            curr.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            curr.transform.SetParent(gameObject.transform);
            curr.transform.position = new Vector3(parent.position.x, parent.position.y + yOffset, parent.position.z);

            // Play Audio
            if (pickSFX != null)
            {
                GetComponent<AudioSource>().PlayOneShot(pickSFX);
            }

            Debug.Log("Picked up " + curr.name);
        }
    }

    private void Extract()
    {

    }
}
