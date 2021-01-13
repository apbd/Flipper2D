using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupActions : MonoBehaviour
{

    [SerializeField]

    public Rigidbody2D ballRigidbody;

    public BallGravity ballGravity;
    public GameObject[] ballGravitiesList;

    public TrailRenderer whiteBallTrail;
    public GameObject specialBall;

    public ParticleSystem specialBallParticleSys;

    

    private void Start()
    {
        // global timescale
        Time.timeScale = 1.5f; 
        
        ballRigidbody = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallGravity>().getRigidbody();
        whiteBallTrail = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallGravity>().whiteBallTrail;
        specialBallParticleSys = GameObject.Find("ParticleSystems/SpecialSpawnParticleSys").GetComponent<ParticleSystem>();

    }
    private void FixedUpdate()
    {
        ballGravitiesList = GameObject.FindGameObjectsWithTag("Ball");
        
    }
    public void HighSpeedStartAction()
    {

        // script allows only one powerup per time
        //-> need to make powerup dictionary system if its needed

        foreach(GameObject obj in ballGravitiesList)
        {
            obj.GetComponent<BallGravity>().ballSpeed = 1.04f;
            obj.GetComponent<BallGravity>().whiteBallTrail.startColor = Color.yellow;
            obj.GetComponent<BallGravity>().whiteBallTrail.endColor = Color.red;
           
        }
       
    }

    public void HighSpeedEndAction()
    {
        foreach (GameObject obj in ballGravitiesList)
        {
            if(obj.name.Contains("SpecialBall"))
            {
                obj.GetComponent<BallGravity>().whiteBallTrail.startColor = Color.magenta;
                obj.GetComponent<BallGravity>().whiteBallTrail.endColor = Color.clear;
            }
            else
            {
                obj.GetComponent<BallGravity>().whiteBallTrail.startColor = Color.white;
                obj.GetComponent<BallGravity>().whiteBallTrail.endColor = Color.clear;
            }
            
            obj.GetComponent<BallGravity>().ballSpeed = 1.0f;
        }
    }

    public void BigBallStartAction()
    {
        ballGravity.transform.localScale = new Vector3(0.09f, 0.09f, 0);
        ShowControls.ballRigidbody.mass = 100.0f;
        whiteBallTrail.startWidth = 1.0f;
    }

    public void BigBallEndAction()
    {
        //Debug.Log("poweruploppu");
        ballGravity.transform.localScale = new Vector3(0.05f, 0.05f, 0);
        ShowControls.ballRigidbody.mass = 0.7f;
        whiteBallTrail.startWidth = 0.5f;
    }

    public void ExtraStartAction()
    {
        specialBallParticleSys.Play();
        Instantiate(specialBall, new Vector2(0, 0), Quaternion.identity);
    }

    public void ExtraEndAction()
    {
        
        foreach (GameObject obj in ballGravitiesList)
        {
            if (obj.name.Contains("SpecialBall"))
            {
                obj.GetComponent<BallGravity>().BallLastlife(true);
            }
        }
    }

    public void GravityStartAction()
    {
        
        ballGravity.gravityPowerup = 0.001f;
        Debug.Log("gravity activoitu");
    }

    public void GravityEndAction()
    {
        //Debug.Log("poweruploppu");
        ballGravity.gravityPowerup = 1.0f;
    }
}
