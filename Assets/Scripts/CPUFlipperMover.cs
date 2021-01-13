using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUFlipperMover : MonoBehaviour
{
    public float speed = 750f;
    private HingeJoint2D myHingeJoint;
    private JointMotor2D motor2D;
    public int flipperDown;
    public int flipperUp;
    public string inputName;


    public static string activate;
    
    private bool _soundHasPlayed = true;

    void Start()
    {
        myHingeJoint = GetComponent<HingeJoint2D>();
        motor2D = myHingeJoint.motor;
    }

    void FixedUpdate()
    {
        // changes direction of flippers to correct position (doesnt move flippers, thats motor)
        if (inputName == "P2FlipperR")
        {
            // (from players angle)
            // Right  Flipper Idle: -1   (Down) 
            // Right Flipper Activated: 1   (Up) 
            flipperDown = -1;
            flipperUp = 1;

        }
        else if (inputName == "P2FlipperL")
        {
            // Left Flipper Idle: 1   (Down) 
            // Left Flipper Activated: -1    (Up)
            flipperDown = 1;
            flipperUp = -1;
        }

        //Debug.Log(activateR);
       // Debug.Log(activateL);


        // users triggers to know if flipper is activated
        if (inputName == activate)
        {
            if (!_soundHasPlayed)
            {
                SoundManager.PlaySound("flipper");
                _soundHasPlayed = true;
            }
            
            motor2D.motorSpeed = flipperUp * speed;
            myHingeJoint.motor = motor2D;
           // Debug.Log(motor2D.motorSpeed);
        }
        else
        {
            _soundHasPlayed = false;
            motor2D.motorSpeed = flipperDown * speed;
            myHingeJoint.motor = motor2D;
           

        }
    }

}
