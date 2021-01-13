using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text scoreTextP2;
    public Text scoreTextP1;
    public static int ScoreP2;
    public static int ScoreP1;

    public Text P1WinText;
    public Text P2WinText;

    public static int maxGoals= 100;
    public Text goalLimitText;

    private float slowMoTime = 1.0f;
    private bool gameOver;
    public SpriteRenderer arenaSpriteRenderer;

    void Start()
    {
        P1WinText.enabled = false;
        P2WinText.enabled = false;
        gameOver = false;
        ScoreP1 = 0;
        ScoreP2 = 0;
        goalLimitText.text = "GOAL LIMIT: " + maxGoals;

    }

    void Update()
    {
        if (gameOver == false)
        {
            if (ScoreP1 == ScoreP2)
            {
                arenaSpriteRenderer.color = Color.white;
            }
            else
            {
                if (ScoreP1 < ScoreP2)
                {
                    arenaSpriteRenderer.color = Color.blue;
                }
                else
                {
                    arenaSpriteRenderer.color = Color.red;
                }
            }

            scoreTextP2.text = ScoreP2.ToString();
            scoreTextP1.text = ScoreP1.ToString();

            if (ScoreP2 == maxGoals)
            {
                P1WinText.enabled = true;
                gameOver = true;
            }
            if (ScoreP1 == maxGoals)
            {
                P2WinText.enabled = true;
                gameOver = true;
            }
        }
        else
        {
            BackToMenu();
        }
    }

    // called when game ends and starts slow motion effect and countdown to go menu
    public void BackToMenu()
    {
        Time.timeScale = 0.3f;
 
        slowMoTime -= Time.deltaTime;
        Debug.Log(slowMoTime);
        
        if (slowMoTime < 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}

