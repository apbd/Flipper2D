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

    

    private float r1;
    private int r2;
    private float r3x;
    private float r4y;

    private float r5s;
    

  
    public Text powerupTimerSpeed, powerupTimerBig, powerupTimerPower, powerupTimerGravity;

    void Update() 
    {
        HandleActivePowerups();  //kuuluu alkaa kun painaa menussa start



        if(r1 < 0.0f && BallGravity.freeze == false)
        {
            r1 = Random.Range(4.0f, 20.0f); //kauan kestää powerup spawniin
            r2 = Random.Range(0, 4);        //spawnattavat powerupit 1-4
            r3x = Random.Range(-4.0f, 4.0f); //spawnaus koord x
            r4y = Random.Range(-4.0f, 4.0f); //spawnaus koord y


            r5s = Random.Range(0.08f, 0.25f); //powerup koko, EI TOIMI ANIMAATION TAKIA!
            

            SpawnPowerup(powerups[r2], new Vector2(r3x, r4y), new Vector3(r5s, r5s, 0.0f));

         //   Debug.Log(r2);

        }

        
        r1 -= Time.deltaTime;     
    }

    public void HandleActivePowerups() 
    {
        bool changed = false;
        if (activePowerups.Count > 0) //onko uusia poweruppeja tullut
        {
            
           
            foreach (Powerup powerup in keys) //katsoo kaikki activoidut powerupit
            {
                //Debug.Log(powerup.name); //activated powerup name
                if (activePowerups[powerup] > 0) //jos activoituja poweruppeja on enemmän kuin 0
                {

                    
                    activePowerups[powerup] -= Time.deltaTime / 1.5f;   //aika jaetaan kahdella koska timescale MONIKERTAINe
                    
                    if (powerup.name == "HighSpeed") //laittaa ajan oikeaan poweruppiin
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

        if (changed)
        {
            keys = new List<Powerup>(activePowerups.Keys);
        }
    }

    public void ActivatePowerup(Powerup powerup)
    {
        if (!activePowerups.ContainsKey(powerup))
        {
            powerup.Start();
            activePowerups.Add(powerup, powerup.duration);
        }
        else
        {
            activePowerups[powerup] += powerup.duration;
        }

        keys = new List<Powerup>(activePowerups.Keys);
    }


    //antaa powerupille ominaisuudet  ja palauttaa powerupin gameobjectina
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
