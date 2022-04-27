using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int lvlIndex;

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(lvlIndex);
    }
}
