using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperMover : MonoBehaviour {
    public float speed = 750f;
    private HingeJoint2D myHingeJoint;
    private JointMotor2D motor2D;
    public int suunta;
    public int suunta2;
    public string inputName;

   
    private bool hasPlayed = false;

    public string swapPlayerLetter = "";
    public static bool swapped = false;

    void Start ()
    {
       

        myHingeJoint = GetComponent<HingeJoint2D>();
        motor2D = myHingeJoint.motor;
        System.Console.WriteLine("Input.GetAxis(inputName)");
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (swapped)
        {
            swapPlayerLetter = "P2";

        }
        else
        {
            swapPlayerLetter = "";
        }

        if (gameObject.name == "flipperR") //vaihtaa flipperien suunnan oikeaksi
        {
            inputName = swapPlayerLetter + "RFlipper";
            suunta = -1;
            suunta2 = 1;
        }
        if (gameObject.name == "flipperL")
        {
            inputName = swapPlayerLetter + "LFlipper";
            suunta = 1;
            suunta2 = -1;
        }
        //Debug.Log(Input.GetAxis(inputName));

        

        //saa inputnamen ja katsoo mikä nimi inputissa on ja ottaa siitä inputin 
        if (Input.GetAxis(inputName) == 1)
        {
            
            
            motor2D.motorSpeed = suunta2 * speed;
            myHingeJoint.motor = motor2D;
            if (!hasPlayed)
            {
                SoundManager.PlaySound("flipper");
                hasPlayed = true;
            }
                
        }
        else
        {
            motor2D.motorSpeed = suunta * speed;
            myHingeJoint.motor = motor2D;
          
            hasPlayed = false;
        }

	}
}
