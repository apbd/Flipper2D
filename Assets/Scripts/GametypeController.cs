using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GametypeController : MonoBehaviour
{

    void Start()
    {
        switch (MainMenu.gametype)
        {
            case MainMenu.GameType.solo:
                GetComponent<P2FlipperMover>().enabled = false;
                GetComponent<CPU2>().enabled = true;

                break;
            case MainMenu.GameType.local:
                GetComponent<P2FlipperMover>().enabled = true;
                GetComponent<CPU2>().enabled = false;
                break;
            case MainMenu.GameType.online:
                break;
            default:
                break;
        }

    }

    void Update()
    {

    }


}
