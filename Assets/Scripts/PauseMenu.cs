using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    public Toggle swapToggle;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    //INVERTED AND SWAP
    public void IsInverted(bool invert)
    {
        P2FlipperMover.inverted = invert;
    }
    public void SwapControls(bool swap)
    {

        P2FlipperMover.swapped = swap;
        P1FlipperMover.swapped = swap;

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.5f;
        gameIsPaused = false;
    }
    void Pause() 
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }



    public void LoadMenu()
    {

        // destroys dontdestroyonload object so theres no duplicates
        // Destroy(mainMenuObjectinScript.gameObject);
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
