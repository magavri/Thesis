using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private static float cameraHeight = 0;
    private static float cameraDistance = -10f;
   
    private Vector3[] cameraPos =
    {
        new Vector3(0f,cameraHeight, cameraDistance),
        new Vector3(10f,cameraHeight, cameraDistance),
        new Vector3(19.2f,cameraHeight, cameraDistance),
        new Vector3(-19.2f,cameraHeight, cameraDistance),
    };
    void Update()
    {
        if (BaseCollision.index < 2)
        {
            CameraMove(3);
        }
        if (BaseCollision.index == 2)
        {
            CameraMove(0);
        }

        if (BaseCollision.index == 3)
        {
            CameraMove(1);
        }
        if (BaseCollision.index == 5)
        {
            CameraMove(2);
        }
    }
    private void CameraMove (int i)
    {
        var speed = 15f;
        float step = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, cameraPos[i], step);
        
    }
}
