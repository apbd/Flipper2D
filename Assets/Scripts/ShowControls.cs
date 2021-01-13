using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowControls : MonoBehaviour
{
    public Text holdControlsTextDark;
    public Text holdControlsTextRed;
    public Text holdCText;
    public GameObject controlsAsChars;
    public GameObject ball;
    public static Rigidbody2D ballRigidbody;

    void Start()
    {
        // find graphics 
        holdCText = this.GetComponent<Text>();
        holdControlsTextDark = GameObject.Find("Graphics/HoldDownControlsDarkText").GetComponent<Text>();
        holdControlsTextRed = GameObject.Find("Graphics/HoldDownControlsDarkText/HoldDownControlsRedText").GetComponent<Text>();
        controlsAsChars = GameObject.Find("Graphics/ControlsAsChars");

        controlsAsChars.SetActive(false);

        // find ball
        ball = GameObject.FindGameObjectWithTag("Ball");
        ballRigidbody = ball.GetComponent<Rigidbody2D>();

        //  MainMenu.gametype = MainMenu.GameType.local;    // For testing purposes
        if (MainMenu.gametype == MainMenu.GameType.local)
        {
            BallGravity.ballFreeze = true;
            holdCText.enabled = true;
        }
    }

    void FixedUpdate()
    {

        if (Input.GetKey("c"))
        {
            controlsAsChars.SetActive(true);
        }
        else
        {
            controlsAsChars.SetActive(false);
        }

        // if game starts as local, show how to start game text
        if (MainMenu.gametype == MainMenu.GameType.local)
        {

            if (BallGravity.ballFreeze == true)
            {
                controlsAsChars.SetActive(true);
                holdControlsTextDark.enabled = true;
                holdControlsTextRed.enabled = true;
                ballRigidbody.Sleep();


                if (Input.GetAxis("P2RFlipper") == 1 && Input.GetAxis("P2LFlipper") == 1 &&  // Player 2 ready
                    Input.GetAxis("RFlipper") == 1 && Input.GetAxis("LFlipper") == 1)        // Player 1 ready
                {
                    BallGravity.ballFreeze = false;
                    ballRigidbody.WakeUp();
                    holdControlsTextRed.enabled = false;
                    holdControlsTextDark.enabled = false;
                }
            }
        }
    }
}
