using UnityEngine;

public class EndMenuMove : MonoBehaviour
{
    //speed of the movement
    public float speed = 2f;
   //final position of the canvas
    private Vector3 target;

    private void Start()
    {
        target.x = -23.7f;
    }

    /// <summary>
    /// Moving the canvas to the target position
    /// </summary>
    void Update()
    {
        float step = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
}
