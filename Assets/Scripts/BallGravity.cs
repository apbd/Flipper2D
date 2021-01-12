 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGravity : MonoBehaviour {

   
    
    public Rigidbody2D palloRigidBody2d;
    public Transform palloTransform;
    public float nopeus = 1.0f;
    
    public bool hasPlayed = false;
    
    public static bool freeze;

    public float gravitypowerup;

    //RESPAWNIN
    private int randomi1;
    private float randomi2;

    List<int> sivulista = new List<int> { 10, -10, 5, -5, 2, -2, 8, -8, 4, -4 }; //sivusuunta heitto
    private int sivul;
    private float pystyl;

    public TrailRenderer whitetrail, blacktrail;

    //special ball
    private GameObject ball;
    public bool lastLife = false;

    

    void Start()
    {
        gravitypowerup = 1.0f;
        palloTransform = GetComponent<Transform>();
        palloRigidBody2d = GetComponent<Rigidbody2D>();
        whitetrail = GetComponent<TrailRenderer>();
      
        blacktrail = this.transform.Find("trails/pallotrailblack").GetComponent<TrailRenderer>();

        ball = this.gameObject;
        if (ball.name.Contains("SpecialBall"))
        {
            
            StartCoroutine(BallReset());
        }
    }

    void FixedUpdate()
    {

        randomi1 = Random.Range(0, 7); //sivul
        sivul = sivulista[randomi1];

        palloRigidBody2d.velocity *= nopeus;

        if (freeze == true)
        {
            palloRigidBody2d.Sleep();
        }
        else
        {
            palloRigidBody2d.WakeUp();
        }
    }

    void Awake()
    {
        randomi2 = Random.Range(-10.0f, 5.0f); //ylös alas heitto
        pystyl = randomi2;

    }

    void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.name == "ylä")
        {
            palloRigidBody2d.gravityScale = -1.0f  * gravitypowerup;
        }

        if (other.gameObject.name == "ala")
        {
            palloRigidBody2d.gravityScale = 1.0f * gravitypowerup;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!hasPlayed)
        {
            soundManager.PlaySound("pallo");
            hasPlayed = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        hasPlayed = false;

    }

    //RESPAWNIN
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {

           


            //which side continues

            if (other.gameObject.name == "UpperRespawn")
            {
                pystyl = 3.0f;
            }

            if (other.gameObject.name == "LowerRespawn")
            {
                pystyl = -3.0f;
            }

            //for special balls 
            if (lastLife == true)
            {
                Destroy(this.gameObject);
            }
            else
            {
                palloTransform.transform.position = new Vector2(0, 0);
                other.GetComponent<Restarttaaja>().psystem.Play();
                //reset ball after 0.3f because trails
                StartCoroutine(BallReset());
            }
        }
    }
    IEnumerator BallReset()
    {
        Debug.Log("Goal!!");
        palloRigidBody2d.Sleep();
         blacktrail.Clear();
         whitetrail.Clear();

        yield return new WaitForSeconds(0.3f);
        //GameObject.FindGameObjectWithTag("Ball").GetComponent<BallGravity>().ResetBall();

        
        Debug.Log("Ball restartted.");
        
        //pallotrans.transform.position = new Vector2(0, 0);
        palloRigidBody2d.velocity = new Vector2(sivul, pystyl);
        //blacktrail.emitting = true;   //ei toimi dunno
    }

    public Rigidbody2D getRigidbody()
    {
        return (palloRigidBody2d);
    }

    public void BallLastlife(bool t)
    {
        this.lastLife = t;
        Debug.Log(lastLife);
    }
}
