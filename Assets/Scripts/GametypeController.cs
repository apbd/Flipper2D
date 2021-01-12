using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GametypeController : MonoBehaviour
{
    public GameObject f2R;
    public GameObject f2L;

    public GameObject gm;

    void Start()
    {
       //MainMenu.gametype = MainMenu.GameType.online;
        Debug.Log(MainMenu.gametype);
        switch (MainMenu.gametype)
        {
            case MainMenu.GameType.solo:

                f2L.GetComponent<P2FlipperMover>().enabled = false;
                f2R.GetComponent<P2FlipperMover>().enabled = false;

                f2R.GetComponent<CPU2>().enabled = true;
                f2L.GetComponent<CPU2>().enabled = true;

                gm.SetActive(false);
                break;

            case MainMenu.GameType.local:
                f2L.GetComponent<P2FlipperMover>().enabled = true;
                f2R.GetComponent<P2FlipperMover>().enabled = true;

                f2L.GetComponent<CPU2>().enabled = false;
                f2R.GetComponent<CPU2>().enabled = false;

                gm.SetActive(false);
                break;

            case MainMenu.GameType.online:
                f2L.GetComponent<CPU2>().enabled = false;
                f2R.GetComponent<CPU2>().enabled = false;

                f2L.GetComponent<P2FlipperMover>().enabled = false;
                f2R.GetComponent<P2FlipperMover>().enabled = false;

              // gm = GameObject.Find("GameManager2");
                gm.SetActive(true);
                Debug.Log("opoosdfpo" + gm);

                break;
            default:
                break;
        }

    }



}
