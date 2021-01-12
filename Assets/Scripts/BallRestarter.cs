using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRestarter : MonoBehaviour
{
    public Rigidbody2D ballRigidbody;
    private BallGravity ballGravity;


    
    public ParticleSystem ballSpawntParticles;


    // rambling:
    // !! EI PYSTY TEKEMÄÄN KAIKKIEN PALLOJEN ASIOITA SAMANAIKAISESTI -> VAIN AINOASTAAN YHDEN PALLON ASIOITA
    // ELI SIIRRÄ KAIKKI PALLOON LIITTYVÄT BALLGRAVITYYN JA PIDÄ PISTEET ÄÄNET YMS TÄSSÄ.
    



    void Start()
    {
        ballGravity = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallGravity>();    //get ball gravity component from scene
        ballRigidbody = ballGravity.getRigidbody();   // use ball gravity objects rigidbody
    }   


    void OnTriggerEnter2D(Collider2D other) // when ball enters a goal give point
    {
        if (other.CompareTag("Ball")) 
        { 
            if (gameObject.name == "UpperRespawn")
            {
                Score.p2 += 1;
            }

            if (gameObject.name == "LowerRespawn")
            {
                Score.p1 += 1;
            }

            soundManager.PlaySound("point");
            soundManager.PlaySound("point");
        }
    }
    

       


}
