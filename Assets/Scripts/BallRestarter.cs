using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRestarter : MonoBehaviour
{
    public Rigidbody2D ballRigidbody;
    private BallGravity ballGravity;


    
    public ParticleSystem ballSpawntParticleSys;


    // rambling:
    // !! EI PYSTY TEKEMÄÄN KAIKKIEN PALLOJEN ASIOITA SAMANAIKAISESTI -> VAIN AINOASTAAN YHDEN PALLON ASIOITA
    // ELI SIIRRÄ KAIKKI PALLOON LIITTYVÄT BALLGRAVITYYN JA PIDÄ PISTEET ÄÄNET YMS TÄSSÄ.
    



    void Start()
    {
        ballGravity = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallGravity>();    // get ball gravity component from scene
        ballRigidbody = ballGravity.getRigidbody();   // use ball gravity objects rigidbody
        ballSpawntParticleSys = GameObject.Find("ParticleSystems/RespawnParticleSys").GetComponent<ParticleSystem>();
    }   


    void OnTriggerEnter2D(Collider2D other) // when ball enters a goal give point
    {
        if (other.CompareTag("Ball")) 
        { 
            if (gameObject.name == "UpperGoal")
            {
                Score.p2 += 1;
            }

            if (gameObject.name == "LowerGoal")
            {
                Score.p1 += 1;
            }

            SoundManager.PlaySound("point");
            SoundManager.PlaySound("point");
        }
    }
    

       


}
