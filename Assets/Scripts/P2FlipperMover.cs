using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2FlipperMover : MonoBehaviour
{
    public float speed = 750f;
    private HingeJoint2D myHingeJoint;
    private JointMotor2D motor2D;
    public int flipperDown;
    public int flipperUp;
    public string inputName;

    public static bool inverted = false;
    
    private bool _soundHasPlayed = false;


    private string swapLetterR2 = "R";
    private string swapLetterL2 = "L";
    public string swapPlayerLetter = "P2";
    public static bool swapped = false;

    void Start()
    {
        myHingeJoint = GetComponent<HingeJoint2D>();
        motor2D = myHingeJoint.motor;
    }
   

    void FixedUpdate()
    {

        // inverted just switches string values
        if (inverted)
        {
            swapLetterR2 = "L";
            swapLetterL2 = "R";
        }
        else
        {
            swapLetterR2 = "R";
            swapLetterL2 = "L";
        }

        // changes string value
        if (swapped)
        {
            swapPlayerLetter = "P1";
        }
        else
        {
            swapPlayerLetter = "P2";
        }


        if (gameObject.name == "P2FlipperR")  
            {
                inputName = swapPlayerLetter + "Flipper" + swapLetterR2 ; 
                flipperDown = -1;          
                flipperUp = 1;
            }
            if (gameObject.name == "P2FlipperL")
            {
                inputName = swapPlayerLetter + "Flipper" + swapLetterL2;
                flipperDown = 1;
                flipperUp = -1;
            } 


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
