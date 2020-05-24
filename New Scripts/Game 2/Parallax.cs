using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject camera;
    private float length, initialPos;
    public float parallax;
    void Start()
    {
        initialPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x; //getting the length of one background layer

    }

    void FixedUpdate()
    {
        float temp = (camera.transform.position.x * (1 - parallax));
        float distance = (camera.transform.position.x * parallax);
        transform.position = new Vector3(initialPos + distance, transform.position.y, transform.position.z);
        if (temp > initialPos + length)
        {
            initialPos += length;
        }
        else if (temp < initialPos - length)
        {
            initialPos -= length;
        }
    }
}
