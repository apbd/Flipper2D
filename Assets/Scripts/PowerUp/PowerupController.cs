using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PowerupController : MonoBehaviour
{
    public GameObject powerupPrefab;

    public List<Powerup> powerups;

    public Dictionary<Powerup, float> activePowerups = new Dictionary<Powerup, float>();

    private List<Powerup> keys = new List<Powerup>();


    private float _randomPowerupSpawnDuration;
    private int _randomPowerupSpawn;
    private float _randomCoordX;
    private float _randomCoordY;

    private float _randomPowerupSize;
  
    public Text powerupTimerSpeed, powerupTimerBig, powerupTimerPower, powerupTimerGravity;

    void Update() 
    {
        HandleActivePowerups();  //needs to be called when pressing start in menu



        if(_randomPowerupSpawnDuration < 0.0f && BallGravity.ballFreeze == false)
        {
            _randomPowerupSpawnDuration = Random.Range(4.0f, 20.0f);    // how long for powerup spawn
            _randomPowerupSpawn = Random.Range(0, 4);                   // which powerup spawns 1-4
            _randomCoordX = Random.Range(-4.0f, 4.0f);                  // spawning coordinate x
            _randomCoordY = Random.Range(-4.0f, 4.0f);                  // spawnining coord y


            _randomPowerupSize = Random.Range(0.08f, 0.25f);   // powerup size, BUG: doesnt work cause of animation!
            

            SpawnPowerup(powerups[_randomPowerupSpawn], new Vector2(_randomCoordX, _randomCoordY), new Vector3(_randomPowerupSize, _randomPowerupSize, 0.0f));
        }
        // reduces duration as time goes on and gains more time when it reaches 0
        _randomPowerupSpawnDuration -= Time.deltaTime;
    }

    public void HandleActivePowerups() 
    {
        bool changed = false;
        if (activePowerups.Count > 0)    // Are there new powerups?
        {
            foreach (Powerup powerup in keys)   // looks at all the activated powerups
            {
                //Debug.Log(powerup.name);   // activated powerup name
                if (activePowerups[powerup] > 0)    // if there are activated powerups
                {
                    activePowerups[powerup] -= Time.deltaTime / 1.5f;   //  time is divided by 1.5 because timescale is 1.5

                    // displays durations of the correct powerups as text in scene
                    if (powerup.name == "HighSpeed") 
                    {
                        powerupTimerSpeed.text = Mathf.RoundToInt(activePowerups[powerup]).ToString();
                    }
                    else if (powerup.name == "BigBall") //scale powerup
                    {
                        powerupTimerBig.text = Mathf.RoundToInt(activePowerups[powerup]).ToString();
                    }
                    else if (powerup.name == "Power") //powerful flippers powerup
                    {
                        powerupTimerPower.text = Mathf.RoundToInt(activePowerups[powerup]).ToString();
                    }
                    else if (powerup.name == "Gravity") //gravityless/gravity changes powerup
                    {
                        powerupTimerGravity.text = Mathf.RoundToInt(activePowerups[powerup]).ToString();
                    }
                }
                else
                {
                    changed = true;
                    activePowerups.Remove(powerup);
                    powerup.End();
                }
            }
        }

        // if something changed make new list that has key of every active powerup
        if (changed)
        {
            keys = new List<Powerup>(activePowerups.Keys);
        }
    }

    public void ActivatePowerup(Powerup powerup)
    {
        // if activepowerups dic doesnt have key of powerup, start powerup and add it
        if (!activePowerups.ContainsKey(powerup))
        {
            powerup.Start();
            activePowerups.Add(powerup, powerup.duration);
        }
        // else add more duration to the existing one
        else
        {
            activePowerups[powerup] += powerup.duration;
        }

        // make new list that has key of every active powerup
        keys = new List<Powerup>(activePowerups.Keys);
    }


    // gives powerup features and returns it as object
    public GameObject SpawnPowerup(Powerup powerup, Vector2 position, Vector3 scale)
    {
        GameObject powerupGameObject = Instantiate(powerupPrefab);

        var powerupBehaviour = powerupGameObject.GetComponent<PowerupBehaviour>();
        

        powerupBehaviour.controller = this;

        powerupBehaviour.SetPowerup(powerup);

      
        powerupGameObject.transform.position = position;
        powerupGameObject.transform.localScale = scale;


        return powerupGameObject;
    }
}
