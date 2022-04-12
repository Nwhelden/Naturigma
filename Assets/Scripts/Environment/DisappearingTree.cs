using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingTree : MonoBehaviour
{
    bool disappearing;
    public float disappearTime = 2f;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (!disappearing)
        {
            disappearing = true;
            StartCoroutine(StartDestruction());
        }
    }

    IEnumerator StartDestruction()
    {
        yield return new WaitForSeconds(disappearTime);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(true);
    }
}
