using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip ballSound, flipperSound, pointSound, powerupSound;
    static AudioSource audioSource;
    void Start()
    {
        ballSound = Resources.Load<AudioClip>("ball");
        flipperSound = Resources.Load<AudioClip>("flipper");
        pointSound = Resources.Load<AudioClip>("point");
        powerupSound = Resources.Load<AudioClip>("powerup");

        audioSource = GetComponent<AudioSource>();
    }
    
    public static void PlaySound (string clip)
    {
        audioSource.volume = 1.0f;
        switch (clip)
        {
            case "ball":
                audioSource.PlayOneShot(ballSound);
                break;
            case "flipper":
                audioSource.volume = 0.3f;
                audioSource.PlayOneShot(flipperSound);   // BUG: when everyone uses flipper the sound is 4x
                break;
            case "point":
                audioSource.volume = 10.0f;
                audioSource.PlayOneShot(pointSound);
                break;
            case "powerup":
                audioSource.PlayOneShot(powerupSound);
                break;

        }
    }
}
