using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallUpright : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start ()
    {
        speed = 3.5f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Quaternion q = Quaternion.FromToRotation(transform.up, -Vector3.up) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
    }
}
