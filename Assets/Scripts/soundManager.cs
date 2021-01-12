using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static AudioClip palloSound, flipperSound, pisteSound, powerupSound;
    static AudioSource audioSrc;
    void Start()
    {
        palloSound = Resources.Load<AudioClip>("pallo");
        flipperSound = Resources.Load<AudioClip>("flipper");
        pisteSound = Resources.Load<AudioClip>("piste");
        powerupSound = Resources.Load<AudioClip>("powerup");

        audioSrc = GetComponent<AudioSource>();
    }
    
    public static void PlaySound (string clip)
    {
        audioSrc.volume = 1.0f;
        switch (clip)
        {
            case "pallo":
                audioSrc.PlayOneShot(palloSound);
                break;
            case "flipper":
                audioSrc.volume = 0.3f;
                audioSrc.PlayOneShot(flipperSound);   //BUGI kun kaikki lyö samaa aikaa ääni tulee 4x
                break;
            case "piste":
                audioSrc.volume = 10.0f;
                audioSrc.PlayOneShot(pisteSound);
                break;
            case "powerup":
                audioSrc.PlayOneShot(powerupSound);
                break;

        }
    }
}
