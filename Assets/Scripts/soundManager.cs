using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static AudioClip ballSound, flipperSound, pointSound, powerupSound;
    static AudioSource audioSrc;
    void Start()
    {
        ballSound = Resources.Load<AudioClip>("ball");
        flipperSound = Resources.Load<AudioClip>("flipper");
        pointSound = Resources.Load<AudioClip>("point");
        powerupSound = Resources.Load<AudioClip>("powerup");

        audioSrc = GetComponent<AudioSource>();
    }
    
    public static void PlaySound (string clip)
    {
        audioSrc.volume = 1.0f;
        switch (clip)
        {
            case "ball":
                audioSrc.PlayOneShot(ballSound);
                break;
            case "flipper":
                audioSrc.volume = 0.3f;
                audioSrc.PlayOneShot(flipperSound);   // BUG: when everyone uses flipper the sound is 4x
                break;
            case "point":
                audioSrc.volume = 10.0f;
                audioSrc.PlayOneShot(pointSound);
                break;
            case "powerup":
                audioSrc.PlayOneShot(powerupSound);
                break;

        }
    }
}
