using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restarttaaja : MonoBehaviour
{
    public Rigidbody2D pallrigid;

    private BallGravity gravcomponent;
    //randomizer
    private int randomi1;
    private float randomi2;

    List<int> lista = new List<int> { 10,-10,5,-5,2,-2,8,-8,4,-4}; //sivusuunta heitto
    private int sivul;
    private float pystyl;
    
    public ParticleSystem psystem;
    /*
    public GameObject pallotrails;
    public TrailRenderer blacktrail, whitetrail;
    */

    // !! EI PYSTY TEKEMÄÄN KAIKKIEN PALLOJEN ASIOITA SAMANAIKAISESTI -> VAIN AINOASTAAN YHDEN PALLON ASIOITA
    //ELI SIIRRÄ KAIKKI PALLOON LIITTYVÄT BALLGRAVITYYN JA PIDÄ PISTEET ÄÄNET YMS TÄSSÄ.


    void Update()
    {
        

        randomi1 = Random.Range(0, 7); //sivul
        sivul = lista[randomi1];

    }
    void Awake()
    {
        randomi2 = Random.Range(-10.0f, 5.0f); //ylös alas heitto
        pystyl = randomi2;
        
    }
    void Start()
    {
        gravcomponent = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallGravity>();
        pallrigid = gravcomponent.getRigidbody();
    }
    void OnTriggerEnter2D(Collider2D other)
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

            soundManager.PlaySound("piste");
            soundManager.PlaySound("piste");
        }
    }
    

       


}
