using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Force : MonoBehaviour
{
    public int testi;
    public Rigidbody2D pallo1;
    

    void OnTriggerEnter2D(Collider2D other)
    {
         //Debug.Log(other);
        if (other.CompareTag("Ball"))

        {
            //Debug.Log(pallo1);
            testi++;
            pallo1.AddForce(Vector2.down * 1500);
            
        }
    }

}

