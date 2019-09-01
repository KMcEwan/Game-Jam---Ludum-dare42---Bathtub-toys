using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderSpawn : MonoBehaviour {

    public Transform SoliderPrefabSpawn;
    public float RandomRangeAmountZ;
    public float RandomRangeAmountX;
    public float timer;
    //public AudioSource[] ToySpawnLaugh = null;

    void Start ()
    {
        timer = 5;
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Spawn();
            timer = 5;
        }
    }

    void Spawn()
    {
        //ToySpawnLaugh[Random.Range(0, ToySpawnLaugh.Length)].Play();
        RandomRangeAmountZ = Random.Range(1.064f, -1.072f);
        RandomRangeAmountX = Random.Range(0.426f, -0.43f);
        Instantiate(SoliderPrefabSpawn, new Vector3(RandomRangeAmountX, 2, RandomRangeAmountZ), Quaternion.identity);
    }
}
