using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU2Input : MonoBehaviour
{

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))

        {
            if(gameObject.name == "R1")
            {
                //Debug.Log(gameObject.name);
                CPU2.activate = "2LFlipper";
            }
            else
            {
                CPU2.activate = "2RFlipper";
                //Debug.Log(gameObject.name);
            }
            

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))

        {
            if (gameObject.name == "R1")
            {
                CPU2.activate = "Still";
            }
            else
            {
                CPU2.activate = "Still";
            }

        }
        

    }
}
