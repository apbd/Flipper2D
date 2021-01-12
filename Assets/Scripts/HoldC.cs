using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldC : MonoBehaviour
{
    public Text holdcontrols;
    public Text holdcontrolsred;
    public GameObject controls;
    public Text holdc;
    public GameObject palloite;
    public static Rigidbody2D pallonrigid;

    void Start()
    {
        
        palloite = GameObject.FindGameObjectWithTag("Ball");
       
        pallonrigid = palloite.GetComponent<Rigidbody2D>();
        Debug.Log(palloite);
        Debug.Log(pallonrigid);
      //  MainMenu.gametype = MainMenu.GameType.local;

        if (MainMenu.gametype == MainMenu.GameType.local)
        {
            BallGravity.ballFreeze = true;
            holdc.enabled = true;

        }

        
    }


    void FixedUpdate()
    {
        if (MainMenu.gametype == MainMenu.GameType.local)
        {

            if (Input.GetKey("c"))
            {
                controls.SetActive(true);

            }
            else
            {
                controls.SetActive(false);
            }


            if (BallGravity.ballFreeze == true)
            {
                controls.SetActive(true);
                holdcontrols.enabled = true;
                holdcontrolsred.enabled = true;
                pallonrigid.Sleep();




                if (Input.GetAxis("P2RFlipper") == 1 && Input.GetAxis("P2LFlipper") == 1 &&  //p2
                    Input.GetAxis("RFlipper") == 1 && Input.GetAxis("LFlipper") == 1)        //p1
                {
                    BallGravity.ballFreeze = false;
                    pallonrigid.WakeUp();
                    holdcontrolsred.enabled = false;
                    holdcontrols.enabled = false;
                }
            }
        }
    }
}
