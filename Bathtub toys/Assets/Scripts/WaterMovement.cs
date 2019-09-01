using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour {

    public float strength;
    public float scale;
    public float time;

    private float width;
    private float height;
    private MeshFilter meshFil;

    // Use this for initialization
    void Start ()
    {
        meshFil = GetComponent<MeshFilter>();
        GenMovement();
    }
	
	// Update is called once per frame
	void Update ()
    {
        GenMovement();
        width += Time.deltaTime * time;
        height += Time.deltaTime * time;
	}

    void GenMovement()
    {
        Vector3[] vertices = meshFil.mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = calcualteHeight(vertices[i].x, vertices[i].z) * strength;
        }

        meshFil.mesh.vertices = vertices;
    }

    float calcualteHeight(float x, float y)
    {
        float xpos = x * scale + width;
        float ypos = y * scale + height;

        return Mathf.PerlinNoise(xpos, ypos);
    }
}
