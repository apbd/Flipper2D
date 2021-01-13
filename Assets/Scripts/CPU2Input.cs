using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU2Input : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        // if ball hits trigger zone
        if (other.CompareTag("Ball"))
        {
            // if that zone is R1
            if(gameObject.name == "R1")
            {
                Debug.Log(gameObject.name);
                CPUFlipperMover.activate = "P2FlipperR";
            }
            else
            {
                CPUFlipperMover.activate = "P2FlipperL";
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // whebn ball leaves zone, put flippers down
        if (other.CompareTag("Ball"))

        {
            if (gameObject.name == "R1")
            {
                CPUFlipperMover.activate = "Still";
            }
            else
            {
                CPUFlipperMover.activate = "Still";
            }
        }
    }
}
