using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pausemenuUI;
    public MainMenu mainMenuObjectinScript;

    public Toggle swapToggle;

    void Start()
    {
        /*
        if (mainMenuObjectinScript.swapToggle.isOn)
        {
            Debug.Log("onopööö");
            swapToggle.isOn = true;
        }
        //etsii mainmenussa olevan mainmenuscriptin
        mainMenuObjectinScript = GameObject.Find("MainMenuController").GetComponent<MainMenu>(); ;
        Debug.Log("what" + mainMenuObjectinScript.goalamount);
       */
    }
    void Update()
    {
        


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
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
        FlipperMover.swapped = swap;

    }

    public void Resume()
    {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1.5f;
        GameIsPaused = false;
    }
    void Pause() 
    {
        pausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }



    public void LoadMenu()
    {

        //tuhoaa dontdestroyonload objetin jottei tuu duplicateja
        // Destroy(mainMenuObjectinScript.gameObject);
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
