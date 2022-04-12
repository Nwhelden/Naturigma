using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingTree : MonoBehaviour
{
    bool disappearing;
    public float disappearTime = 2f;

    Collider collider;
    MeshRenderer mesh;

    private void Start()
    {
        collider = GetComponent<MeshCollider>();
        mesh = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!disappearing)
        {
            disappearing = true;
            StartCoroutine(StartDisappear());
        }
    }

    IEnumerator StartDisappear()
    {
        yield return new WaitForSeconds(disappearTime);
        collider.enabled = false;
        mesh.enabled = false;
        yield return new WaitForSeconds(3f);
        collider.enabled = true;
        mesh.enabled = true;
        gameObject.SetActive(true);
    }
}
