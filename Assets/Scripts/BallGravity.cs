 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGravity : MonoBehaviour {

   
    
    public Rigidbody2D ballRigidbody;
    public Transform ballTransform;

    public float ballSpeed = 1.0f;
    public bool soundHasPlayed = false;
    public static bool ballFreeze;
    public float gravityPowerup;

    // Options for which side ball is thrown (so it doesnt get thrown at 90 degrees to the wall)
    List<int> throwOptions = new List<int> { 10, -10, 5, -5, 2, -2, 8, -8, 4, -4 };      
    private int _horizontalThrow;
    private float _verticalThrow;

    public TrailRenderer whiteBallTrail, blackBallTrail;

    // special ball 
    private GameObject _ball;
    public bool lastSpecialBall = false;

    

    void Start()
    {
        gravityPowerup = 1.0f;
        ballTransform = GetComponent<Transform>();
        ballRigidbody = GetComponent<Rigidbody2D>();
        whiteBallTrail = GetComponent<TrailRenderer>();
      
        blackBallTrail = this.transform.Find("trails/black_ball_trail").GetComponent<TrailRenderer>();

        _ball = this.gameObject;
        if (_ball.name.Contains("SpecialBall"))
        {
            StartCoroutine(BallReset());
        }
    }

    void FixedUpdate()
    {
        _horizontalThrow = throwOptions[Random.Range(0, 7)];  // horizontal throw every round
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
        _verticalThrow = Random.Range(-10.0f, 5.0f); // vertical throw at match start
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // Change gravity based on which zone the ball is in
        if (other.gameObject.name == "UpperZone")
        {
            ballRigidbody.gravityScale = -1.0f  * gravityPowerup;
        }

        if (other.gameObject.name == "LowerZone")
        {
            ballRigidbody.gravityScale = 1.0f * gravityPowerup;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!soundHasPlayed)
        {
            SoundManager.PlaySound("ball");
            soundHasPlayed = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        soundHasPlayed = false;
    }

    //RESPAWNIN
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {
            //which side continues

            if (other.gameObject.name == "UpperGoal")
            {
                _verticalThrow = 3.0f;
            }

            if (other.gameObject.name == "LowerGoal")
            {
                _verticalThrow = -3.0f;
            }

            // if special ball is last, destroy
            if (lastSpecialBall == true)
            {
                Destroy(this.gameObject);
            }
            else
            {
                ballTransform.transform.position = new Vector2(0, 0);
                other.GetComponent<BallRestarter>().ballSpawntParticleSys.Play();
                // Reset ball after 0.3f because trails
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
        ballRigidbody.velocity = new Vector2(_horizontalThrow, _verticalThrow);
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
