using UnityEngine;


public class Scaling : MonoBehaviour
{
    /// <summary>
    /// Changing the scale of the object
    /// </summary>
    public void ScaleUp()
    {
        transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);
    }

    /// <summary>
    /// Changing the scale of the object
    /// </summary>
    public void ScaleDown()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}

