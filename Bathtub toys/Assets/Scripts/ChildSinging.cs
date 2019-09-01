using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildSinging : MonoBehaviour
{

    public float timer;
    public AudioSource[] ChildSing = null;

    // Use this for initialization
    void Start()
    {
        timer = 60;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            ChildSing[Random.Range(0, ChildSing.Length)].Play();
            timer = 60;
        }
    }
}
