using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

    
    public static int scoreValue = 0;
    public int lives = 3;
    public GameObject InfoUI;
    public BoatMovement boatMovementScript;
    Text score;
    BoxCollider boxCollider;
    Transform player;

    public AudioSource[] SoliderPickup = null;
    public AudioSource BoatDeath;
    public AudioSource EnenyCollision;

    // Use this for initialization
    void Start ()
    {
        boxCollider = GetComponent<BoxCollider>();
        boatMovementScript = GetComponent<BoatMovement>();
        InfoUI = GameObject.FindGameObjectWithTag("UI");
        InfoUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DeathCheck();

        if (Input.GetKeyDown(KeyCode.I))
        {              
           if (InfoUI.activeSelf)
            {
                InfoUI.SetActive(false);
            }
           else
            {
                InfoUI.SetActive(true);
            }
        }
    }

    void DeathCheck()
    {
        if (lives <= 0)
        {
            if (!BoatDeath.isPlaying)
            {
                BoatDeath.Play();
            }
            boxCollider.isTrigger = true;
            GetComponent<Rigidbody>().useGravity = false;
            boatMovementScript.alive = false;
            Debug.Log(boatMovementScript.alive);
            Vector3 DeathPos = new Vector3(transform.position.x, transform.position.y-0.5f, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, DeathPos, 0.1f * Time.deltaTime);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Inital Collision");
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Health Reduction");
            lives -= 1;
            if (!EnenyCollision.isPlaying)
            {
                EnenyCollision.Play();
            }
        }

        if (other.gameObject.tag == "Solider")
        {
            Debug.Log("Solider Collision");
            ScoreScript.scoreValue += 1;
            Debug.Log("score" + ScoreScript.scoreValue);
            Destroy(other.gameObject);
            SoliderPickup[Random.Range(0, SoliderPickup.Length)].Play();
        }
        if (other.gameObject.tag == "EndGameCollider")
        {
            SceneManager.LoadScene(0);
        }
    }

    

}
