using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToySpawnHardcore : MonoBehaviour {

   
    public List<Transform> PrefabSpawn;
    public float RandomRangeAmountZ;
    public float RandomRangeAmountX;
    public float timer;

    public AudioSource[] ToySpawnLaugh = null;
    AudioClip currentClip;
    // Use this for initialization
    void Start ()
    {
        timer = 3;
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Spawn();
            timer = 3;
        }
    }

    void Spawn()
    {
        if (!AnyClipIsPlaying())
        {
            ToySpawnLaugh[Random.Range(0, ToySpawnLaugh.Length)].Play();
        }
        RandomRangeAmountZ = Random.Range(1.064f, -1.072f);
        RandomRangeAmountX = Random.Range(0.426f, -0.43f);
        Instantiate(PrefabSpawn[Random.Range(0, PrefabSpawn.Count)], new Vector3(RandomRangeAmountX, 2, RandomRangeAmountZ), Quaternion.identity);
    }

    bool AnyClipIsPlaying()
    {
        for (int i = 0; i < ToySpawnLaugh.Length; i++)
        {
            if (ToySpawnLaugh[i].isPlaying) return true;
        }
        return false;
    }
}
