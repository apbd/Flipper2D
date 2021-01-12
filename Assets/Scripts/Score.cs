using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{

    public Text scoreText2;
    public Text scoreText1;
    public static int p2 = 0;
    public static int p1 = 0;

    public Text p1wins;
    public Text p2wins;

    public static int goal = 100;
    public Text goalLimitText;


    private float aika = 1.0f;
    private bool gameover = false;
    public SpriteRenderer render;



   // public TrailRenderer pallotrailrender;

    void Start()
    {
        Debug.Log("goalamount: " + goal);
        p1wins.enabled = false;
        p2wins.enabled = false;
        gameover = false;
        p1 = 0;
        p2 = 0;
        goalLimitText.text = "GOAL LIMIT: " + goal;

    }

    // Update is called once per frame
    void Update()
    {

        if (gameover == false)
        {
            if (p1 == p2)
            {
                render.color = Color.white;
                // pallotrailrender.startColor = Color.white;
            }
            else
            {
                if (p1 < p2)
                {
                    render.color = Color.blue;
                   // pallotrailrender.startColor = Color.blue;
                }
                else
                {
                    render.color = Color.red;
                   // pallotrailrender.startColor = Color.red;
                }
            }

            //huom ristissä olevat 1 ja 2 koska näin pisteet toimivat
            scoreText2.text = p1.ToString();
            scoreText1.text = p2.ToString();

            if (p2 == goal)
            {
                p1wins.enabled = true;
                gameover = true;
            }
            if (p1 == goal)
            {
                p2wins.enabled = true;
                gameover = true;
            }
        }
        else
        {
            BackToMenu();
        }
        
    }

    public void BackToMenu()
    {
        
        Time.timeScale = 0.3f;
 
            aika -= Time.deltaTime;
            Debug.Log(aika);
        

        if (aika < 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}

