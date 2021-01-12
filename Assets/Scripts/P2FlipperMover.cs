using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2FlipperMover : MonoBehaviour
{
    public float speed = 750f;
    private HingeJoint2D myHingeJoint;
    private JointMotor2D motor2D;
    public int suunta;
    public int suunta2;
    public string inputName;


    public static bool inverted = false;
    
    private bool hasPlayed = false;


    private string swapLetterR2 = "R";
    private string swapLetterL2 = "L";
    public string swapPlayerLetter = "P2";
    public static bool swapped = false;

    void Start()
    {

  

        myHingeJoint = GetComponent<HingeJoint2D>();
        motor2D = myHingeJoint.motor;
        System.Console.WriteLine("Input.GetAxis(inputName)");



            
        
    }
   

    void FixedUpdate()
    {

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

        if (swapped)
        {
            swapPlayerLetter = "";
          
        }
        else
        {
            swapPlayerLetter = "P2";
        }

        //inverted vaihtaa vain muuttujat ristiin

        if (gameObject.name == "2flipperR_name")  //huom R //katsoo mikä objecti on kyseessä
            {
                inputName = swapPlayerLetter + swapLetterR2 + "Flipper"; //huom L
                suunta = -1;            //vaihtaa flipperien suunnan oikeaksi
                suunta2 = 1;
            }
            if (gameObject.name == "2flipperL_name")
            {
                inputName = swapPlayerLetter + swapLetterL2 + "Flipper";
                suunta = 1;
                suunta2 = -1;  //<- ovat jo ristissä vaikkei siltä näytä
            } /*
        }

        else
        {
            if (gameObject.name == "2flipperR" + swapLetterR2) //huom R //katsoo mikä objecti on kyseessä
            {

                inputName = "P2RFlipper";    //huom R
                suunta = -1;              //vaihtaa flipperien suunnan oikeaksi
                suunta2 = 1;
            }
            if (gameObject.name == "2flipperL" + swapLetterL2)
            {
                inputName = "P2LFlipper";
                suunta = 1;
                suunta2 = -1;
            }

        }
        */



        //saa inputnamen ja katsoo mikä nimi inputissa on ja ottaa siitä inputin 
        if (Input.GetAxis(inputName) == 1)
        {

            motor2D.motorSpeed = suunta2 * speed;
            myHingeJoint.motor = motor2D;
            if (!hasPlayed)
            {
                soundManager.PlaySound("flipper");
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
