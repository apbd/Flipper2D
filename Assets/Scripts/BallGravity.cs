 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGravity : MonoBehaviour {

   
    
    public Rigidbody2D ballRigidbody;
    public Transform ballTransform;

    public float ballSpeed = 1.0f;
    public bool soundHasPlayer = false;
    public static bool ballFreeze;
    public float gravityPowerup;


    List<int> throwOptions = new List<int> { 10, -10, 5, -5, 2, -2, 8, -8, 4, -4 };      // Options for which side ball is thrown (so it doesnt get thrown at 90 degrees to the wall)
    private int horizontalThrow;
    private float verticalThrow;

    public TrailRenderer whiteBallTrail, blackBallTrail;

    // special ball 
    private GameObject ball;
    public bool lastSpecialBall = false;

    

    void Start()
    {
        gravityPowerup = 1.0f;
        ballTransform = GetComponent<Transform>();
        ballRigidbody = GetComponent<Rigidbody2D>();
        whiteBallTrail = GetComponent<TrailRenderer>();
      
        blackBallTrail = this.transform.Find("trails/black_ball_trail").GetComponent<TrailRenderer>();

        ball = this.gameObject;
        if (ball.name.Contains("SpecialBall"))
        {
            StartCoroutine(BallReset());
        }
    }

    void FixedUpdate()
    {
        horizontalThrow = throwOptions[Random.Range(0, 7)];  // horizontal throw every round
        ballRigidbody.velocity *= ballSpeed;

        if (ballFreeze == true)
        {
            ballRigidbody.Sleep();
        }
        else
        {
            ballRigidbody.WakeUp();
        }
    }

    void Awake()
    {
        verticalThrow = Random.Range(-10.0f, 5.0f); // vertical throw at match start
    }

    void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.name == "ylä")
        {
            ballRigidbody.gravityScale = -1.0f  * gravityPowerup;
        }

        if (other.gameObject.name == "ala")
        {
            ballRigidbody.gravityScale = 1.0f * gravityPowerup;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!soundHasPlayer)
        {
            soundManager.PlaySound("ball");
            soundHasPlayer = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        soundHasPlayer = false;

    }

    //RESPAWNIN
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {
            //which side continues

            if (other.gameObject.name == "UpperRespawn")
            {
                verticalThrow = 3.0f;
            }

            if (other.gameObject.name == "LowerRespawn")
            {
                verticalThrow = -3.0f;
            }

            // if special ball is last, destroy
            if (lastSpecialBall == true)
            {
                Destroy(this.gameObject);
            }
            else
            {
                ballTransform.transform.position = new Vector2(0, 0);
                other.GetComponent<BallRestarter>().ballSpawntParticles.Play();
                //reset ball after 0.3f because trails
                StartCoroutine(BallReset());
            }
        }
    }
    IEnumerator BallReset()
    {
        Debug.Log("Goal!!");
        ballRigidbody.Sleep();
         blackBallTrail.Clear();
         whiteBallTrail.Clear();

        yield return new WaitForSeconds(0.3f);
        //GameObject.FindGameObjectWithTag("Ball").GetComponent<BallGravity>().ResetBall();

        
        Debug.Log("Ball restartted.");
        
        //pallotrans.transform.position = new Vector2(0, 0);
        ballRigidbody.velocity = new Vector2(horizontalThrow, verticalThrow);
        //blacktrail.emitting = true;   //ei toimi dunno
    }

    public Rigidbody2D getRigidbody()
    {
        return (ballRigidbody);
    }

    public void BallLastlife(bool last)
    {
        this.lastSpecialBall = last;
        Debug.Log(lastSpecialBall);
    }
}
