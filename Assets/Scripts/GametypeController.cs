using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GametypeController : MonoBehaviour
{

    void Start()
    {
        // enable correct components based on gameype
        switch (MainMenu.gametype)
        {
            case MainMenu.GameType.solo:
                GetComponent<P2FlipperMover>().enabled = false;
                GetComponent<CPUFlipperMover>().enabled = true;
                break;
            case MainMenu.GameType.local:
                GetComponent<P2FlipperMover>().enabled = true;
                GetComponent<CPUFlipperMover>().enabled = false;
                break;
            case MainMenu.GameType.online:
                break;
            default:
                break;
        }
    }
}
