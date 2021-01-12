using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviour : MonoBehaviour
{
   
    public PowerupController controller;

    [SerializeField]

    private Powerup powerup;

    private SpriteRenderer spriterenderer;

    public ParticleSystem pasystem; //tarvitaan powerupeille psystem komponentti plaplapla

    private Transform transform_;

    public Animator animator;

    private void Awake()
    {
        
        transform_ = transform;
        //ottaa objetin spriterenderin haltuun
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Ball") //pallo törmää 
        {
            soundManager.PlaySound("powerup");
            ActivatePowerup();
            gameObject.SetActive(false);


        }
    }

    private void ActivatePowerup()
    {
        controller.ActivatePowerup(powerup);
    }

    public void SetPowerup(Powerup powerup)
    {
        this.powerup = powerup;
        gameObject.name = powerup.name;
        //laittaa haltuunotettuun spriterenderiin spriten joka on tullut powerupin mukana joka on laitettu powerupcontrollerissa
        spriterenderer.sprite = powerup.sprite;
    }
}
