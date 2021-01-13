using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviour : MonoBehaviour
{
   
    public PowerupController controller;

    [SerializeField]

    private Powerup powerup;

    private SpriteRenderer spriteRenderer;

    public ParticleSystem powerupParticleSys;  //powerups need particlesystem component etc

    public Animator animator;

    private void Awake()
    {
        // takes spriterender of powerup
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Ball") // ball collision with powerup
        {
            SoundManager.PlaySound("powerup");
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
        // assign powerup object's renderer a sprite that can be changed in powerupcontroller
        spriteRenderer.sprite = powerup.sprite;
    }
}
