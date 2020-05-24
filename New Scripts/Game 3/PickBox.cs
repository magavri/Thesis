using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class PickBox : MonoBehaviour
{
    public static int index = 1;
    private void Update()
   {
       Physics2D.IgnoreLayerCollision(0, 11);
   }

   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Contains("HouseBox") && transform.childCount == 0)
        {
            other.transform.parent = transform;
            other.transform.localPosition = Vector3.zero;
            EnableHouseParts.parts[index].gameObject.SetActive(true);
            index++;
        }
    }
}
 