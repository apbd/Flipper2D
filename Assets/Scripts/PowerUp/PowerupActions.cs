using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupActions : MonoBehaviour
{

    [SerializeField]

    public Rigidbody2D pallo;

    public BallGravity ballgravity;
    public GameObject[] ballgravitys;

    public TrailRenderer whitetrail;
    public GameObject specialBall;

    public ParticleSystem ParSysExtra;

    

    private void Start()
    {
        Time.timeScale = 1.5f; //global timescale
        
        pallo = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallGravity>().getRigidbody();
        whitetrail = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallGravity>().whiteBallTrail;
    }
    private void FixedUpdate()
    {
        ballgravitys = GameObject.FindGameObjectsWithTag("Ball");
        
    }
    public void HighSpeedStartAction()
    {

        //powerupit ei toimi koska scripti voi hoitaa vaan yhen kerrallaa 
        //-> pitäis tehä sammalaine ku powerup dictionary systeemi

        foreach(GameObject obj in ballgravitys)
        {
            obj.GetComponent<BallGravity>().ballSpeed = 1.04f;
            obj.GetComponent<BallGravity>().whiteBallTrail.startColor = Color.yellow;
            obj.GetComponent<BallGravity>().whiteBallTrail.endColor = Color.red;
           
        }
       
    }

    public void HighSpeedEndAction()
    {
        foreach (GameObject obj in ballgravitys)
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
        ballgravity.transform.localScale = new Vector3(0.09f, 0.09f, 0);
        HoldC.pallonrigid.mass = 100.0f;
        whitetrail.startWidth = 1.0f;
    }

    public void BigBallEndAction()
    {
        //Debug.Log("poweruploppu");
        ballgravity.transform.localScale = new Vector3(0.05f, 0.05f, 0);
        HoldC.pallonrigid.mass = 0.7f;
        whitetrail.startWidth = 0.5f;
    }

    public void ExtraStartAction()
    {
        ParSysExtra.Play();
        Instantiate(specialBall, new Vector2(0, 0), Quaternion.identity);
    }

    public void ExtraEndAction()
    {
        
        foreach (GameObject obj in ballgravitys)
        {
            if (obj.name.Contains("SpecialBall"))
            {
                obj.GetComponent<BallGravity>().BallLastlife(true);
            }
        }
    }

    public void GravityStartAction()
    {
        
        ballgravity.gravityPowerup = 0.001f;
        Debug.Log("gravity activoitu");
    }

    public void GravityEndAction()
    {
        //Debug.Log("poweruploppu");
        ballgravity.gravityPowerup = 1.0f;
    }
}
