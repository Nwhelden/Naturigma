using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPlatform : MonoBehaviour
{
    private Transform target;
    private IEnumerator iter;

    public bool active = false;
    public float speed;
    public List<Transform> waypoints;

    // Start is called before the first frame update
    void Start()
    {
        Transform origin = new GameObject(gameObject.name + "_ORIGIN").transform;
        origin.position = transform.position;
        waypoints.Add(origin);

        iter = waypoints.GetEnumerator();
        if (iter.MoveNext())
        {
            target = (Transform)iter.Current;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            // MoveTowards doesn't overshoot target
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            // If we've reached targed, assign a new one
            if (Vector3.Distance(transform.position, target.position) < 0.01f && waypoints.Count != 0)
            {
                if (!iter.MoveNext())
                {
                    iter.Reset();
                    iter.MoveNext();
                }

                target = (Transform)iter.Current;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

    public void Activate()
    {
        active = true;
    }

    public void Deactivate()
    {
        active = false;
    }
}
