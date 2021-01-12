using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
   
    public Rigidbody2D pallorigid;
   // public Transform pallotrans;
    public Transform prefab;
    
    // Start is called before the first frame update
    void Start()
    {

       // pallotrans = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallGravity>().getTransform();


        pallorigid = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallGravity>().getRigidbody();

    }

    // Update is called once per frame
    void Update()
    {
        /*
              if (Input.GetKeyDown(KeyCode.H))
              {

                  Instantiate(prefab, new Vector2(0, 0), Quaternion.identity);

                  pallorigid = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallGravity>().getRigidbody();
                  pallorigid.gravityScale = 100.0f;
                  // BallGravity.freeze = true;
              }
              if (Input.GetKeyDown(KeyCode.K))
              {
                  Destroy(GameObject.FindGameObjectWithTag("Ball"));
              }
              */
    }

}
