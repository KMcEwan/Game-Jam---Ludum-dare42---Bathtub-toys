using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public List<Transform> PrefabSpawn;
    public float RandomRangeAmountZ;
    public float RandomRangeAmountX;
    public float timer;

    public void PlayGameNormal()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayGameHard()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Start()
    {
        timer = 3;
    }

    // Update is called once per frame
    void Update()
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
        RandomRangeAmountZ = Random.Range(1.087f, -1.104f);
        RandomRangeAmountX = Random.Range(0.502f, -0.499f);
        Instantiate(PrefabSpawn[Random.Range(0, PrefabSpawn.Count)], new Vector3(RandomRangeAmountX, 2, RandomRangeAmountZ), Quaternion.identity);
    }
}
