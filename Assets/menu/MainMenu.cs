using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public enum GameType { solo, local, online}
    public static GameType gametype;
    public Text goalamount;
    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;
   public float musicOn;

    public Toggle swapToggle;


    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        Time.timeScale = 1.5f;  //toinen on powerupActionsisa

        ToggleMusic(false);
        Score.goal = 10;
        goalamount.text = "10";

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height && 
                resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResolutionIndex = i;
            }
        }
        Screen.SetResolution(1280, 720, Screen.fullScreen, 60);

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    //playmenu
    public void PlayGameSolo()
    {
        SceneManager.LoadScene(1);
        gametype = GameType.solo;
    }

    public void PlayGameLocal()
    {
        SceneManager.LoadScene(1);
        gametype = GameType.local;
    }
    public void PlayGameOnline()
    {
        SceneManager.LoadScene(1);
        gametype = GameType.online;
    }


    //GOAL
    public void GoalSlider(float goal)
    {

        Debug.Log(Mathf.RoundToInt(goal));

        goalamount.text = goal.ToString();

        Score.goal = Mathf.RoundToInt(goal);
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
    //VOLUME
    public void SetVolume (float volume)
    {
        Debug.Log(Mathf.Pow(3, volume) * volume);
        audioMixer.SetFloat("masterVolume",  volume);
    }

    //MUSIC

    public void ToggleMusic (bool music)
    {
        if(music == true)
        {
           musicOn = 0.0f;
        }
        else
        {
            musicOn = -80.0f;
        }

        audioMixer.SetFloat("musicVolume", musicOn);
    }
    //QUALITY
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    //set RESOLUTION
    public void SetResolution (int resolutionIndex)
    {

        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen, resolution.refreshRate);
    }
    //FULLSCREEN
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
