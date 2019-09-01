using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour {
    public bool alive = true;
    public float speed;
    public float turningSpeed;
    public float speedMultiplyer;
    public float speedMultiplyer1;
    public AudioSource[] BoatMovements = null;

    Animator TurningAnimation;

    private Rigidbody rigidbody;

    // Use this for initialization
    void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        TurningAnimation = GetComponentInChildren<Animator>();        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
    }

    private void FixedUpdate()
    {
        if (alive)
        {
            if (Input.GetKey(KeyCode.W))
        {
            speedMultiplyer = 1;
            speedMultiplyer1 = 0;
            if (!BoatMovements[0].isPlaying)
            {
                BoatMovements[0].Play();                    
            }
        }
        else
        if (Input.GetKey(KeyCode.S))
        {
            speedMultiplyer1 = 1;
            speedMultiplyer = 0;
            if (!BoatMovements[1].isPlaying)
            {
                BoatMovements[1].Play();                    
            }
        }
        else
        {
            speedMultiplyer = Mathf.MoveTowards(speedMultiplyer, 0, 0.1f * Time.deltaTime);
            speedMultiplyer1 = Mathf.MoveTowards(speedMultiplyer1, 0, 0.1f * Time.deltaTime);
            BoatMovements[2].Stop();
        }
       
            movement();
        }
        else
        {
            BoatMovements[2].Stop();
        }
       
    }

    void movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles += new Vector3(0, Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime, 0);
            TurningAnimation.SetBool("TurningRight", true);
        }
        else
        {
            TurningAnimation.SetBool("TurningRight", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles += new Vector3(0, Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime, 0);
            TurningAnimation.SetBool("TurningLeft", true);
        }
        else
        {
            TurningAnimation.SetBool("TurningLeft", false);
        }
        if (speedMultiplyer > 0) 
        {
            transform.position += transform.forward * Time.deltaTime * speed * speedMultiplyer;
        }
        if (speedMultiplyer1 > 0)
        {
            transform.position -= transform.forward * Time.deltaTime * speed * speedMultiplyer1;
        }
    }
}
