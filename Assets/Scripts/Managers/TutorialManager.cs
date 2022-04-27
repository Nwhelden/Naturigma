using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public CanvasGroup tutorialMenuCanvas;

    private void Start()
    {
        ToggleCanvas(tutorialMenuCanvas);
        print("OpenTutorials");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCanvas(tutorialMenuCanvas);
            print("OpenTutorials");
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

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
