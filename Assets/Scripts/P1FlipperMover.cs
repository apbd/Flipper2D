using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1FlipperMover : MonoBehaviour 
{
    public float speed = 750f;
    private HingeJoint2D myHingeJoint;
    private JointMotor2D motor2D;
    public int flipperDown;
    public int flipperUp;
    public string inputName;

    private bool _soundHasPlayed = false;

    public string swapPlayerLetter;
    public static bool swapped = false;

    void Start ()
    {
        myHingeJoint = GetComponent<HingeJoint2D>();
        motor2D = myHingeJoint.motor;
    }

    void FixedUpdate () {

        if (swapped)
        {
            swapPlayerLetter = "P2";
        }
        else
        {
            swapPlayerLetter = "P1";
        }


        // changes orientation of flippers to correct position (doesnt directly move flippers, thats motor)
        if (gameObject.name == "P1FlipperR")
        {
            // Right Flipper Idle: -1 (Down) 
            // Right Flipper Activated: 1 (Up)
            inputName = swapPlayerLetter + "FlipperR";
            flipperDown = -1;
            flipperUp = 1;
        }
        if (gameObject.name == "P1FlipperL")
        {
            // Left Flipper Idle: 1 (Down) 
            // Left Flipper Activated: -1   (Up) 
            inputName = swapPlayerLetter + "FlipperL";
            flipperDown = 1;
            flipperUp = -1;
        }


        // gets inputName and checks which string it is and uses that to move flippers
        // this moves both flippers
        if (Input.GetAxis(inputName) == 1)
        {
            motor2D.motorSpeed = flipperUp * speed;
            myHingeJoint.motor = motor2D;
            if (!_soundHasPlayed)
            {
                SoundManager.PlaySound("flipper");
                _soundHasPlayed = true;
            }
                
        }
        else
        {
            motor2D.motorSpeed = flipperDown * speed;
            myHingeJoint.motor = motor2D;
          
            _soundHasPlayed = false;
        }

	}
}
