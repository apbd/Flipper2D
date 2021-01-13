using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU2 : MonoBehaviour
{
    public float speed = 750f;
    private HingeJoint2D myHingeJoint;
    private JointMotor2D motor2D;

    public int suunta = 1;
    public int suunta2 = -1;
    
    

    public string inputName;
    public static string activate;
    
    private bool hasPlayed = true;

    void Start()
    {
        myHingeJoint = GetComponent<HingeJoint2D>();
        motor2D = myHingeJoint.motor;
        
      

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (inputName == "2RFlipper") //vaihtaa flipperien suunnan oikeaksi (ei liikuta flippreitä, se on motor mikä liikuttaa)
        {
            
            suunta = -1;
            suunta2 = 1;
            
        }
        else if (inputName == "2LFlipper")
        {
            suunta = 1;
            suunta2 = -1;
        }

        //Debug.Log(activateR);
       // Debug.Log(activateL);

       //skripti luo flippereist kaks oliota ja täl tietää kumpaa liikuttaa koska triggerit eri skriptissä/esineissä
       //eli tämä liikuttaa molempia
        if (inputName == activate)
        {
            if (!hasPlayed)
            {
                SoundManager.PlaySound("flipper");
                hasPlayed = true;
            }
            
            motor2D.motorSpeed = suunta2 * speed;
            myHingeJoint.motor = motor2D;
           // Debug.Log(motor2D.motorSpeed);
        }
        else
        {
            hasPlayed = false;
            motor2D.motorSpeed = suunta * speed;
            myHingeJoint.motor = motor2D;
           

        }
    }

}
