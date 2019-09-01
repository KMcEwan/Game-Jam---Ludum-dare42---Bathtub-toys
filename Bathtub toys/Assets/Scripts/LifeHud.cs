using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeHud : MonoBehaviour {

    public Sprite[] lifeBoats;    
    public Image lifeBoatsUI;

    private PlayerScript player;
    private BoatMovement boatAlive;
    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        boatAlive = GameObject.FindGameObjectWithTag("Player").GetComponent<BoatMovement>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (boatAlive.alive == true)
        {
            lifeBoatsUI.sprite = lifeBoats[player.lives];
        }
	}
}
