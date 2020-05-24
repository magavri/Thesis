using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject reference;
    public float speed = 2f;
    private float delay, timer;
    private Vector3 target;
    void Start()
    {
        delay = 6f; //10 sec delay before the camera starts to move
        target.x = reference.GetComponent<SpriteRenderer>().bounds.size.x * 2; //twice length of one background layer

    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delay)
        {
            float step = Time.deltaTime * speed;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
    }
    
}
