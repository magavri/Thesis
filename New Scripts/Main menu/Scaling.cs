using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Scaling : MonoBehaviour
{
    public void ScaleUp()
    {
        transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);
        Debug.Log("yooo");
    }

    public void ScaleDown()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}

