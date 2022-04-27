using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public GameObject Tutorial1;
    public GameObject Tutorial2;
    public GameObject Tutorial3;
    public GameObject Tutorial4;

    void Start()
    {
        Tutorial1.SetActive(true);
        StartCoroutine(Waitaminute1());
        Tutorial2.SetActive(false);
        Tutorial3.SetActive(false);
        Tutorial4.SetActive(false);

    }

    void OnTriggerEnter(Collider Player)
    {
     if (Player.gameObject.name == "Tutorial_1_1")
        {
            Tutorial2.SetActive(true);
            StartCoroutine(Waitaminute2());
        }   
    }

    IEnumerator Waitaminute1()
    {
        print(Time.time);
        yield return new WaitForSeconds(3);
        Tutorial1.SetActive(false);
    }

    IEnumerator Waitaminute2()
    {
        print(Time.time);
        yield return new WaitForSeconds(3);
        Tutorial1.SetActive(false);
    }
}
