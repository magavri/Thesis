using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private static float carHeight = - 6.5f;
    private float speed;
    // new Vector3(-14.15f, carHeight) //initial
    private Vector3[] carPos =
    {
        new Vector3(-7.7f, carHeight),
        new Vector3(4.2f, carHeight),
        new Vector3(16.7f, carHeight),
        new Vector3(24.08f, carHeight),
        new Vector3(36.5f, carHeight)
    };
    

    private void Update()
    {
        speed = 6f;
        float step = Time.deltaTime * speed;
        Vector3 target = new Vector3(-14.5f, carHeight);
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        if (BaseCollision.index != 0)
        {
            CarMove(BaseCollision.index-1);
        }
    }

    private void CarMove (int i)
    {
        speed = 9f;
        float step = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, carPos[i], step);
        
    }
}
