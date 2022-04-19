using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public CanvasGroup pauseMenuCanvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCanvas(pauseMenuCanvas);
            print("OpenPauseMenu");
        }
    }

    public void ToggleCanvas(CanvasGroup canvas)
    {
        if (canvas.alpha == 0)
        {
            canvas.alpha = 1;
            canvas.interactable = true;
            canvas.blocksRaycasts = true;
            Time.timeScale = 0;
        }
        else
        {
            canvas.alpha = 0;
            canvas.interactable = false;
            canvas.blocksRaycasts = false;
            Time.timeScale = 1;
        }
    }

    public void RestartLevel()
    {
        int currSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currSceneIndex);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
